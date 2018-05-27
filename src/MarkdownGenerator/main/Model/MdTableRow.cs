using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Model
{
    //TODO: make class sealed
    /// <summary>
    /// Represent a row in a table
    /// </summary>
    public class MdTableRow : IEnumerable<string>
    {
        readonly List<string> m_Cells;

        /// <summary>
        /// The row's cell values
        /// </summary>
        public IEnumerable<string> Cells => m_Cells;

        /// <summary>
        /// Gets the number of coumns in the row
        /// </summary>
        public int ColumnCount => m_Cells.Count;
        
        /// <summary>
        /// Gets the value in the specified column
        /// </summary>
        /// <param name="column">The index of the column which's value to get</param>
        public string this[int column] => m_Cells[column];


        public MdTableRow(params string[] cells) : this((IEnumerable<string>)cells)
        { }

        public MdTableRow(IEnumerable<string> cells)
        {
            m_Cells = new List<string>(cells ?? throw new ArgumentNullException(nameof(cells)));            
        }

        /// <summary>
        /// Adds a column to the row
        /// </summary>
        public void Add(string cell) => m_Cells.Add(cell);

        public IEnumerator<string> GetEnumerator() => m_Cells.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Cells.GetEnumerator();

        /// <summary>
        /// Gets the width of the specified column
        /// </summary>
        /// <returns>Retunrs the width of the specified column or 0 if the column index is greater than the number of columns</returns>
        internal int GetColumnWidthOrDefault(int column)
        {
            return column < m_Cells.Count ? m_Cells[column].Length : 0;
        }
    }
}
