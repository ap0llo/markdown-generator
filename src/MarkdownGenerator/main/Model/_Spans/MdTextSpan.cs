using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Grynwald.MarkdownGenerator.Utilities;

namespace Grynwald.MarkdownGenerator.Model
{
    public abstract class MdTextSpan
    {
        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdTextSpan()
        {
        }

        public override string ToString()
        {
            using (var stringWriter = new StringWriter())
            {
                var documentSerializer = new TextSpanSerializer(stringWriter);
                documentSerializer.Serialize(this);
                return stringWriter.ToString();
            }
        }
    }
}
