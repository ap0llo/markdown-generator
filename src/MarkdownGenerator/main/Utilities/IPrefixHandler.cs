namespace Grynwald.MarkdownGenerator.Utilities
{
    interface IPrefixHandler
    {
        string GetLinePrefix();

        string GetBlankLinePrefix();
    }
}
