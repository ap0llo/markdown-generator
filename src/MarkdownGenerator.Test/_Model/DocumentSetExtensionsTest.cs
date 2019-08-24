using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class DocumentSetExtensionsTest
    {
        [Theory]
        [InlineData("some/path/document.md")]
        [InlineData("some/path/../document.md")]
        public void CreateDocument_creates_a_new_Document_for_valid_paths(string path)
        {
            var set = new DocumentSet<MdDocument>();
            var document = set.CreateDocument(path);
            Assert.NotNull(document);
        }
    }
}
