using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    public static class EnumerableExtensions
    {
        public static MdSpan Join(this IEnumerable<MdSpan> spans) => Join(spans, (string)null);

        public static MdSpan Join(this IEnumerable<MdSpan> spans, string separator) => 
            Join(spans, separator == null ? null : new MdTextSpan(separator));

        public static MdSpan Join(this IEnumerable<MdSpan> spans, MdSpan separator)
        {
            // no spans to join => return empty span
            if (!spans.Any())
            {
                return MdEmptySpan.Instance;
            }
            // a single span to join => just return the single span
            else if (!spans.Skip(1).Any())
            {
                return spans.Single();
            }
            // multiple span but no separator => create composite span will all the specified spans
            else if(separator == null)
            {
                return new MdCompositeSpan(spans);
            }
            // multiple spans and separator specified 
            // => create composite span and add separator between individual spans
            else
            {
                var composite = new MdCompositeSpan();
                
                foreach(var span in spans)
                {
                    if(composite.Spans.Count > 0)
                    {
                        composite.Add(separator.DeepCopy());
                    }
                    composite.Add(span);
                }

                return composite;
            }            
        }
              
    }
}
