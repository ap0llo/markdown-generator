using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Combines the sequence of spans to a single span.
        /// </summary>
        /// <param name="spans">The sequence of spans to combine</param>
        /// <returns>
        /// Returns a new span containing all the specified spans.
        /// <list type="bullet">
        /// <item>
        /// <description>If <paramref name="spans"/> is empty, an instance of <see cref="MdEmptySpan"/> will be returned</description>
        /// </item>
        /// <item>
        /// <description>If <paramref name="spans"/> contains a single item, this single span will be returned</description>
        /// </item>
        /// <item>
        /// <description>Otherwise a instance of <see cref="MdCompositeSpan"/> is returned that wraps all the specified spans.</description>
        /// </item>
        /// </list>
        /// </returns>
        public static MdSpan Join(this IEnumerable<MdSpan> spans) => Join(spans, null);

        /// <summary>
        /// Combines the sequence of spans to a single span and adds a separator between them.
        /// </summary>
        /// <param name="spans">The sequence of spans to combine</param>
        /// <param name="separator">The separator to insert between spans. The string value will be wrapped in an instance of <see cref="MdTextSpan"/></param>
        /// <returns>
        /// Returns a new span containing all the specified spans:
        /// <list type="bullet">
        /// <item>
        /// <description>If <paramref name="spans"/> is empty, an instance of <see cref="MdEmptySpan"/> will be returned</description>
        /// </item>
        /// <item>
        /// <description>If <paramref name="spans"/> contains a single item, this single span will be returned</description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise a instance of <see cref="MdCompositeSpan"/> is returned that wraps all the specified spans.
        /// Between two elements of the input sequence, the specified separator is inserted
        /// </description>
        /// </item>
        /// </list>
        /// </returns>
        public static MdSpan Join(this IEnumerable<MdSpan> spans, string? separator) =>
            Join(spans, separator == null ? null : new MdTextSpan(separator));

        /// <summary>
        /// Combines the sequence of spans to a single span and adds a separator between them.
        /// </summary>
        /// <param name="spans">The sequence of spans to combine</param>
        /// <param name="separator">The separator to insert between spans.</param>
        /// <returns>
        /// Returns a new span containing all the specified spans:
        /// <list type="bullet">
        /// <item>
        /// <description>If <paramref name="spans"/> is empty, an instance of <see cref="MdEmptySpan"/> will be returned</description>
        /// </item>
        /// <item>
        /// <description>If <paramref name="spans"/> contains a single item, this single span will be returned</description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise a instance of <see cref="MdCompositeSpan"/> is returned that wraps all the specified spans.
        /// Between two elements of the input sequence, the specified separator is inserted
        /// </description>
        /// </item>
        /// </list>
        /// </returns>
        public static MdSpan Join(this IEnumerable<MdSpan> spans, MdSpan? separator)
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
            // multiple span but no separator => create composite span with all the specified spans
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
