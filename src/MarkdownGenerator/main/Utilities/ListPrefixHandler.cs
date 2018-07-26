using System;
using Grynwald.MarkdownGenerator.Model;

namespace Grynwald.MarkdownGenerator.Utilities
{
    /// <summary>
    /// Prefix handler for lists
    /// </summary>
    class ListPrefixHandler : IPrefixHandler
    {                
        private readonly MdListKind m_ListKind;                 // indicates whether to write a bullet list of ordered list
        private readonly MdBulletListStyle m_BulletListStyle;   // determines the list marker for bullet lists (either -, + or *)
        private readonly MdOrderedListStyle m_OrderedListStyle; // determines the list marker for ordered lists (either '.' or ')' )

        private bool m_LineWritten = false;                     // indicates if any lines have been written in the current list item
        private string m_ListMarker;                            // the prefix for list items
        private string m_ListPrefix;                            // the prefix for lines other than the first line
        private int m_ListItemNumber = 0;                       // the number of the list item (for ordered lists)


        public ListPrefixHandler(MdListKind listKind, MdBulletListStyle bulletListStyle, MdOrderedListStyle orderedListStyle)
        {
            m_ListKind = listKind;
            m_BulletListStyle = bulletListStyle;
            m_OrderedListStyle = orderedListStyle;
        }

        public string GetBlankLinePrefix() => m_ListPrefix;

        public string GetLinePrefix()
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
                return m_ListMarker;
            }
        }

        public void BeginListItem()
        {
            // reset line written (new list item is initally empty)
            m_LineWritten = false;

            // increment list item number
            m_ListItemNumber += 1;

            // update list marker
            // marker is a dash, plus or asterisk for bullet lists and the number followed by a period for ordered lists            
            if(m_ListKind == MdListKind.Bullet)
            {
                switch (m_BulletListStyle)
                {
                    case MdBulletListStyle.Dash:
                        m_ListMarker = "- ";
                        break;

                    case MdBulletListStyle.Plus:
                        m_ListMarker = "+ ";
                        break;

                    case MdBulletListStyle.Asterisk:
                        m_ListMarker = "* ";
                        break;

                    default:
                        throw new ArgumentException($"Unsupported bullet list style: {m_BulletListStyle}");
                }
            }
            else
            {
                switch (m_OrderedListStyle)
                {
                    case MdOrderedListStyle.Dot:
                        m_ListMarker = $"{m_ListItemNumber}. ";
                        break;

                    case MdOrderedListStyle.Parenthesis:
                        m_ListMarker = $"{m_ListItemNumber}) ";
                        break;

                    default:
                        throw new ArgumentException($"Unsupported ordered list style: {m_BulletListStyle}");
                }

                
            }

            m_ListPrefix = new String(' ', m_ListMarker.Length);
        }
    }
}
