using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdownBuilder.Model
{
    public class MdTableHeaderRow : MdTableRow
    {
        public MdTableHeaderRow(IEnumerable<string> cells) : base(cells)
        {
        }

        public MdTableHeaderRow(params string[] cells) : base(cells)
        {
        }
    }
}
