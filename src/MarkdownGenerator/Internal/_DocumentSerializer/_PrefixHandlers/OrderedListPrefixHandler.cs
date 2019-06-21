using System;

namespace Grynwald.MarkdownGenerator.Internal
{
    /// <summary>
    /// Prefix handler for ordered lists
    /// </summary>
    internal sealed class OrderedListPrefixHandler : ListPrefixHandler
    {                
        private readonly MdOrderedListStyle m_OrderedListStyle; // determines the list marker for ordered lists (either '.' or ')' )        
        private int m_ListItemNumber = 0;                       // the number of the list item (for ordered lists)


        public OrderedListPrefixHandler(MdOrderedListStyle orderedListStyle)
        {      
            m_OrderedListStyle = orderedListStyle;
        }


        public override void BeginListItem()
        {
            // increment list item number
            m_ListItemNumber += 1;

            base.BeginListItem();
        }


        protected override string GetListMarker()
        {
            switch (m_OrderedListStyle)
            {
                case MdOrderedListStyle.Dot:
                    return $"{m_ListItemNumber}. ";
                    
                case MdOrderedListStyle.Parenthesis:
                    return $"{m_ListItemNumber}) ";

                default:
                    throw new ArgumentException($"Unsupported ordered list style: {m_OrderedListStyle}");
            }
        }
       
    }
}
