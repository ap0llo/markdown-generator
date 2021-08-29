using System;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal abstract class ListPrefixHandler : IPrefixHandler
    {
        protected readonly MdSerializationOptions m_SerializationOptions;
        protected string? m_ListPrefix;          // the prefix for lines other than the first line
        protected bool m_LineWritten = false;    // indicates if any lines have been written in the current list item
        protected string? m_ListMarker;          // the prefix for list items
        protected MdListItemBase? m_CurrentListItem;


        public ListPrefixHandler(MdSerializationOptions serializationOptions)
        {
            m_SerializationOptions = serializationOptions ?? throw new ArgumentNullException(nameof(serializationOptions));
        }


        public int PrefixLength => m_LineWritten ? m_ListPrefix!.Length : m_ListMarker!.Length;


        public string? GetBlankLinePrefix() => m_ListPrefix;

        public string? GetLinePrefix()
        {
            // prefix the first line in the list item with the list marker,
            // other lines are just indented by the width of the list marker

            if (m_LineWritten)
            {
                return m_ListPrefix;
            }
            else
            {
                m_LineWritten = true;
                var additionalListItemMarker = m_CurrentListItem?.AdditionalListItemMarker ?? "";
                return String.Concat(m_ListMarker, additionalListItemMarker);
            }
        }

        public virtual void BeginListItem(MdListItemBase listItem)
        {
            // reset line written (new list item is initially empty)
            m_LineWritten = false;

            // update list marker
            // marker is a dash, plus or asterisk for bullet lists and the number followed by a period for ordered lists            
            m_ListMarker = GetListMarker();

            m_ListPrefix = new string(' ', Math.Max(m_ListMarker.Length, m_SerializationOptions.MinimumListIndentationWidth));

            m_CurrentListItem = listItem;
        }


        protected abstract string GetListMarker();
    }
}
