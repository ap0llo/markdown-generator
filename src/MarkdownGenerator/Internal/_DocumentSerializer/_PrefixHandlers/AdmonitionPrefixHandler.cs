namespace Grynwald.MarkdownGenerator.Internal
{
    internal class AdmonitionPrefixHandler : IPrefixHandler
    {
        public int PrefixLength => 4;

        public string GetBlankLinePrefix() => "    ";

        public string GetLinePrefix() => "    ";
    }
}
