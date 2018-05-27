using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grynwald.MarkdownGenerator.Utilities
{
    // TODO: Find a better name
    internal sealed class SimpleTextWriter 
    {        
        private readonly TextWriter m_InnerWriter;
        private bool m_AnyLinesWritten = false;
        private bool m_BlankLineRequested = false;
        private readonly Stack<string> m_Prefixes = new Stack<string>();


        public event EventHandler<EventArgs> LineWritten;

        public event EventHandler<EventArgs> BlankLineRequested;


        public string CurrentPrefix => m_Prefixes.Count > 0 ? m_Prefixes.Peek() : null;

        public SimpleTextWriter(TextWriter innerWriter)
        {
            m_InnerWriter = innerWriter ?? throw new ArgumentNullException(nameof(innerWriter));            
        }
        

        public void WriteLine(string value)
        {
            // write a blank line if previously requested
            if(m_BlankLineRequested)
            {
                // only write blank line if document is not empty
                if(m_AnyLinesWritten)
                    m_InnerWriter.WriteLine();

                m_BlankLineRequested = false;
            }

            // write prefix (if set)
            if(m_Prefixes.Count > 0)
                m_InnerWriter.Write(m_Prefixes.Peek());

            // write value
            m_InnerWriter.WriteLine(value);
            LineWritten?.Invoke(this, EventArgs.Empty);
            m_AnyLinesWritten = true;
        }
        
        public void RequestBlankLine()
        {
            m_BlankLineRequested = true;
            BlankLineRequested?.Invoke(this, EventArgs.Empty);
        }

        public void CancelRequestBlankLine()
        {
            m_BlankLineRequested = false;
        }

        public void PushPrefix(string prefix) => m_Prefixes.Push(prefix ?? throw new ArgumentNullException(nameof(prefix)));

        public void PopPrefix() => m_Prefixes.Pop();
    }
}
