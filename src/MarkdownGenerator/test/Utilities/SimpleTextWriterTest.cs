using System;
using System.IO;
using System.Text;
using Xunit;
using MarkdownBuilder.Utilities;

namespace MarkdownBuilder.Test.Utilities
{
    public class SimpleTextWriterTest : IDisposable
    {        
        readonly TextWriter m_TextWriter;
        readonly SimpleTextWriter m_Instance;
        readonly StringBuilder m_StringBuilder;

        public SimpleTextWriterTest()
        {
            m_StringBuilder = new StringBuilder();
            m_TextWriter = new StringWriter(m_StringBuilder);
            m_Instance = new SimpleTextWriter(m_TextWriter);
        }

        public void Dispose() => m_TextWriter.Dispose();

        private string GetWrittenText() => m_StringBuilder.ToString();


        [Fact]
        public void WriteLine_saves_text_01()
        {
            // ARRANGE
            var expected = "Hello World\r\n";

            // ACT
            m_Instance.WriteLine("Hello World");
            
            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WriteLine_saves_text_02()
        {
            // ARRANGE
            var expected = 
                "Hello\r\n" +
                "World\r\n";

            // ACT
            m_Instance.WriteLine("Hello");
            m_Instance.WriteLine("World");

            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RequestBlankLine_inserts_a_blank_line_between_writes()
        {
            // ARRANGE
            var expected = 
                "Hello\r\n" +
                "\r\n" +
                "World\r\n";

            // ACT
            m_Instance.WriteLine("Hello");
            m_Instance.RequestBlankLine();
            m_Instance.WriteLine("World");

            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RequestBlankLine_does_not_insert_blank_lines_at_the_start()
        {
            // ARRANGE
            var expected = "Hello World\r\n";

            // ACT
            m_Instance.RequestBlankLine();
            m_Instance.WriteLine("Hello World");

            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RequestBlankLine_ignores_request_before_any_line_is_written()
        {
            // ARRANGE
            var expected = "Hello\r\nWorld\r\n";

            // ACT
            m_Instance.RequestBlankLine();
            m_Instance.WriteLine("Hello");
            m_Instance.WriteLine("World");

            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RequestBlankLine_does_not_insert_blank_lines_at_the_end()
        {
            // ARRANGE
            var expected = "Hello World\r\n";

            // ACT
            m_Instance.WriteLine("Hello World");
            m_Instance.RequestBlankLine();

            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RequestBlankLine_does_not_insert_multiple_blank_lines()
        {
            // ARRANGE
            var expected =
                "Hello\r\n" +
                "\r\n" +
                "World\r\n";

            // ACT
            m_Instance.WriteLine("Hello");
            m_Instance.RequestBlankLine();
            m_Instance.RequestBlankLine();
            m_Instance.WriteLine("World");

            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }       

        [Fact]
        public void PushPrefix_sets_a_new_prefix_when_no_prefix_is_set()
        {
            // ARRANGE
            var expected =
                "Hello\r\n" +
                "prefix-World\r\n";

            // ACT
            m_Instance.WriteLine("Hello");
            m_Instance.PushPrefix("prefix-");
            m_Instance.WriteLine("World");

            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PushPrefix_sets_a_new_prefix_when_a_prefix_is_already_set()
        {
            // ARRANGE
            var expected =
                "prefix1-Hello\r\n" +                
                "prefix2-World\r\n";

            // ACT
            m_Instance.PushPrefix("prefix1-");
            m_Instance.WriteLine("Hello");
            m_Instance.PushPrefix("prefix2-");
            m_Instance.WriteLine("World");

            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PopPrefix_restores_the_previous_prefix()
        {
            // ARRANGE
            var expected =
                "prefix1-Line1\r\n" +
                "prefix2-Line2\r\n" +
                "prefix1-Line3\r\n";

            // ACT
            m_Instance.PushPrefix("prefix1-");
            m_Instance.WriteLine("Line1");
            m_Instance.PushPrefix("prefix2-");            
            m_Instance.WriteLine("Line2");
            m_Instance.PopPrefix();
            m_Instance.WriteLine("Line3");

            // ASSERT
            var actual = GetWrittenText();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CurrentPrefix_returns_null_if_no_prefix_is_set_01()
        {
            Assert.Null(m_Instance.CurrentPrefix);
        }

        [Fact]
        public void CurrentPrefix_returns_null_if_no_prefix_is_set_02()
        {
            m_Instance.PushPrefix("prefix");
            m_Instance.PopPrefix();
            Assert.Null(m_Instance.CurrentPrefix);
        }

        [Fact]
        public void CurrentPrefix_returns_the_current_prefix()
        {
            m_Instance.PushPrefix("prefix");
            Assert.Equal("prefix", m_Instance.CurrentPrefix);
        }
    }
}
