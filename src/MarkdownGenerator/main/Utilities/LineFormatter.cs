using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grynwald.MarkdownGenerator.Utilities
{   
    class LineFormatter 
    {
        internal struct StringSegment
        {
            public string Value { get; set; }

            public int Length => Value.Length;

            public bool IsWhiteSpace { get; set; }
        }
        

        public static IEnumerable<string> GetLines(string input, int maxLineLength)
        {
            var segments = GetStringSegments(input).ToArray();

            var stringBuilder = new StringBuilder();

            for(int i = 0; i < segments.Length; i++)
            {
                var islast = i == segments.Length - 1;
                                
                if(islast)
                {
                    var currentSegment = segments[i];

                    if(currentSegment.IsWhiteSpace)
                    {
                        if (stringBuilder.Length > 0)
                            stringBuilder.Append(currentSegment.Value);
                    }
                    else
                    {
                        if (stringBuilder.Length + currentSegment.Length <= maxLineLength)
                        {
                            stringBuilder.Append(currentSegment.Value);
                        }
                        else
                        {
                            if(stringBuilder.Length > 0)
                            {
                                yield return stringBuilder.ToString();
                            }

                            stringBuilder = new StringBuilder();
                            stringBuilder.Append(currentSegment.Value);
                        }

                    }
                }
                else
                {
                    var currentSegment = segments[i];
                    var nextSegment = segments[i + 1];

                    if(stringBuilder.Length == 0)
                    {
                        stringBuilder.Append(currentSegment.Value);
                        continue;
                    }


                    if(currentSegment.IsWhiteSpace)
                    {
                        if (stringBuilder.Length + currentSegment.Length + nextSegment.Length <= maxLineLength)
                        {
                            stringBuilder.Append(currentSegment.Value);
                            //stringBuilder.Append(nextSegment.Value);
                        }
                        else
                        {
                            yield return stringBuilder.ToString();
                            stringBuilder = new StringBuilder();
                        }
                    }
                    else
                    {
                        // append if it still fits within max length, otherwise being anew
                        if(stringBuilder.Length + currentSegment.Length <= maxLineLength)
                        {
                            stringBuilder.Append(currentSegment.Value);
                        }
                        else
                        {
                            yield return stringBuilder.ToString();
                            stringBuilder = new StringBuilder();
                            stringBuilder.Append(currentSegment.Value);
                        }
                    }

                }
               
            }


            if (stringBuilder.Length > 0)
                yield return stringBuilder.ToString().TrimEnd();

        }
        
        /// <summary>
        /// Spltis the specified string into a sequence of segements.
        /// Each segment is either a whitespace-segment (contains only whitespace characters)
        /// or an non-whitespace segment
        /// </summary>
        internal static IReadOnlyList<StringSegment> GetStringSegments(string input)
        {
            // empty string => no segements
            if(String.IsNullOrEmpty(input))
                return Array.Empty<StringSegment>();

            var segments = new List<StringSegment>();

            var i = 0;
            while (i < input.Length)
            {
                // determine is current char is whitespace or not
                var isWhiteSpace = char.IsWhiteSpace(input[i]);

                // move i forward as long as all chars are whitespace or non-whitespace
                var start = i;
                while (i < input.Length && char.IsWhiteSpace(input[i]) == isWhiteSpace)
                {
                    i++;
                }

                // emit new segment
                segments.Add(new StringSegment()
                {
                    Value = input.Substring(start, i - start),
                    IsWhiteSpace = isWhiteSpace
                });

            }

            return segments;
        }        
    }
}
