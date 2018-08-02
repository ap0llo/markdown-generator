using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a bullet list.
    /// For specification see https://spec.commonmark.org/0.28/#list-items
    /// </summary>
    public sealed class MdBulletList : MdList
    {
        internal override MdListKind Kind => MdListKind.Bullet;

        /// <summary>
        /// Initializes a new instance of <see cref="MdBulletList"/> with the specified list items
        /// </summary>
        /// <param name="content">The list items to intially add to the list</param>
        public MdBulletList(params MdListItem[] content) : base(content)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBulletList"/> with the specified list items
        /// </summary>
        /// <param name="content">The list items to intially add to the list</param>
        public MdBulletList(IEnumerable<MdListItem> content) : base(content)
        { }
    }
}
