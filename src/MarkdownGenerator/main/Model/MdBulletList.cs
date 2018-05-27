using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a bullet list
    /// </summary>
    public sealed class MdBulletList : MdList
    {
        internal override MdListKind Kind => MdListKind.Bullet;

        public MdBulletList(params MdListItem[] content) : base(content)
        { }

        public MdBulletList(IEnumerable<MdListItem> content) : base(content)
        { }
    }
}
