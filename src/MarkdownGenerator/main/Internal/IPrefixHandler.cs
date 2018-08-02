namespace Grynwald.MarkdownGenerator.Internal
{
    internal interface IPrefixHandler
    {
        string PreviewLinePrefix();

        string GetLinePrefix();

        string GetBlankLinePrefix();
    }
}
