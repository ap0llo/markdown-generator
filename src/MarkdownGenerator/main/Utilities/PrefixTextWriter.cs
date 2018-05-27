using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grynwald.MarkdownGenerator.Utilities
{
    internal sealed class PrefixTextWriter 
    {        
        private readonly TextWriter m_InnerWriter;
        private bool m_AnyLinesWritten = false;
        private bool m_BlankLineRequested = false;
        private readonly LinkedList<IPrefixHandler> m_PrefixHandlers = new LinkedList<IPrefixHandler>();


        public event EventHandler<EventArgs> LineWritten;

        public event EventHandler<EventArgs> BlankLineRequested;

        
        public PrefixTextWriter(TextWriter innerWriter)
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
                {                    
                    m_InnerWriter.WriteLine(GetBlankLinePrefix());
                }
                m_BlankLineRequested = false;
            }

            // write prefix
            m_InnerWriter.Write(GetLinePrefix());

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

        public void PushPrefixHandler(IPrefixHandler prefixHandler) => m_PrefixHandlers.AddLast(prefixHandler ?? throw new ArgumentNullException(nameof(prefixHandler)));

        public void PopPrefixHandler() => m_PrefixHandlers.RemoveLast();


        private string GetBlankLinePrefix()
        {
            var prefixBuilder = new StringBuilder();
            foreach (var handler in m_PrefixHandlers)
            {
                prefixBuilder.Append(handler.GetBlankLinePrefix());
            }
            var prefix= prefixBuilder.ToString();

            if (String.IsNullOrWhiteSpace(prefix))
                return "";
            else
                return prefix.TrimEnd();
        }

        private string GetLinePrefix()
        {
            var prefixBuilder = new StringBuilder();
            foreach (var handler in m_PrefixHandlers)
            {
                prefixBuilder.Append(handler.GetLinePrefix());
            }
            return prefixBuilder.ToString();
        }
    }
}