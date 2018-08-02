using System;
using System.Linq;
using Grynwald.MarkdownGenerator.Utilities;
using Grynwald.Utilities.Collections;
using Xunit;
using Xunit.Sdk;


namespace Grynwald.MarkdownGenerator.Test.Utilities
{
    public class LineFormatterTest
    {
        [Theory]
        [InlineData(5, "abcde", new [] {  "abcde" })]
        [InlineData(5, "abcde fgh", new [] {  "abcde", "fgh" })]
        [InlineData(5, "ab de fgh", new [] {  "ab de", "fgh" })]
        [InlineData(5, "abcdefgh", new [] {  "abcdefgh" })]
        [InlineData(5, "abcdefgh ijk", new [] {  "abcdefgh", "ijk" })]        
        [InlineData(5, "abc defgh ijk", new [] {  "abc", "defgh", "ijk" })]        
        [InlineData(5, "abc def  ijk", new [] {  "abc", "def",  "ijk" })]        
        public void Line_is_split_as_expected(int lineLength, string input, string[] expectedResult)
        {
            var actualResult = LineFormatter.GetLines(input, lineLength);

            if(!expectedResult.SequenceEqual(actualResult))
            {
                throw new XunitException("SequenceEqual failure:\r\n" +
                    $"Expected: {expectedResult.Select(x=> $"\"{x}\"").JoinToString(", ")}\r\n" +
                    $"Actual:   {actualResult.Select(x => $"\"{x}\"").JoinToString(", ")}");
            }            
        }
        
        [Theory]
        [InlineData("abcde", new[] { "abcde" })]
        [InlineData("abcde fgh", new[] { "abcde", " ", "fgh" })]
        [InlineData("ab  de fgh", new[] { "ab", "  ", "de", " ", "fgh" })]
        [InlineData("  abc", new[] {"  ", "abc" })]        
        [InlineData("abc  ", new[] {"abc", "  " })]        
        [InlineData("  abc  ", new[] {"  ", "abc", "  " })]        
        [InlineData("", new string[0])]        
        public void GetStringSegments_returns_the_expected_segments(string input, string[] expectedSegments)
        {
            var actualSegments = LineFormatter.GetStringSegments(input).Select(x => x.Value).ToArray();
            if (!expectedSegments.SequenceEqual(actualSegments))
            {
                throw new XunitException("SequenceEqual failure:\r\n" +
                    $"Expected: {expectedSegments.Select(x => $"\"{x}\"").JoinToString(", ")}\r\n" +
                    $"Actual:   {actualSegments.Select(x => $"\"{x}\"").JoinToString(", ")}");
            }
        }

    }
}
