using System;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.MarkdownGenerator.Internal
{
    internal class LineFormatter 
    {
        public static IEnumerable<string> GetLines(string input, int maxLineLength)
        {
            // fast path: if the input is already shorter than the maximum length
            // return it unchanged
            if(input.Length <= maxLineLength)
            {
                yield return input;
                yield break;
            }

            var segments = GetStringSegments(input).ToArray();


            var lineBuilder = new ResettableStringBuilder();
            // iterate over all segments
            for(var i = 0; i < segments.Length; i++)
            {
                var isLastSegment = (i == segments.Length - 1);
                                
                // last segment requires special handling (no look ahead to next segment possible)
                if(isLastSegment)
                {                    
                    var (value, isWhiteSpace) = segments[i];

                    // if last segment is whitespace and the current line is not empty
                    // append the whitespace to retain trailing whitespace)
                    // if the current line is empty, do not append whitespace to avoid introducing blank lines
                    if(isWhiteSpace && !lineBuilder.IsEmpty)
                    {                        
                        lineBuilder.Append(value);
                        yield return lineBuilder.GetAndReset();
                    }
                    else
                    {
                        // append segment to the current line if it fits wihtin max length
                        if (lineBuilder.Length + value.Length <= maxLineLength)
                        {
                            lineBuilder.Append(value);
                        }
                        // emit a new line for the last segment
                        else
                        {
                            // if current line contains a value, return it
                            // then append last segment
                            if (!lineBuilder.IsEmpty)
                            {
                                yield return lineBuilder.GetAndReset();
                            }
                            lineBuilder.Append(value);
                        }
                    }
                }
                else
                {
                    // get current and next segment
                    var (currentValue, currentIsWhiteSpace) = segments[i];
                    var (nextValue, _) = segments[i + 1];

                    // if current line is empty append the current value anyways
                    // (to handle cases where a single segment does not fit into the line)
                    if(lineBuilder.IsEmpty && !currentIsWhiteSpace)
                    {
                        lineBuilder.Append(currentValue);
                        continue;
                    }


                    if(currentIsWhiteSpace)
                    {
                        // for whitespace segments, look for the next segment
                        // if appending the whitespace AND the next segement would 
                        // exceed the maximum line length, start a new line 
                        // and omit the whitespace
                        // otherwise, append the whitespace and the next segment
                        if (lineBuilder.Length + currentValue.Length + nextValue.Length <= maxLineLength)
                        {
                            lineBuilder.Append(currentValue);
                            lineBuilder.Append(nextValue);

                            // skip next segment (already appended)
                            i++;        
                        }
                        else
                        {
                            yield return lineBuilder.GetAndReset();                            
                        }
                    }
                    else
                    {
                        // append if it still fits within max length, otherwise being anew
                        if(lineBuilder.Length + currentValue.Length <= maxLineLength)
                        {
                            lineBuilder.Append(currentValue);
                        }
                        else
                        {
                            yield return lineBuilder.GetAndReset();                            
                            lineBuilder.Append(currentValue);
                        }
                    }

                }
               
            }

            if (!lineBuilder.IsEmpty)
                yield return lineBuilder.ToString();

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
