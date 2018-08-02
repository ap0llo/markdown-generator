using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a bullet list.
    /// 
    /// </summary>
    public sealed class MdBulletList : MdList
    {
        internal override MdListKind Kind => MdListKind.Bullet;

        /// <summary>
        /// Initializes a new instance of <see cref="MdBulletList"/> with the specified list items
        /// </summary>
        /// <param name="listItems">The list items to intially add to the list</param>
        public MdBulletList(params MdListItem[] listItems) : base(listItems)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdBulletList"/> with the specified list items
        /// </summary>
        /// <param name="listItems">The list items to intially add to the list</param>
        public MdBulletList(IEnumerable<MdListItem> listItems) : base(listItems)
        { }
    }
}
