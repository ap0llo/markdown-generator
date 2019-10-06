using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Grynwald.MarkdownGenerator.Internal;

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
    public sealed class MdTable : MdLeafBlock, IReadOnlyCollection<MdTableRow>
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
        /// Gets the number of rows in the table.
        /// </summary>
        /// <value>The number of rows in the table.</value>
        /// <remarks>This property is equivalent to <see cref="RowCount"/>.</remarks>
        public int Count => RowCount;

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


        /// <summary>
        /// Returns an enumerator that iterates through the table's rows.
        /// </summary>
        public IEnumerator<MdTableRow> GetEnumerator() => m_Rows.GetEnumerator();

        /// <summary>
        /// Returns an (non-generic) enumerator that iterates through the table's rows.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => m_Rows.GetEnumerator();

        /// <summary>
        /// Adds the specified row to the table
        /// </summary>
        /// <param name="row">The row to add to the table.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="row"/> is <c>null</c>.</exception>
        public void Add(MdTableRow row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            m_Rows.Add(row);
        }

        /// <summary>
        /// Inserts the a row at the specified index.
        /// </summary>
        /// <param name="index">The index (zero-based) to insert the row at.</param>
        /// <param name="row">The row to insert into the table.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="row"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is negative or greater than the number of rows in the table.</exception>
        public void Insert(int index, MdTableRow row)
        {
            if(row == null)
                throw new ArgumentNullException(nameof(row));

            if (index < 0 || index > m_Rows.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            m_Rows.Insert(index, row);
        }

        /// <inheritdoc />
        public override bool DeepEquals(MdBlock other) => DeepEquals(other as MdTable);

        /// <inheritdoc />
        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);


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
