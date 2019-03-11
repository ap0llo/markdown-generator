//
// The source code in this file is based on work by Andrew Lock, Licensed under the MIT license.
// The oginal version of the file can be found at
// https://github.com/andrewlock/blog-examples/blob/bf9da19db2867cbf371f74299148f17e1f82ad09/AsciiTreeDiagram/AsciiTreeDiagram/Program.cs
//
// For documentation on how the Ascii Tree is generated, see
// https://andrewlock.net/creating-an-ascii-art-tree-in-csharp/
//

using System.IO;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal class AsciiTreeWriter
    {
        private const string s_Cross = " ├─";
        private const string s_Corner = " └─";
        private const string s_Vertical = " │ ";
        private const string s_Space = "   ";

        private readonly StringWriter m_Writer = new StringWriter();


        public void WriteNode(AsciiTreeNode topLevelNode)
        {
            PrintNode(topLevelNode, indent: "");
        }

        public override string ToString() => m_Writer.ToString();


        private void PrintNode(AsciiTreeNode node, string indent)
        {
            m_Writer.WriteLine(node.Name);

            // Loop through the children recursively, passing in the
            // indent, and the isLast parameter
            var numberOfChildren = node.Children.Count;
            for (var i = 0; i < numberOfChildren; i++)
            {
                var child = node.Children[i];
                var isLast = (i == (numberOfChildren - 1));
                PrintChildNode(child, indent, isLast);
            }
        }

        private void PrintChildNode(AsciiTreeNode node, string indent, bool isLast)
        {
            // Print the provided pipes/spaces indent
            m_Writer.Write(indent);

            // Depending if this node is a last child, print the
            // corner or cross, and calculate the indent that will
            // be passed to its children
            if (isLast)
            {
                m_Writer.Write(s_Corner);
                indent += s_Space;
            }
            else
            {
                m_Writer.Write(s_Cross);
                indent += s_Vertical;
            }

            PrintNode(node, indent);
        }
    }
}
