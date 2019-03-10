﻿using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdStrongEmphasisSpanTest
    {
        [Fact]
        public void ToString_returns_the_expected_value()
        {
            var text = "Some text";
            var span = new MdStrongEmphasisSpan(text);

            Assert.Equal($"**{text}**", span.ToString());
        }

        [Theory]
        [MarkdownSpecialCharacterData]
        public void ToString_escapes_special_characters(char charToEscape)
        {
            var text = $"prefix{charToEscape}suffix";
            var span = new MdStrongEmphasisSpan(text);

            var expectedValue = $"**prefix\\{charToEscape}suffix**";

            Assert.Equal(expectedValue, span.ToString());
        }

        [Fact]
        public void ToString_returns_an_empty_string_if_value_is_empty()
        {
            var span = new MdStrongEmphasisSpan(new MdTextSpan(""));
            Assert.Equal(string.Empty, span.ToString());
        }

        [Theory]
        [InlineData(MdEmphasisStyle.Asterisk, '*')]
        [InlineData(MdEmphasisStyle.Underscore, '_')]
        public void ToString_respects_EmphasisStyle_from_serialization_options(MdEmphasisStyle emphasisStyle, char emphasisCharater)
        {
            var text = "Some text";
            var span = new MdStrongEmphasisSpan(text);

            var options = new MdSerializationOptions()
            {
                EmphasisStyle = emphasisStyle
            };

            var expected = $"{emphasisCharater}{emphasisCharater}{text}{emphasisCharater}{emphasisCharater}";
            var actual = span.ToString(options);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DeepEquals_returns_expected_value()
        {
            var instance1 = new MdStrongEmphasisSpan("content");
            var instance2 = new MdStrongEmphasisSpan("content");
            var instance3 = new MdStrongEmphasisSpan("other content");

            Assert.True(instance1.DeepEquals(instance1));
            Assert.True(instance1.DeepEquals(instance2));

            Assert.False(instance1.DeepEquals(null));
            Assert.False(instance1.DeepEquals(instance3));
            Assert.False(instance1.DeepEquals(new MdTextSpan("")));
        }
    }
}
