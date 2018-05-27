using System;
using System.IO;
using System.Text;
using Xunit;
using Grynwald.MarkdownGenerator.Utilities;

namespace Grynwald.MarkdownGenerator.Test.Utilities
{
    public class SimpleTextWriterTest : IDisposable
    {        
        readonly TextWriter m_TextWriter;
        readonly PrefixTextWriter m_Instance;
        readonly StringBuilder m_StringBuilder;

        public SimpleTextWriterTest()
        {
            m_StringBuilder = new StringBuilder();
            m_TextWriter = new StringWriter(m_StringBuilder);
            m_Instance = new PrefixTextWriter(m_TextWriter);
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
    }
}
