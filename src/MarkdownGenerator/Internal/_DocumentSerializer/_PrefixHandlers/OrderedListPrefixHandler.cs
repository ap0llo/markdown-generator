using System;

namespace Grynwald.MarkdownGenerator.Internal
{
    /// <summary>
    /// Prefix handler for ordered lists
    /// </summary>
    internal sealed class OrderedListPrefixHandler : ListPrefixHandler
    {
        private int m_ListItemNumber = 0;       // the number of the list item (for ordered lists)


        public OrderedListPrefixHandler(MdSerializationOptions serializationOptions) : base(serializationOptions)
        { }


        public override void BeginListItem(MdListItemBase listItem)
        {
            // increment list item number
            m_ListItemNumber += 1;

            base.BeginListItem(listItem);
        }


        protected override string GetListMarker()
        {
            switch (m_SerializationOptions.OrderedListStyle)
            {
                case MdOrderedListStyle.Dot:
                    return $"{m_ListItemNumber}. ";

                case MdOrderedListStyle.Parenthesis:
                    return $"{m_ListItemNumber}) ";

                default:
                    throw new ArgumentException($"Unsupported ordered list style: {m_SerializationOptions.OrderedListStyle}");
            }
        }

    }
}
