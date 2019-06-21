//
// The source code in this file is based on work by Andrew Lock, Licensed under the MIT license.
// The oginal version of the file can be found at
// https://github.com/andrewlock/blog-examples/blob/bf9da19db2867cbf371f74299148f17e1f82ad09/AsciiTreeDiagram/AsciiTreeDiagram/Node.cs
//
// For documentation on how the Ascii Tree is generated, see
// https://andrewlock.net/creating-an-ascii-art-tree-in-csharp/
//

using System;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal class AsciiTreeNode
    {
        public string Name { get; }

        public IList<AsciiTreeNode> Children { get; } = new List<AsciiTreeNode>();


        public AsciiTreeNode(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
