namespace Grynwald.MarkdownGenerator.Internal
{
    interface IPrefixHandler
    {
        string PreviewLinePrefix();

        string GetLinePrefix();

        string GetBlankLinePrefix();
    }
}
