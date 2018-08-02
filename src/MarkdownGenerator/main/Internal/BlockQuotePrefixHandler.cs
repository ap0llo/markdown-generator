namespace Grynwald.MarkdownGenerator.Internal
{
    /// <summary>
    /// Prefix handler for block quotes
    /// </summary>
    internal sealed class BlockQuotePrefixHandler : IPrefixHandler
    {
        private bool m_LineWritten = false;


        public int PrefixLength => 2;


        // do no prefix blank lines before the quote, then prefix all lines
        public string GetBlankLinePrefix() => m_LineWritten ? "> " : "";
        
        public string GetLinePrefix()
        {
            m_LineWritten = true;
            return "> ";
        }
    }
}
