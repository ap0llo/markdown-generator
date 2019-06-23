﻿namespace Grynwald.MarkdownGenerator.Internal
{
    internal partial interface IBlockVisitor
    {
        void Visit(MdHeading heading);

        void Visit(MdParagraph paragraph);

        void Visit(MdContainerBlock containerBlock);

        void Visit(MdThematicBreak thematicBreak);

        void Visit(MdTable table);

        void Visit(MdBulletList bulletList);

        void Visit(MdOrderedList orderedList);

        void Visit(MdListItem listItem);

        void Visit(MdBlockQuote blockQuote);

        void Visit(MdCodeBlock codeBlock);
    }
}
