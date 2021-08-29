using Grynwald.MarkdownGenerator.Extensions;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal partial interface IBlockVisitor
    {
        void Visit(MdAdmonition codeBlock);

        void Visit(MdTaskListItem taskListItem);
    }
}
