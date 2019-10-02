using System;

namespace Grynwald.MarkdownGenerator.Internal
{
    /// <summary>
    /// Prefix handler for bullet lists
    /// </summary>
    internal sealed class BulletListPrefixHandler : ListPrefixHandler
    {
        public BulletListPrefixHandler(MdSerializationOptions serializationOptions) : base(serializationOptions)
        { }


        protected override string GetListMarker()
        {
            switch (m_SerializationOptions.BulletListStyle)
            {
                case MdBulletListStyle.Dash:
                    return "- ";

                case MdBulletListStyle.Plus:
                    return "+ ";

                case MdBulletListStyle.Asterisk:
                    return "* ";

                default:
                    throw new ArgumentException($"Unsupported bullet list style: {m_SerializationOptions.BulletListStyle}");
            }
        }
    }
}
