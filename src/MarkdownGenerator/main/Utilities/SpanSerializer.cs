using System;
using System.IO;
using System.Text.RegularExpressions;
using Grynwald.MarkdownGenerator.Model;

namespace Grynwald.MarkdownGenerator.Utilities
{
    internal class SpanSerializer
    {
        
        public SpanSerializer()
        {
        }


        public string ConvertToString(MdSpan span)
        {
            using (var stringWriter = new StringWriter())
            {                
                WriteTo(span, stringWriter, false);
                return stringWriter.ToString();
            }
        }
        

        private void WriteTo(MdSpan span, TextWriter writer, bool removeLineBreaks)
        {
            writer.Write(span.ToString());
           
        }        

    }
}
