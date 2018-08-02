namespace Grynwald.MarkdownGenerator.Utilities
{
    interface IPrefixHandler
    {
        string PreviewLinePrefix();

        string GetLinePrefix();

        string GetBlankLinePrefix();
    }
}
