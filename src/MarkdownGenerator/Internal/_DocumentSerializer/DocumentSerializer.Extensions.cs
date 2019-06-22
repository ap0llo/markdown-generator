using System;
using System.Linq;
using Grynwald.MarkdownGenerator.Extensions;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal partial class DocumentSerializer
    {
        public void Visit(MdAdmonition admonition)
        {
            m_Writer.RequestBlankLine();

            var title = admonition.Title.ToString();

            if (String.IsNullOrEmpty(title))
            {
                m_Writer.WriteLine($"!!! {admonition.Type.ToLower()}");
            }
            else
            {
                m_Writer.WriteLine($"!!! {admonition.Type.ToLower()} \"{title}\"");
            }

            m_Writer.PushPrefixHandler(new AdmonitionPrefixHandler());

            if(admonition.Any())
                m_Writer.SuppressNextBlankLine();

            foreach (var block in admonition)
            {
                block.Accept(this);
            }

            m_Writer.PopPrefixHandler();
            m_Writer.RequestBlankLine();
        }
    }
}
