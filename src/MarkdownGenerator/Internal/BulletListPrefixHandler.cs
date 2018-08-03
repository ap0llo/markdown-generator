using System;

namespace Grynwald.MarkdownGenerator.Internal
{
    /// <summary>
    /// Prefix handler for bullet lists
    /// </summary>
    internal sealed class BulletListPrefixHandler : ListPrefixHandler
    {                
        private readonly MdBulletListStyle m_BulletListStyle;   // determines the list marker for bullet lists (either -, + or *)
        

        public BulletListPrefixHandler(MdBulletListStyle bulletListStyle)
        {
            m_BulletListStyle = bulletListStyle;           
        }

        
        protected override string GetListMarker()
        {
            switch (m_BulletListStyle)
            {
                case MdBulletListStyle.Dash:
                    return "- ";

                case MdBulletListStyle.Plus:
                    return "+ ";

                case MdBulletListStyle.Asterisk:
                    return "* ";

                default:
                    throw new ArgumentException($"Unsupported bullet list style: {m_BulletListStyle}");
            }
        }
    }
}
