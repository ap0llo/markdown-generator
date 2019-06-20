using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represent a row in a table (see <see cref="MdTable"/>)
    /// </summary>
    public sealed class MdTableRow : IReadOnlyList<MdSpan>
    {
        private readonly List<MdSpan> m_Cells;


        /// <summary>
        /// Gets the row's cells
        /// </summary>
        public IEnumerable<MdSpan> Cells => m_Cells;

        /// <summary>
        /// Gets the number of columns in the row
        /// </summary>
        public int ColumnCount => m_Cells.Count;

        /// <summary>
        /// Gets the value in the specified column
        /// </summary>
        /// <param name="column">The index of the column which's value to get</param>
        public MdSpan this[int column] => m_Cells[column];

        /// <summary>
        /// Gets the number of columns in the row.
        /// </summary>
        /// <value>The number of columns in the row.</value>
        /// <remarks>This property is equivalent to <see cref="ColumnCount"/>.</remarks>
        public int Count => ColumnCount;

        /// <summary>
        /// Initializes a new instance of <see cref="MdTableRow"/> with the specified cells/columns.
        /// </summary>
        /// <param name="cells">
        /// The rows's cells/columns.
        /// The string value will be wrapped into instances of <see cref="MdTextSpan"/> .
        /// </param>
        public MdTableRow(IEnumerable<string> cells) : this(cells.Select(str => new MdTextSpan(str)))
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTableRow"/> with the specified cells/columns.
        /// </summary>
        /// <param name="cells">The row's cells/columns</param>
        public MdTableRow(params MdSpan[] cells) : this((IEnumerable<MdSpan>)cells)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTableRow"/> with the specified cell.
        /// </summary>
        /// <param name="cell">The row's cell</param>
        public MdTableRow(MdCompositeSpan cell) : this((MdSpan)cell)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="MdTableRow"/> with the specified cells/columns.
        /// </summary>
        /// <param name="cells">The row's cells/columns</param>
        public MdTableRow(IEnumerable<MdSpan> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            // wrap the cells into MdSingleLineSpan instances so line breaks are removed
            // when writing the table to the output
            m_Cells = new List<MdSpan>(cells.Select(span => ToSingleLineSpan(span)));
        }


        /// <summary>
        /// Adds a column to the row
        /// </summary>
        /// <param name="cell">
        /// The cell to add to the row.
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/>
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="cell"/> is <c>null</c>.</exception>
        public void Add(string cell) => Add(new MdTextSpan(cell ?? throw new ArgumentNullException(nameof(cell))));

        /// <summary>
        /// Adds a column to the row
        /// </summary>
        /// <param name="cell">The cell to add to the row.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="cell"/> is <c>null</c>.</exception>
        public void Add(MdSpan cell)
        {
            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            m_Cells.Add(ToSingleLineSpan(cell));
        }

        /// <summary>
        /// Inserts a table cell at the specified index.
        /// </summary>
        /// <param name="index">The index (zero-based) index to insert the cell at.</param>
        /// <param name="cell">The table cell to insert.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="cell"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is negative of greater than the number of columns in the row.</exception>
        public void Insert(int index, MdSpan cell)
        {
            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            if (index < 0 || index > m_Cells.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            m_Cells.Insert(index, cell);
        }

        /// <inheritdoc />
        public IEnumerator<MdSpan> GetEnumerator() => m_Cells.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => m_Cells.GetEnumerator();

       
        public bool DeepEquals(MdTableRow other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (ColumnCount != other.ColumnCount)
                return false;

            for(int i = 0; i < ColumnCount; i++)
            {
                if (!m_Cells[i].DeepEquals(other.m_Cells[i]))
                    return false;
            }

            return true;
        }


        private MdSpan ToSingleLineSpan(MdSpan span) => span is MdSingleLineSpan ? span : new MdSingleLineSpan(span);
    }
}
