namespace Grynwald.MarkdownGenerator.Internal
{
    internal interface IPrefixHandler
    {
        /// <summary>
        /// Gets the number of characters for this prefix handler's current prefix
        /// </summary>
        int PrefixLength { get; }


        string? GetLinePrefix();

        string? GetBlankLinePrefix();
    }
}
