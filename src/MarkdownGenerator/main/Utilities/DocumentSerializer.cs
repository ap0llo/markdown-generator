using System;
using System.IO;
using System.Text;
using Grynwald.MarkdownGenerator.Model;

namespace Grynwald.MarkdownGenerator.Utilities
{
    internal class DocumentSerializer
    {
        private readonly PrefixTextWriter m_Writer;
        private int m_ListLevel = 0;


        public DocumentSerializer(TextWriter writer)
        {
            m_Writer = new PrefixTextWriter(writer ?? throw new ArgumentNullException(nameof(writer)));
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

            m_Writer.WriteLine($"{new String('#', block.Level)} {block.Text}");

            m_Writer.RequestBlankLine();
        }

        public void Serialize(MdParagraph paragraph)
        {
            m_Writer.RequestBlankLine();

            var lines = paragraph.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
            var prefixHandler = new ListPrefixHandler(list.Kind);
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
            m_Writer.WriteLine($"```{codeBlock.InfoString ?? ""}");
            
            var lines = codeBlock.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach(var line in lines)
            {
                m_Writer.WriteLine(line);
            }

            m_Writer.WriteLine("```");
        }

        public void Serialize(MdTable table)
        {

            //TODO: Remove line breaks from cells
            //TODO: Escape |

            var tableColumnCount = table.ColumnCount;

            void SaveRow(MdTableRow row )
            {
                var lineBuilder = new StringBuilder();

                lineBuilder.Append("|");
                for (var i = 0; i < tableColumnCount; i++)
                {
                    if (i < row.ColumnCount)
                    {
                        lineBuilder.Append(" ");
                        lineBuilder.Append(row[i].PadRight(table.GetColumnWidth(i)));
                        lineBuilder.Append(" ");
                    }                        
                    else
                    {
                        lineBuilder.AppendRepeat(' ', table.GetColumnWidth(i) + 2);
                    }

                    lineBuilder.Append("|");
                }

                m_Writer.WriteLine(lineBuilder.ToString());
            }

            // save header row
            SaveRow(table.HeaderRow);

            // write separator between header and table
            var separatorLineBuilder = new StringBuilder();
            separatorLineBuilder.Append("|");
            for (var i = 0; i < tableColumnCount; i++)
            {
                separatorLineBuilder.Append(' ');
                separatorLineBuilder.AppendRepeat('-', table.GetColumnWidth(i));
                separatorLineBuilder.Append(' ');
                separatorLineBuilder.Append("|");
            }
            m_Writer.WriteLine(separatorLineBuilder.ToString());
            
            // write table rows
            foreach(var row in table)
            {
                SaveRow(row);
            }            
        }

        public void Serialize(MdThematicBreak thematicBreak)
        {
            m_Writer.WriteLine("---");
        }       
    }
}
