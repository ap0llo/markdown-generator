using System;
using System.Collections.Generic;
using System.Text;
using Grynwald.MarkdownGenerator.Extensions;

namespace Grynwald.MarkdownGenerator.Internal
{
    class TaskListItemPrefixHandler : IPrefixHandler
    {
        private readonly MdTaskListItem m_ListItem;
        protected bool m_LineWritten = false;    // indicates if any lines have been written in the current list item

        public TaskListItemPrefixHandler(MdTaskListItem listItem)
        {
            m_ListItem = listItem ?? throw new ArgumentNullException(nameof(listItem));
        }

        public int PrefixLength => m_LineWritten ? 4 : 0;

        public string? GetBlankLinePrefix() => "";

        public string? GetLinePrefix()
        {
            // prefix the first line in the list item with the list marker,
            // other lines are just indented by the width of the list marker
            if (m_LineWritten)
            {
                return "";
            }
            else
            {
                m_LineWritten = true;
                return m_ListItem.IsChecked ? "[x] " : "[ ] ";
            }
        }
    }
}
