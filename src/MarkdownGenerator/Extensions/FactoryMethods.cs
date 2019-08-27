using System;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Extensions
{
    [Obsolete("FactoryMethods is obsolete. Use the constructors of the markdown data types directly instead.")]
    public static class FactoryMethods
    {
        public static MdAdmonition Admonition(string type) => new MdAdmonition(type);

        public static MdAdmonition Admonition(string type, MdSpan title) => new MdAdmonition(type, title);

        public static MdAdmonition Admonition(string type, MdContainerBlockBase content) => new MdAdmonition(type, content);

        public static MdAdmonition Admonition(string type, MdSpan title, MdContainerBlockBase content) => new MdAdmonition(type, title, content);

        public static MdAdmonition Admonition(string type, MdList content) => new MdAdmonition(type, content);

        public static MdAdmonition Admonition(string type, MdSpan title, MdList content) => new MdAdmonition(type, title, content);

        public static MdAdmonition Admonition(string type, params MdBlock[] content) => new MdAdmonition(type, content);

        public static MdAdmonition Admonition(string type, MdSpan title, params MdBlock[] content) => new MdAdmonition(type, title, content);

        public static MdAdmonition Admonition(string type, IEnumerable<MdBlock> content) => new MdAdmonition(type, content);

        public static MdAdmonition Admonition(string type, MdSpan title, IEnumerable<MdBlock> content) => new MdAdmonition(type, title, content);
    }
}
