namespace Grynwald.MarkdownGenerator.Internal
{
    internal interface ISpanVisitor
    {
        void Visit(MdEmptySpan emptySpan);

        void Visit(MdTextSpan textSpan);

        void Visit(MdEmphasisSpan emphasisSpan);

        void Visit(MdStrongEmphasisSpan strongEmphasisSpan);

        void Visit(MdCodeSpan codeSpan);

        void Visit(MdCompositeSpan compositeSpan);
        
        void Visit(MdLinkSpan linkSpan);

        void Visit(MdImageSpan imageSpan);

        void Visit(MdSingleLineSpan singleLineSpan);

        void Visit(MdRawMarkdownSpan rawMarkdownSpan);        
    }
}
