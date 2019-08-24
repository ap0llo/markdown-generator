using System;
using System.IO;
using System.Linq;
using Grynwald.Utilities.IO;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class DocumentSetTest
    {
        private class TestDocument : IDocument
        {
            public void Save(string path) => File.WriteAllText(path, "Test Document Content");
        }


        [Fact]
        public void Indexer_returns_expected_document()
        {
            var path = "some/path/doc.md";
            var set = new DocumentSet<TestDocument>();
            var document = new TestDocument();
            set.Add(path, document);

            Assert.Same(document, set[path]);
        }

        [Fact]
        public void Indexer_throws_ArgumentNullException_if_path_is_null()
        {
            var set = new DocumentSet<TestDocument>();
            Assert.Throws<ArgumentNullException>(() => set[(string)null]);
        }

        [Fact]
        public void Indexer_throws_DocumentNotFoundException_if_path_is_unknown()
        {
            var set = new DocumentSet<TestDocument>();
            set.Add("doc2.md", new TestDocument());
            Assert.Throws<DocumentNotFoundException>(() => set["doc1.md"]);
            Assert.Throws<DocumentNotFoundException>(() => set["path/doc1.md"]);
        }

        [Fact]
        public void Indexer_returns_a_documents_path()
        {
            var path = "some/path/doc.md";
            var set = new DocumentSet<TestDocument>();
            var document = new TestDocument();
            set.Add(path, document);

            Assert.Equal(path, set[document]);
        }

        [Fact]
        public void Indexer_throws_ArgumentNullException_if_document_is_null()
        {
            var set = new DocumentSet<TestDocument>();
            Assert.Throws<ArgumentNullException>(() => set[(TestDocument)null]);
        }

        [Fact]
        public void Indexer_throws_DocumentNotFoundException_if_document_is_unknown()
        {
            var set = new DocumentSet<TestDocument>();
            Assert.Throws<DocumentNotFoundException>(() => set[new TestDocument()]);
        }


        [Fact]
        public void Documents_is_initially_empty()
        {
            var set = new DocumentSet<TestDocument>();

            Assert.NotNull(set.Documents);
            Assert.Empty(set.Documents);
        }

        [Fact]
        public void Documents_returns_expected_documents()
        {
            var set = new DocumentSet<TestDocument>();

            var document1 = new TestDocument();
            set.Add("path1", document1);
            var document2 = new TestDocument();
            set.Add("path2", document2);
            var document3 = new TestDocument();
            set.Add("path3", document3);

            Assert.Equal(3, set.Documents.Count());
            Assert.Contains(document1, set.Documents);
            Assert.Contains(document2, set.Documents);
            Assert.Contains(document3, set.Documents);
        }

        [Fact]
        public void ContainsDocument_returns_expected_value()
        {
            var set = new DocumentSet<TestDocument>();

            var doc1 = new TestDocument();
            var doc2 = new TestDocument();

            set.Add("doc1.md", doc1);

            Assert.True(set.ContainsDocument(doc1));
            Assert.False(set.ContainsDocument(doc2));
        }

        [Fact]
        public void ContainsPath_returns_expected_value()
        {
            var set = new DocumentSet<TestDocument>();

            var doc1 = new TestDocument();
            set.Add("doc1.md", doc1);
            
            var doc2 = new TestDocument();
            set.Add("doc2.md", doc2);

            Assert.True(set.ContainsPath("doc1.md"));
            Assert.True(set.ContainsPath("subDir/../doc1.md"));
            Assert.True(set.ContainsPath("subDir\\../doc1.md"));
            Assert.True(set.ContainsPath("doc2.md"));

            Assert.False(set.ContainsPath("doc3.md"));
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Add_throws_ArgumentException_for_empty_path(string path)
        {
            var set = new DocumentSet<TestDocument>();            
            Assert.Throws<ArgumentException>(() => set.Add(path, new TestDocument()));
        }

        [Theory]
        [InlineData("myPath.md", "myPath.md")]
        [InlineData("some/path/myPath.md", "some/path/myPath.md")]
        [InlineData("some/path/myPath.md", "some\\path\\myPath.md")]
        [InlineData("some/path/../../myPath.md", "myPath.md")]
        public void Add_throw_ArgumentException_for_duplicate_paths(string path1, string path2)
        {
            var set = new DocumentSet<TestDocument>();

            set.Add(path1, new TestDocument());
            Assert.Throws<ArgumentException>(() => set.Add(path2, new TestDocument()));
        }

        [Theory]
        [InlineData("../some/path/document.md")]
        [InlineData("../../some/path/document.md")]
        [InlineData("some/path/../../../document.md")]
        [InlineData("/document.md")]
        [InlineData(@"C:\document.md")]
        public void Add_throw_ArgumentException_for_invalid_paths(string path)
        {
            var set = new DocumentSet<TestDocument>();
            Assert.Throws<ArgumentException>(() => set.Add(path, new TestDocument()));
        }

        [Theory]
        [InlineData("some/path/document.md", "some/path/document.md")]
        [InlineData(@"some\path\document.md", "some/path/document.md")]
        [InlineData(@"some\path/document.md", "some/path/document.md")]
        [InlineData("some/path/../document.md", "some/document.md")]
        [InlineData(@"some\path\..\document.md", "some/document.md")]
        [InlineData("some/path/./document.md", "some/path/document.md")]
        [InlineData(@"some\path\.\document.md", "some/path/document.md")]
        [InlineData("some/path/../path/document.md", "some/path/document.md")]
        [InlineData(@"some\path\..\path\document.md", "some/path/document.md")]
        public void Add_normalizes_paths(string path, string expectedNormalizedPath)
        {
            var set = new DocumentSet<TestDocument>();

            var document = new TestDocument();
            set.Add(path, document);

            var actualNormalizedPath = set[document];

            Assert.Equal(expectedNormalizedPath, actualNormalizedPath);
        }


        [Fact]
        public void Add_throws_ArgumentException_is_document_is_added_twice()
        {
            var set = new DocumentSet<TestDocument>();
            var document = new TestDocument();

            set.Add("doc1.md", document);

            Assert.Throws<ArgumentException>(() => set.Add("doc2.md", document));
        }


        [Theory]
        [InlineData("doc1.md", "doc2.md", "doc2.md")]
        [InlineData("some/path/doc1.md", "some/path/doc2.md", "doc2.md")]
        [InlineData("some/path/doc1.md", "somePath/doc2.md", "../../somePath/doc2.md")]
        [InlineData("some/path/doc1.md", "some/path/../doc2.md", "../doc2.md")]
        public void GetRelativePath_returns_expected_link(string fromPath, string toPath, string expectedLinkUri)
        {
            var set = new DocumentSet<TestDocument>();

            var from = new TestDocument();
            set.Add(fromPath, from);
            var to = new TestDocument();
            set.Add(toPath, to);

            var relativePath = set.GetRelativePath(from, to);

            Assert.NotNull(relativePath);
            Assert.Equal(expectedLinkUri, relativePath);
        }

        [Fact]
        public void GetRelativePath_throws_DocumentNotFoundException_if_eiher_document_is_unknown()
        {
            var set = new DocumentSet<TestDocument>();
            var doc1 = new TestDocument();
            set.Add("doc1.md", doc1);
            var doc2 = new TestDocument();
            set.Add("doc2.md", doc2);

            Assert.Throws<DocumentNotFoundException>(() => set.GetRelativePath(doc1, new TestDocument()));
            Assert.Throws<DocumentNotFoundException>(() => set.GetRelativePath(new TestDocument(), doc2));
        }

        [Fact]
        public void Save_saves_all_documents()
        {
            using (var directory = new TemporaryDirectory())
            {
                // ARRANGE
                var set = new DocumentSet<MdDocument>();

                var document1 = new MdDocument();
                set.Add("doc1.md", document1);

                var document2 = new MdDocument();
                set.Add("subDir/doc2.md", document2);

                var expectedOutPath1 = Path.Combine(directory, "doc1.md");
                var expectedOutPath2 = Path.Combine(directory, "subDir/doc2.md");

                document1.Root.Add(new MdHeading(1, "Document 1"));
                document2.Root.Add(new MdHeading(1, "Document 2"));

                // ACT
                set.Save(directory);

                // ASSERT
                Assert.True(File.Exists(expectedOutPath1));
                Assert.True(File.Exists(expectedOutPath2));

                Assert.Equal(document1.ToString(), File.ReadAllText(expectedOutPath1));
                Assert.Equal(document2.ToString(), File.ReadAllText(expectedOutPath2));
            }
        }

        [Fact]
        public void Save_deletes_output_directory_if_cleanOutputDirectory_is_true()
        {
            using (var directory = new TemporaryDirectory())
            {
                // ARRANGE
                var existingPath1 = Path.Combine(directory, "file1.txt");
                var existingPath2 = Path.Combine(directory, "subDir/file2.txt");

                Directory.CreateDirectory(Path.GetDirectoryName(existingPath1));
                File.WriteAllText(existingPath1, "Content");
                Directory.CreateDirectory(Path.GetDirectoryName(existingPath2));
                File.WriteAllText(existingPath2, "Content");

                var set = new DocumentSet<TestDocument>();
                var document1 = new TestDocument();
                set.Add("doc1.md", document1);
                var document2 = new TestDocument();
                set.Add("subDir/doc2.md", document2);

                var expectedOutPath1 = Path.Combine(directory, "doc1.md");
                var expectedOutPath2 = Path.Combine(directory, "subDir/doc2.md");

                // ACT
                set.Save(directory, cleanOutputDirectory: true);

                // ASSERT
                Assert.True(File.Exists(expectedOutPath1));
                Assert.True(File.Exists(expectedOutPath2));
                Assert.False(File.Exists(existingPath1));
                Assert.False(File.Exists(existingPath2));
            }
        }

        [Fact]
        public void Save_keeps_redundant_files_in_output_directory_if_cleanOutputDirectory_is_false()
        {
            using (var directory = new TemporaryDirectory())
            {
                // ARRANGE
                var existingPath1 = Path.Combine(directory, "file1.txt");
                var existingPath2 = Path.Combine(directory, "subDir/file1.txt");

                Directory.CreateDirectory(Path.GetDirectoryName(existingPath1));
                File.WriteAllTextAsync(existingPath1, "Content");
                Directory.CreateDirectory(Path.GetDirectoryName(existingPath2));
                File.WriteAllTextAsync(existingPath2, "Content");

                var set = new DocumentSet<TestDocument>();

                var document1 = new TestDocument();
                set.Add("doc1.md", document1);

                var document2 = new TestDocument();
                set.Add("subDir/doc2.md", document2);

                var expectedOutPath1 = Path.Combine(directory, "doc1.md");
                var expectedOutPath2 = Path.Combine(directory, "subDir/doc2.md");

                // ACT
                set.Save(directory, cleanOutputDirectory: false);

                // ASSERT
                Assert.True(File.Exists(expectedOutPath1));
                Assert.True(File.Exists(expectedOutPath2));
                Assert.True(File.Exists(existingPath1));
                Assert.True(File.Exists(existingPath2));
            }
        }
    }
}
