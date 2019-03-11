using System;
using System.Text;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal class SyntaxVisualizer
    {
        private class SyntaxVisualizerVisitor : IBlockVisitor
        {
            private readonly StringBuilder m_Builder;
            private int m_Indentation = 0;


            public SyntaxVisualizerVisitor(StringBuilder writer)
            {
                m_Builder = writer ?? throw new ArgumentNullException(nameof(writer));
            }


            public void Visit(MdHeading heading) => AppendTypeName(heading);

            public void Visit(MdParagraph paragraph) => AppendTypeName(paragraph);

            public void Visit(MdContainerBlock containerBlock) => VisitContainer(containerBlock);

            public void Visit(MdThematicBreak thematicBreak) => AppendTypeName(thematicBreak);

            public void Visit(MdTable table)
            {
                AppendTypeName(table);

                m_Indentation += 1;

                AppendTypeName(table.HeaderRow);
                foreach (var row in table.Rows)
                {
                    AppendTypeName(row);
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
