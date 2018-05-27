using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represent the header row in a table
    /// </summary>
    public sealed class MdTableHeaderRow : MdTableRow
    {
        public MdTableHeaderRow(IEnumerable<string> cells) : base(cells)
        { }

        public MdTableHeaderRow(params string[] cells) : base(cells)
        { }
    }
}
