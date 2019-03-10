using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represent a row in a table (see <see cref="MdTable"/>)
    /// </summary>
    public sealed class MdTableRow : IEnumerable<MdSpan>
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
        /// Initializes a new instance of <see cref="MdTableRow"/> with the specified cells/columns.
        /// </summary>
        /// <param name="cells">The row's cells/columns</param>
        public MdTableRow(IEnumerable<MdSpan> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            // wrap the cells into MdSingleLineSpan instances so line breaks are removed
            // when writing the table to the output
            m_Cells = new List<MdSpan>(cells.Select(span => new MdSingleLineSpan(span)));
        }


        /// <summary>
        /// Adds a column to the row
        /// </summary>
        /// <param name="cell">
        /// The cell to add to the row.
        /// The string value will be wrapped into an instance of <see cref="MdTextSpan"/>
        /// </param>
        public void Add(string cell) => Add(new MdTextSpan(cell));

        /// <summary>
        /// Adds a column to the row
        /// </summary>
        /// <param name="cell">The cell to add to the row.</param>
        public void Add(MdSpan cell) => m_Cells.Add(new MdSingleLineSpan(cell));

        public IEnumerator<MdSpan> GetEnumerator() => m_Cells.GetEnumerator();

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
    }
}
