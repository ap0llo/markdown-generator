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
        
        internal static IEnumerable<StringSegment> GetStringSegments(string input)
        {
            if(String.IsNullOrEmpty(input))
            {
                yield break;                
            }

            int i = 0;
            while (i < input.Length)
            {
                if (char.IsWhiteSpace(input[i]))
                {
                    var start = i;
                    while (i < input.Length && char.IsWhiteSpace(input[i]))
                    {
                        i++;
                    }
                    yield return new StringSegment()
                    {
                        Value = input.Substring(start, i - start),
                        IsWhiteSpace = true
                    };
                }
                else
                {
                    var start = i;
                    while (i < input.Length && !char.IsWhiteSpace(input[i]))
                    {
                        i++;
                    }
                    yield return new StringSegment()
                    {
                        Value = input.Substring(start, i - start),
                        IsWhiteSpace = false
                    };

                }

            }            

        }        
    }
}
