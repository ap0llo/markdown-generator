using System.Text;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal sealed class ResettableStringBuilder
    {
        private StringBuilder m_StringBuilder = new StringBuilder();


        public int Length => m_StringBuilder.Length;

        public bool IsEmpty => Length == 0;


        public void Reset() => m_StringBuilder = new StringBuilder();

        public string GetAndReset()
        {
            var value = m_StringBuilder.ToString();
            Reset();
            return value;
        }

        public void Append(string value) => m_StringBuilder.Append(value);

        public override string ToString() => m_StringBuilder.ToString();
    }    
}
