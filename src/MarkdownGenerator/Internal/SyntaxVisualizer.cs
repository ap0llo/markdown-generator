using System;
using System.Text;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal class SyntaxVisualizer
    {
        private class SyntaxVisualizerVisitor : IBlockVisitor, ISpanVisitor
        {
            private readonly StringBuilder m_Builder;
            private int m_Indentation = 0;


            public SyntaxVisualizerVisitor(StringBuilder writer)
            {
                m_Builder = writer ?? throw new ArgumentNullException(nameof(writer));
            }


            public void Visit(MdHeading heading)
            {
                AppendTypeName(heading);
                m_Indentation += 1;
                heading.Text.Accept(this);
                m_Indentation -= 1;
            }

            public void Visit(MdParagraph paragraph)
            {
                AppendTypeName(paragraph);
                m_Indentation += 1;
                paragraph.Text.Accept(this);
                m_Indentation -= 1;
            }

            public void Visit(MdContainerBlock containerBlock) => VisitContainer(containerBlock);

            public void Visit(MdThematicBreak thematicBreak) => AppendTypeName(thematicBreak);

            public void Visit(MdTable table)
            {
                AppendTypeName(table);

                m_Indentation += 1;

                VisitTableRow(table.HeaderRow);                

                foreach (var row in table.Rows)
                {
                    VisitTableRow(row);
                }

                m_Indentation -= 1;
            }

            public void Visit(MdBulletList bulletList) => VisitList(bulletList);

            public void Visit(MdOrderedList orderedList) => VisitList(orderedList);

            public void Visit(MdListItem listItem) => VisitContainer(listItem);

            public void Visit(MdEmptyBlock emptyBlock) => AppendTypeName(emptyBlock);

            public void Visit(MdBlockQuote blockQuote) => VisitContainer(blockQuote);

            public void Visit(MdCodeBlock codeBlock) => AppendTypeName(codeBlock);


            private void AppendTypeName(object item)
            {
                for (int i = 0; i < m_Indentation; i++)
                {
                    m_Builder.Append("  ");
                }
                m_Builder.AppendLine(item.GetType().Name);
            }

            public void VisitContainer(MdContainerBlockBase block)
            {
                AppendTypeName(block);

                m_Indentation += 1;
                foreach (var item in block)
                {
                    item.Accept(this);
                }
                m_Indentation -= 1;
            }

            private void VisitList(MdList list)
            {
                AppendTypeName(list);

                m_Indentation += 1;
                foreach (var listItem in list)
                {
                    listItem.Accept(this);
                }
                m_Indentation -= 1;
            }

            private void VisitTableRow(MdTableRow row)
            {
                AppendTypeName(row);
                m_Indentation += 1;
                foreach(var cell in row)
                {
                    cell.Accept(this);
                }
                m_Indentation -= 1;
            }

            public void Visit(MdEmptySpan span) => AppendTypeName(span);

            public void Visit(MdTextSpan span) => AppendTypeName(span);

            public void Visit(MdEmphasisSpan span)
            {
                AppendTypeName(span);

                m_Indentation += 1;
                span.Text.Accept(this);
                m_Indentation -= 1;
            }

            public void Visit(MdStrongEmphasisSpan span)
            {
                AppendTypeName(span);

                m_Indentation += 1;
                span.Text.Accept(this);
                m_Indentation -= 1;
            }

            public void Visit(MdCodeSpan span) => AppendTypeName(span);

            public void Visit(MdCompositeSpan compositeSpan)
            {
                AppendTypeName(compositeSpan);
                m_Indentation += 1;
                foreach(var span in compositeSpan)
                {
                    span.Accept(this);
                }
                m_Indentation -= 1;

            }

            public void Visit(MdLinkSpan span) => AppendTypeName(span);

            public void Visit(MdImageSpan span) => AppendTypeName(span);

            public void Visit(MdSingleLineSpan singleLineSpan)
            {
                AppendTypeName(singleLineSpan);
                m_Indentation += 1;
                singleLineSpan.Content.Accept(this);
                m_Indentation -= 1;
            }

            public void Visit(MdRawMarkdownSpan span) => AppendTypeName(span);
        }


        public static string GetSyntaxTree(MdBlock block)
        {
            var stringBuilder = new StringBuilder();
            var visitor = new SyntaxVisualizerVisitor(stringBuilder);
            block.Accept(visitor);
            return stringBuilder.ToString();
        }

    }
}
