using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grynwald.MarkdownGenerator.Utilities
{   
    class LineFormatter 
    {
        public static IEnumerable<string> GetLines(string input, int maxLineLength)
        {
            var segments = GetStringSegments(input).ToArray();

            var stringBuilder = new StringBuilder();

            for(int i = 0; i < segments.Length; i++)
            {
                var islast = i == segments.Length - 1;
                                
                if(islast)
                {
                    var (value, isWhiteSpace) = segments[i];

                    if(isWhiteSpace)
                    {
                        if (stringBuilder.Length > 0)
                            stringBuilder.Append(value);
                    }
                    else
                    {
                        if (stringBuilder.Length + value.Length <= maxLineLength)
                        {
                            stringBuilder.Append(value);
                        }
                        else
                        {
                            if(stringBuilder.Length > 0)
                            {
                                yield return stringBuilder.ToString();
                            }

                            stringBuilder = new StringBuilder();
                            stringBuilder.Append(value);
                        }

                    }
                }
                else
                {
                    var (currentValue, currentIsWhiteSpace) = segments[i];
                    var (nextValue, nextIsWhiteSpace) = segments[i + 1];

                    if(stringBuilder.Length == 0)
                    {
                        stringBuilder.Append(currentValue);
                        continue;
                    }


                    if(currentIsWhiteSpace)
                    {
                        if (stringBuilder.Length + currentValue.Length + nextValue.Length <= maxLineLength)
                        {
                            stringBuilder.Append(currentValue);
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
                        if(stringBuilder.Length + currentValue.Length <= maxLineLength)
                        {
                            stringBuilder.Append(currentValue);
                        }
                        else
                        {
                            yield return stringBuilder.ToString();
                            stringBuilder = new StringBuilder();
                            stringBuilder.Append(currentValue);
                        }
                    }

                }
               
            }


            if (stringBuilder.Length > 0)
                yield return stringBuilder.ToString().TrimEnd();

        }
        
        /// <summary>
        /// Splits the specified string into a sequence of segments.
        /// Each segment is either a whitespace-segment (contains only whitespace characters)
        /// or an non-whitespace segment
        /// </summary>
        internal static IReadOnlyList<(string value, bool isWhiteSpace)> GetStringSegments(string input)
        {
            // empty string => no segements
            if(String.IsNullOrEmpty(input))
                return Array.Empty<(string, bool)>();

            var segments = new List<(string, bool)>();

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
                segments.Add((input.Substring(start, i - start), isWhiteSpace));
            }

            return segments;
        }        
    }
}
