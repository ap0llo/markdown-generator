using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator
{    
    /// <summary>
    /// Represent a row in a table
    /// </summary>
    public sealed class MdTableRow : IEnumerable<MdSpan>
    {
        private readonly List<MdSpan> m_Cells;

        /// <summary>
        /// The row's cell values
        /// </summary>
        public IEnumerable<MdSpan> Cells => m_Cells;

        /// <summary>
        /// Gets the number of coumns in the row
        /// </summary>
        public int ColumnCount => m_Cells.Count;
        
        /// <summary>
        /// Gets the value in the specified column
        /// </summary>
        /// <param name="column">The index of the column which's value to get</param>
        public MdSpan this[int column] => m_Cells[column];

        
        public MdTableRow(IEnumerable<string> cells) : this(cells.Select(str => new MdTextSpan(str)))
        { }

        public MdTableRow(params MdSpan[] cells) : this((IEnumerable<MdSpan>)cells)
        { }

        public MdTableRow(IEnumerable<MdSpan> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            // wrap the cells into MdSingleLineSpan instances so line breaks are removed
            // when writeing the table to the output
            m_Cells = new List<MdSpan>(cells.Select(span => new MdSingleLineSpan(span)));            
        }

        /// <summary>
        /// Adds a column to the row
        /// </summary>
        public void Add(string cell) => Add(new MdTextSpan(cell));

        /// <summary>
        /// Adds a column to the row
        /// </summary>
        public void Add(MdSpan cell) => m_Cells.Add(new MdSingleLineSpan(cell));

        public IEnumerator<MdSpan> GetEnumerator() => m_Cells.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Cells.GetEnumerator();        
    }
}
