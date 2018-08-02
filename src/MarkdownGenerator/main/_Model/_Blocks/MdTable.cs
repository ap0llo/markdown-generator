using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a table in a Markdown document.
    /// CommonMark does not specify a table format, but tables are common in GitHub flavoured Markdown
    /// </summary>
    public sealed class MdTable : MdLeafBlock, IEnumerable<MdTableRow>
    {        
        private readonly LinkedList<MdTableRow> m_Rows;

        /// <summary>
        /// Gets the number of columns in the table
        /// </summary>
        public int ColumnCount => Math.Max(HeaderRow.ColumnCount, m_Rows.Max(x => x.ColumnCount));

        /// <summary>
        /// Gets the number of rows in the table
        /// </summary>
        public int RowCount => m_Rows.Count;

        /// <summary>
        /// Gets the table's header row
        /// </summary>
        public MdTableRow HeaderRow { get; }
        
        /// <summary>
        /// Gets the table's rows
        /// </summary>
        /// <remarks>Does not include the header row</remarks>
        public IEnumerable<MdTableRow> Rows => m_Rows;


        public MdTable(MdTableRow headerRow, params MdTableRow[] rows)
            : this(headerRow, (IEnumerable<MdTableRow>)rows)
        {
        }

        public MdTable(MdTableRow headerRow, IEnumerable<MdTableRow> rows)
        {
            HeaderRow = headerRow ?? throw new ArgumentNullException(nameof(headerRow));
            m_Rows = new LinkedList<MdTableRow>(rows ?? throw new ArgumentNullException(nameof(rows)));
        }


        public IEnumerator<MdTableRow> GetEnumerator() => m_Rows.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Rows.GetEnumerator();
        
        public void Add(MdTableRow row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            m_Rows.AddLast(row);
        }
    }
}
