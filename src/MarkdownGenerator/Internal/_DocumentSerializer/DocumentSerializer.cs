using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal partial class DocumentSerializer : IBlockVisitor
    {
        private static readonly char[] s_LineBreakChars = "\r\n".ToCharArray();

        private readonly PrefixTextWriter m_Writer;
        private readonly MdSerializationOptions m_Options;
        private int m_ListLevel = 0;
        private int m_BulletListLevel = 0;
        

        public DocumentSerializer(TextWriter writer) : this(writer, null)
        { }

        public DocumentSerializer(TextWriter writer, MdSerializationOptions options)
        {
            m_Writer = new PrefixTextWriter(writer ?? throw new ArgumentNullException(nameof(writer)));
            m_Options = options ?? MdSerializationOptions.Default;
        }


        public void Serialize(MdDocument document) => document.Root.Accept(this);


        public void Visit(MdContainerBlock containerBlock)
        {
            foreach(var block in containerBlock)
            {
                block.Accept(this);
            }
        }

        public void Visit(MdEmptyBlock emptyBlock)
        {
            // block is empty by definition => no need to write anything to the output
        }

        public void Visit(MdBlockQuote blockQuote)
        {         
            m_Writer.PushPrefixHandler(new BlockQuotePrefixHandler());
            foreach (var block in blockQuote)
            {
                block.Accept(this);
            }
            m_Writer.PopPrefixHandler();            
        }

        public void Visit(MdListItem listItem)
        {
            foreach (var block in listItem)
            {
                block.Accept(this);
            }
        }

        public void Visit(MdHeading block)
        {
            m_Writer.RequestBlankLine();
            
            if(m_Options.HeadingStyle == MdHeadingStyle.Setext && block.Level <= 2)
            {
                var underlineChar = block.Level == 1 ? '=' : '-';
                var text = block.Text.ToString(m_Options);

                // if no maximum line length was specified, write heading into a single line
                if(m_Options.MaxLineLength <= 0)
                {
                    m_Writer.WriteLine(text);
                    m_Writer.WriteLine(new String(underlineChar, text.Length));
                }
                // is max line length was specified, split the value into multiple lines if necessary
                else
                {
                    var headingTextLines = LineFormatter.GetLines(text, m_Options.MaxLineLength - m_Writer.PrefixLength);
                    foreach(var line in headingTextLines)
                    {
                        m_Writer.WriteLine(line);
                    }
                    m_Writer.WriteLine(new String(underlineChar, headingTextLines.Max(x => x.Length)));
                }                
            }
            else
            {
                m_Writer.WriteLine($"{new String('#', block.Level)} {block.Text.ToString(m_Options)}");
            }

            m_Writer.RequestBlankLine();
        }

        public void Visit(MdParagraph paragraph)
        {
            m_Writer.RequestBlankLine();
            
            var lines = paragraph.Text.ToString(m_Options).Split(s_LineBreakChars, StringSplitOptions.RemoveEmptyEntries);

            // skip paragraph if it is empty
            if (lines.Length == 0)
                return;

            for (var i = 0; i < lines.Length; i++)
            {
                // get the current line
                var line = lines[i];

                // if the line is not the last, append 2 spaces to 
                // cause a line break in the output
                // for the last line, this can be omitted, as there will 
                // be a blank line after the paragraph
                if (i != lines.Length - 1)
                {
                    line += "  ";
                }

                // no maximum line length specified => write the line to the output
                if(m_Options.MaxLineLength <= 0)
                {
                    m_Writer.WriteLine(line);
                }
                // maximum line length specified 
                // => format lines to max length and write all lines to the output
                else
                {
                    var formattedLines = LineFormatter.GetLines(line, m_Options.MaxLineLength - m_Writer.PrefixLength);
                    foreach(var formattedLine in formattedLines)
                    {
                        m_Writer.WriteLine(formattedLine);
                    }
                }               
            }

            m_Writer.RequestBlankLine();
        }

        public void Visit(MdBulletList bulletList)
        {
            m_BulletListLevel += 1;
            VisitList(bulletList);
            m_BulletListLevel -= 1;
        }
        
        public void Visit(MdOrderedList orderedList) => VisitList(orderedList);

        private void VisitList(MdList list)
        {
            m_ListLevel += 1;


            if(m_ListLevel == 1)
            {
                // top-level lists should be surrounded by blank lines
                m_Writer.RequestBlankLine();
            }
            else
            {
                // prevent blank lines before nested lists
                // (blank lines may have been requested by block in parent list item)
                m_Writer.CancelRequestBlankLine();
            }

            // add prefix handler for the list
            var prefixHandler = GetListPrefixHandler(list);
            m_Writer.PushPrefixHandler(prefixHandler);

            var listItemNumber = 1;
            foreach (var listItem in list)
            {
                prefixHandler.BeginListItem();

                var lineWritten = false;

                // event handler to prevent blank lines at the start of list items
                void OnBlankLineRequested(object s, EventArgs e)
                {
                    // blank lines before top level lists ( = before the first item)
                    // should not be suppressed
                    if (listItemNumber == 1 && m_ListLevel == 1)
                        return;

                    // while no other line was written, suppress blank lines
                    if(!lineWritten)
                        m_Writer.CancelRequestBlankLine();
                }

                // event handler to update the prefix after the first line of a list item
                void OnLineWritten(object s, EventArgs e)
                {
                    lineWritten = true;
                }

                // attach event handlers
                m_Writer.LineWritten += OnLineWritten;
                m_Writer.BlankLineRequested += OnBlankLineRequested;

                // write list item
                listItem.Accept(this);

                // detach event handlers
                m_Writer.LineWritten -= OnLineWritten;
                m_Writer.BlankLineRequested -= OnBlankLineRequested;

                // prevent blank lines from being inserted after list items
                m_Writer.CancelRequestBlankLine();

                listItemNumber += 1;
            }

            // remove prefix handler
            m_Writer.PopPrefixHandler();

            // top-level lists should be surrounded by blank lines
            if (m_ListLevel == 1)
                m_Writer.RequestBlankLine();

            m_ListLevel -= 1;
        }
        
        public void Visit(MdCodeBlock codeBlock)
        {
            string codeFence;
            switch (m_Options.CodeBlockStyle)
            {
                case MdCodeBlockStyle.Backtick:
                    codeFence = "```";
                    break;

                case MdCodeBlockStyle.Tilde:
                    codeFence = "~~~";
                    break;

                default:
                    throw new ArgumentException($"Unsupported code block style: {m_Options.CodeBlockStyle}");
            }

            m_Writer.WriteLine($"{codeFence}{codeBlock.InfoString ?? ""}");
            
            var lines = codeBlock.Text.Split(s_LineBreakChars, StringSplitOptions.RemoveEmptyEntries);
            foreach(var line in lines)
            {
                m_Writer.WriteLine(line);
            }

            m_Writer.WriteLine(codeFence);
        }

        public void Visit(MdTable table)
        {
            switch (m_Options.TableStyle)
            {
                case MdTableStyle.GFM:
                    SerializeGFMTable(table);
                    break;

                case MdTableStyle.Html:
                    SerializeHtmlTable(table);
                    break;
                
                default:
                    throw new ArgumentException($"Unsupported table style: {m_Options.TableStyle}");
            }
        }

        public void SerializeGFMTable(MdTable table)
        {      
            // convert table to string
            var tableAsString = new[] { table.HeaderRow }.Union(table.Rows)
                    .Select(row =>
                        row.Cells
                            .Select(c => c.ToString(m_Options))
                            .ToArray())
                    .ToArray();

            // determine the maximum width of every column
            var columnWidths = new int[table.ColumnCount];
            for (var rowIndex = 0; rowIndex < tableAsString.Length; rowIndex++)
            {                
                for (var columnIndex = 0; columnIndex < tableAsString[rowIndex].Length; columnIndex++)
                {
                    columnWidths[columnIndex] = Math.Max(
                        columnWidths[columnIndex],
                        tableAsString[rowIndex][columnIndex].Length);
                }
            }            

            // helper functions that writes a single row to the output
            void SaveRow(string[] row)
            {                
                var lineBuilder = new StringBuilder();                
                lineBuilder.Append("|");
                for (var i = 0; i < columnWidths.Length; i++)
                {                   
                    // current row has a cell for column i
                    if (i < row.Length)
                    {
                        lineBuilder.Append(" ");
                        lineBuilder.Append(row[i].PadRight(columnWidths[i]));
                        lineBuilder.Append(" ");
                    }                        
                    // row has less columns than the table => write out empty cell
                    else
                    {
                        lineBuilder.AppendRepeat(' ', columnWidths[i] + 2);
                    }

                    lineBuilder.Append("|");
                }
                m_Writer.WriteLine(lineBuilder.ToString());
            }

            m_Writer.RequestBlankLine();

            // save header row
            SaveRow(tableAsString[0]);

            // write separator between header and table
            var separatorLineBuilder = new StringBuilder();
            separatorLineBuilder.Append("|");
            for (var i = 0; i < columnWidths.Length; i++)
            {
                separatorLineBuilder.Append(' ');
                separatorLineBuilder.AppendRepeat('-', columnWidths[i]);
                separatorLineBuilder.Append(' ');
                separatorLineBuilder.Append("|");
            }
            m_Writer.WriteLine(separatorLineBuilder.ToString());
            
            // write table rows
            foreach(var row in tableAsString.Skip(1))
            {
                SaveRow(row);
            }

            m_Writer.RequestBlankLine();
        }

        public void SerializeHtmlTable(MdTable table)
        {
            // Begin table
            m_Writer.WriteLine("<table>");

            // table head
            m_Writer.WriteLine("  <thead>");
            m_Writer.WriteLine("    <tr>");
            foreach(var cell in table.HeaderRow)
            {
                m_Writer.WriteLine($"      <th>{cell.ToString(m_Options)}</th>");
            }
            m_Writer.WriteLine("    </tr>");
            m_Writer.WriteLine("  </thead>");

            // table body
            m_Writer.WriteLine("  <tbody>");
            foreach(var row in table.Rows)
            {
                m_Writer.WriteLine("    <tr>");
                foreach (var cell in row)
                {
                    m_Writer.WriteLine($"      <td>{cell.ToString(m_Options)}</td>");
                }
                m_Writer.WriteLine("    </tr>");
            }
            m_Writer.WriteLine("  </tbody>");

            // End table
            m_Writer.WriteLine("</table>");


        }

        public void Visit(MdThematicBreak thematicBreak)
        {
            var style = m_Options.ThematicBreakStyle;

            // if a thematic break occurs inside a bullet list
            // and the configured style of the list and the thematic break are configured the same
            // the thematic break takes precedence and hence the list is rendered incorrectly
            // (s. https://spec.commonmark.org/0.28/#thematic-breaks)
            // To avoid this conflict, check for this scenario and change the style 
            // of the thematic break if necessary
            if (m_BulletListLevel > 0)
            {
                if((style == MdThematicBreakStyle.Dash && m_Options.BulletListStyle == MdBulletListStyle.Dash)
                    ||
                    (style == MdThematicBreakStyle.Asterisk && m_Options.BulletListStyle == MdBulletListStyle.Asterisk))
                {
                    style = MdThematicBreakStyle.Underscore;
                }               
            }

            switch (style)
            {
                case MdThematicBreakStyle.Dash:
                    m_Writer.WriteLine("---");
                    break;

                case MdThematicBreakStyle.Asterisk:
                    m_Writer.WriteLine("***");
                    break;

                case MdThematicBreakStyle.Underscore:
                    m_Writer.WriteLine("___");
                    break;

                default:
                    throw new ArgumentException($"Unsupported thematic break style: {m_Options.ThematicBreakStyle}");                    
            }            
        }


        private ListPrefixHandler GetListPrefixHandler(MdList list)
        {
            switch (list)
            {
                case MdBulletList _:
                    return new BulletListPrefixHandler(m_Options);

                case MdOrderedList _:
                    return new OrderedListPrefixHandler(m_Options);

                default:
                    throw new NotSupportedException($"Unsupported list type: {list.GetType().FullName}");
            }
        }

    }
}
