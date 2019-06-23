using System;
using System.Collections.Generic;
using Grynwald.MarkdownGenerator.Extensions;
using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    public static class SyntaxVisualizer
    {
        /// <summary>
        /// Visitor to convert a set of blocks and spans to a <see cref="AsciiTreeNode"/>
        /// </summary>
        private class GraphBuildingVisitor : IBlockVisitor, ISpanVisitor
        {
            private readonly Stack<AsciiTreeNode> m_Nodes = new Stack<AsciiTreeNode>();

            private AsciiTreeNode CurrentNode => m_Nodes.Peek();

            public AsciiTreeNode RootNode { get; private set; }


            public void Visit(MdHeading heading)
            {
                PushNewNode(heading);
                heading.Text.Accept(this);
                PopNode();
            }

            public void Visit(MdParagraph paragraph)
            {
                PushNewNode(paragraph);
                paragraph.Text.Accept(this);
                PopNode();
            }

            public void Visit(MdContainerBlock containerBlock) => VisitContainer(containerBlock);

            public void Visit(MdThematicBreak thematicBreak) => CreateLeafNode(thematicBreak);

            public void Visit(MdTable table)
            {
                PushNewNode(table);

                VisitTableRow(table.HeaderRow);

                foreach (var row in table.Rows)
                {
                    VisitTableRow(row);
                }

                PopNode();
            }

            public void Visit(MdBulletList bulletList) => VisitList(bulletList);

            public void Visit(MdOrderedList orderedList) => VisitList(orderedList);

            public void Visit(MdListItem listItem) => VisitContainer(listItem);

            public void Visit(MdBlockQuote blockQuote) => VisitContainer(blockQuote);

            public void Visit(MdCodeBlock codeBlock) => CreateLeafNode(codeBlock);

            public void Visit(MdEmptySpan span) => CreateLeafNode(span);

            public void Visit(MdTextSpan span) => CreateLeafNode(span);

            public void Visit(MdEmphasisSpan span)
            {
                PushNewNode(span);
                span.Text.Accept(this);
                PopNode();
            }

            public void Visit(MdStrongEmphasisSpan span)
            {
                PushNewNode(span);
                span.Text.Accept(this);
                PopNode();
            }

            public void Visit(MdCodeSpan span) => CreateLeafNode(span);

            public void Visit(MdCompositeSpan compositeSpan)
            {
                PushNewNode(compositeSpan);
                foreach (var span in compositeSpan)
                {
                    span.Accept(this);
                }
                PopNode();

            }

            public void Visit(MdLinkSpan span) => CreateLeafNode(span);

            public void Visit(MdImageSpan span) => CreateLeafNode(span);

            public void Visit(MdSingleLineSpan singleLineSpan)
            {
                PushNewNode(singleLineSpan);
                singleLineSpan.Content.Accept(this);
                PopNode();
            }

            public void Visit(MdRawMarkdownSpan span) => CreateLeafNode(span);

            public void Visit(MdAdmonition admonition) => VisitContainer(admonition);


            private void CreateLeafNode(object item)
            {
                // push new node and immediately pop it from the stack as leaf nodes do not have children
                PushNewNode(item);
                PopNode();
            }

            private void PushNewNode(object item)
            {
                var name = item.GetType().Name;
                var node = new AsciiTreeNode(name);

                if (RootNode == null)
                {
                    RootNode = node;
                    m_Nodes.Push(RootNode);
                }
                else
                {
                    CurrentNode.Children.Add(node);
                    m_Nodes.Push(node);
                }
            }

            private void PopNode() => m_Nodes.Pop();

            public void VisitContainer(MdContainerBlockBase block)
            {
                PushNewNode(block);

                foreach (var item in block)
                {
                    item.Accept(this);
                }

                PopNode();
            }

            private void VisitList(MdList list)
            {
                PushNewNode(list);

                foreach (var listItem in list)
                {
                    listItem.Accept(this);
                }

                PopNode();
            }

            private void VisitTableRow(MdTableRow row)
            {
                PushNewNode(row);

                foreach (var cell in row)
                {
                    cell.Accept(this);
                }

                PopNode();
            }

        }

        /// <summary>
        /// Converts the specified document to a ascci-art syntax tree.
        /// </summary>
        /// <returns>Returns a ASCII tree visualizing the structure of the node and all its child nodes.</returns>
        public static string GetSyntaxTree(MdDocument document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));

            // convert the block into a graph
            var visitor = new GraphBuildingVisitor();
            document.Root.Accept(visitor);

            var rootNode = new AsciiTreeNode(document.GetType().Name);
            rootNode.Children.Add(visitor.RootNode);

            // generate ascii tree
            var treeWriter = new AsciiTreeWriter();
            treeWriter.WriteNode(rootNode);

            // return ascii tree
            return treeWriter.ToString();
        }


        /// <summary>
        /// Converts the specified block to a ascci-art syntax tree.
        /// </summary>
        /// <returns>Returns a ASCII tree visualizing the structure of the node and all its child nodes.</returns>
        public static string GetSyntaxTree(MdBlock block)
        {
            if (block == null)
                new ArgumentNullException(nameof(block));

            // convert the block into a graph
            var visitor = new GraphBuildingVisitor();
            block.Accept(visitor);

            // generate ascii tree
            var treeWriter = new AsciiTreeWriter();
            treeWriter.WriteNode(visitor.RootNode);

            // return ascii tree
            return treeWriter.ToString();
        }
    }
}
