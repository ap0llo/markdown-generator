namespace Grynwald.MarkdownGenerator.Internal
{
    internal interface ISpanVisitor
    {
        void Visit(MdEmptySpan mdEmptySpan);

        void Visit(MdTextSpan mdTextSpan);

        void Visit(MdEmphasisSpan mdEmphasisSpan);

        void Visit(MdStrongEmphasisSpan mdStrongEmphasisSpan);

        void Visit(MdCodeSpan mdCodeSpan);

        void Visit(MdCompositeSpan mdCompositeSpan);
        
        void Visit(MdLinkSpan mdLinkSpan);

        void Visit(MdImageSpan mdImageSpan);

        void Visit(MdSingleLineSpan mdSingleLineSpan);

        void Visit(MdRawMarkdownSpan mdRawMarkdownSpan);        
    }
}
