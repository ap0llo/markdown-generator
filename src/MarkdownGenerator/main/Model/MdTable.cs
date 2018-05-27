using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a table in a Markdown document.
    /// CommonMark does not specify a table format, but tables are common in GitHub flavoured Markdown
    /// </summary>
    public sealed class MdTable : MdLeafBlock, IEnumerable<MdTableRow>
    {        
        readonly LinkedList<MdTableRow> m_Rows;


        /// <summary>
        /// The number of columns in tha table
        /// </summary>
        public int ColumnCount => Math.Max(HeaderRow.ColumnCount, m_Rows.Max(x => x.ColumnCount));
        
        /// <summary>
        /// The table's header row
        /// </summary>
        public MdTableRow HeaderRow { get; }


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

        /// <summary>
        /// Gets the width of the specified column. 
        /// The width of a column is the width of the widest cell in any row of the column.
        /// </summary>
        /// <param name="column">The index of the column</param>
        public int GetColumnWidth(int column)
        {
            if (column < 0)
                throw new ArgumentOutOfRangeException(nameof(column));

            if (column >= ColumnCount)
                throw new ArgumentOutOfRangeException(nameof(column), $"The table has only {ColumnCount} columns");

            return Math.Max(HeaderRow.GetColumnWidthOrDefault(column), m_Rows.Max(r => r.GetColumnWidthOrDefault(column)));
        }
    }
}
