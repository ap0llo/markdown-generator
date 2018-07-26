using System;
using System.IO;
using System.Linq;
using System.Text;
using Grynwald.MarkdownGenerator.Model;

namespace Grynwald.MarkdownGenerator.Utilities
{
    internal class DocumentSerializer
    {
        private readonly PrefixTextWriter m_Writer;
        private readonly MdSerializationOptions m_Options;
        private int m_ListLevel = 0;

        
        public DocumentSerializer(TextWriter writer) : this(writer, null)
        { }

        public DocumentSerializer(TextWriter writer, MdSerializationOptions options)
        {
            m_Writer = new PrefixTextWriter(writer ?? throw new ArgumentNullException(nameof(writer)));
            m_Options = options ?? new MdSerializationOptions();
        }


        public void Serialize(MdDocument document) => Serialize(document.Root);

        public void Serialize(MdBlock block)
        {
            switch(block)
            {
                case MdList list:
                    Serialize(list);
                    break;

                case MdContainerBlock containerBlock:
                    Serialize(containerBlock);
                    break;

                case MdHeading heading:
                    Serialize(heading);
                    break;

                case MdParagraph paragraph:
                    Serialize(paragraph);
                    break;

                case MdCodeBlock codeBlock:
                    Serialize(codeBlock);
                    break;

                case MdTable table:
                    Serialize(table);
                    break;

                case MdThematicBreak thematicBreak:
                    Serialize(thematicBreak);
                    break;

                case MdBlockQuote blockQuote:
                    Serialize(blockQuote);
                    break;

                default:
                    throw new NotSupportedException($"Unsupported block type {block.GetType().FullName}");
            }

        }

        public void Serialize(MdContainerBlock containerBlock)
        {
            foreach(var block in containerBlock)
            {
                Serialize(block);
            }
        }

        public void Serialize(MdBlockQuote blockQuote)
        {         
            m_Writer.PushPrefixHandler(new BlockQuotePrefixHandler());
            foreach (var block in blockQuote)
            {
                Serialize(block);
            }
            m_Writer.PopPrefixHandler();
            
        }

        public void Serialize(MdListItem listItem)
        {
            foreach (var block in listItem)
            {
                Serialize(block);
            }
        }

        public void Serialize(MdHeading block)
        {
            m_Writer.RequestBlankLine();
            
            if(m_Options.HeadingStyle == MdHeadingStyle.Setex && block.Level <= 2)
            {
                var headingText = block.Text.ToString(m_Options);
                m_Writer.WriteLine(headingText);

                var underlineChar = block.Level == 1 ? '=' : '-';
                m_Writer.WriteLine(new String(underlineChar, headingText.Length));
            }
            else
            {
                m_Writer.WriteLine($"{new String('#', block.Level)} {block.Text.ToString(m_Options)}");
            }

            m_Writer.RequestBlankLine();
        }

        public void Serialize(MdParagraph paragraph)
        {
            m_Writer.RequestBlankLine();
            
            var lines = paragraph.Text.ToString(m_Options).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length == 0)
                return;

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                if (i != lines.Length - 1)
                    line += "  ";

                m_Writer.WriteLine(line);
            }

            m_Writer.RequestBlankLine();

        }

        public void Serialize(MdList list)
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
            var prefixHandler = list.Kind == MdListKind.Bullet
                ? (ListPrefixHandler) new BulletListPrefixHandler(m_Options.BulletListStyle)
                : (ListPrefixHandler) new OrderedListPrefixHandler(m_Options.OrderedListStyle);
            
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
                    // should not be supressed
                    if (listItemNumber == 1 && m_ListLevel == 1)
                        return;

                    // while no other line was written, suppress blank lines
                    if(!lineWritten)
                        m_Writer.CancelRequestBlankLine();
                }

                // event handler to update the prefix after the first line of a list item
                void OnLineWritten(object s, EventArgs e)
                {
                    // no action after first line required => unsubscribe from event
                    lineWritten = true;
                }
                
                // attach event handlers
                m_Writer.LineWritten += OnLineWritten;
                m_Writer.BlankLineRequested += OnBlankLineRequested;

                // write list item
                Serialize(listItem);

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

        public void Serialize(MdCodeBlock codeBlock)
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
            
            var lines = codeBlock.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach(var line in lines)
            {
                m_Writer.WriteLine(line);
            }

            m_Writer.WriteLine(codeFence);
        }

        public void Serialize(MdTable table)
        {      
            // convert table to string
            var tableAsString = new[] { table.HeaderRow }.Union(table.Rows)
                    .Select(row =>
                        row.Cells
                            .Select(c => c.ToString(m_Options))
                            .ToArray())
                    .ToArray();

            // determine the maxmum width of every column
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
        }

        public void Serialize(MdThematicBreak thematicBreak)
        {
            switch (m_Options.ThematicBreakStyle)
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
        
    }
}
