using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator.Model
{
    public class MdTableRow : IEnumerable<string>
    {
        private readonly List<string> m_Cells;

        public IEnumerable<string> Cells => m_Cells;

        public int ColumnCount => m_Cells.Count;
        
        public string this[int column] => m_Cells[column];


        public MdTableRow(params string[] cells) : this((IEnumerable<string>)cells)
        {            
        }

        public MdTableRow(IEnumerable<string> cells)
        {
            m_Cells = new List<string>(cells ?? throw new ArgumentNullException(nameof(cells)));            
        }

        public void Add(string cell) => m_Cells.Add(cell);

        public IEnumerator<string> GetEnumerator() => m_Cells.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Cells.GetEnumerator();

        internal int GetColumnWidth(int column)
        {
            return column < m_Cells.Count ? m_Cells[column].Length : 0;
        }
    }
}
