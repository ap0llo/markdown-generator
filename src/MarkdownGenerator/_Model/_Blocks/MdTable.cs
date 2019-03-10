using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a table in a Markdown document.
    /// </summary>
    /// <remarks>
    /// CommonMark does not specify a table format, but tables are common in GitHub Flavored Markdown.
    /// Tables can be serialized either as GitHub Flavored Markdown tables (default) or inline HTML-tables.
    /// For details see <see cref="MdSerializationOptions.TableStyle"/>
    /// </remarks>
    public sealed class MdTable : MdLeafBlock, IEnumerable<MdTableRow>
    {
        private readonly List<MdTableRow> m_Rows;


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


        /// <summary>
        /// Initializes a new instance of <see cref="MdTable"/> with the specified content
        /// </summary>
        /// <param name="headerRow">The table's header row (not optional)</param>
        /// <param name="rows">The table's content rows</param>
        public MdTable(MdTableRow headerRow, params MdTableRow[] rows)
            : this(headerRow, (IEnumerable<MdTableRow>)rows)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTable"/> with the specified content
        /// </summary>
        /// <param name="headerRow">The table's header row (not optional)</param>
        /// <param name="rows">The table's content rows</param>
        public MdTable(MdTableRow headerRow, IEnumerable<MdTableRow> rows)
        {
            HeaderRow = headerRow ?? throw new ArgumentNullException(nameof(headerRow));
            m_Rows = new List<MdTableRow>(rows ?? throw new ArgumentNullException(nameof(rows)));
        }


        public IEnumerator<MdTableRow> GetEnumerator() => m_Rows.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Rows.GetEnumerator();

        /// <summary>
        /// Adds the specified row to the table
        /// </summary>
        /// <param name="row">The row to add to the table</param>
        public void Add(MdTableRow row)
        {
            m_Rows.Add(row ?? throw new ArgumentNullException(nameof(row)));
        }
        
        public override bool DeepEquals(MdBlock other) => DeepEquals(other as MdTable);


        private bool DeepEquals(MdTable other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (RowCount != other.RowCount)
                return false;

            if (!HeaderRow.DeepEquals(other.HeaderRow))
                return false;

            for(int i = 0; i< RowCount; i++)
            {
                if (!m_Rows[i].DeepEquals(other.m_Rows[i]))
                    return false;
            }

            return true;
        }
    }
}
