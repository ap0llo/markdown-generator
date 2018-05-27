using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a table in a Markdown document (GitHub flavoured Markdown)
    /// </summary>
    public class MdTable : MdLeafBlock, IEnumerable<MdTableRow>
    {        
        private readonly LinkedList<MdTableRow> m_Rows;


        public int ColumnCount => Math.Max(HeaderRow.ColumnCount, m_Rows.Max(x => x.ColumnCount));
        
        public MdTableHeaderRow HeaderRow { get; }


        public MdTable(MdTableHeaderRow headerRow, params MdTableRow[] rows)
            : this(headerRow, (IEnumerable<MdTableRow>)rows)
        {
        }

        public MdTable(MdTableHeaderRow headerRow, IEnumerable<MdTableRow> rows)
        {
            HeaderRow = headerRow ?? throw new ArgumentNullException(nameof(headerRow));
            m_Rows = new LinkedList<MdTableRow>(rows ?? throw new ArgumentNullException(nameof(rows)));
        }


        public IEnumerator<MdTableRow> GetEnumerator() => m_Rows.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Rows.GetEnumerator();

        public int GetColumnWidth(int column)
        {
            if (column >= ColumnCount)
                throw new ArgumentException(nameof(column));

            return Math.Max(HeaderRow.GetColumnWidth(column), m_Rows.Max(r => r.GetColumnWidth(column)));
        }
    }
}
