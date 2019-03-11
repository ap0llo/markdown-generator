namespace Grynwald.MarkdownGenerator.Internal
{
    internal interface IBlockVisitor
    {
        void Visit(MdHeading mdHeading);

        void Visit(MdParagraph mdParagraph);

        void Visit(MdContainerBlock mdContainerBlock);

        void Visit(MdThematicBreak mdThematicBreak);

        void Visit(MdTable mdTable);

        void Visit(MdBulletList mdBulletList);

        void Visit(MdOrderedList mdOrderedList);

        void Visit(MdListItem mdListItem);

        void Visit(MdEmptyBlock mdEmptyBlock);

        void Visit(MdBlockQuote mdBlockQuote);

        void Visit(MdCodeBlock mdCodeBlock);
    }
}
