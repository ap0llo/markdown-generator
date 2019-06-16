using System;
using System.IO;
using Grynwald.Utilities.IO;
using Xunit;

namespace Grynwald.MarkdownGenerator.Test
{
    public class MdDocumentSetTest
    {
        [Fact]
        public void Indexer_returns_expected_document()
        {
            var path = "some/path/doc.md";
            var set = new MdDocumentSet();
            var document = set.CreateDocument(path);

            Assert.Same(document, set[path]);
        }


        [Fact]
        public void Documents_is_initially_empty()
        {
            var set = new MdDocumentSet();

            Assert.NotNull(set.Documents);
            Assert.Empty(set.Documents);
        }

        [Fact]
        public void Documents_returns_expected_documents()
        {
            var set = new MdDocumentSet();

            var document1 = set.CreateDocument("path1");
            var document2 = set.CreateDocument("path2");
            var document3 = set.CreateDocument("path3");

            Assert.Equal(3, set.Documents.Count);
            Assert.Contains(document1, set.Documents);
            Assert.Contains(document2, set.Documents);
            Assert.Contains(document3, set.Documents);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CreateDocument_throws_ArgumentException_for_empty_path(string path)
        {
            var set = new MdDocumentSet();
            Assert.Throws<ArgumentException>(() => set.CreateDocument(path));
        }

        [Theory]
        [InlineData("myPath.md", "myPath.md")]
        [InlineData("some/path/myPath.md", "some/path/myPath.md")]
        [InlineData("some/path/myPath.md", "some\\path\\myPath.md")]
        [InlineData("some/path/../../myPath.md", "myPath.md")]
        public void CreateDocument_throw_ArgumentException_for_duplicate_paths(string path1, string path2)
        {
            var set = new MdDocumentSet();

            _ = set.CreateDocument(path1);
            Assert.Throws<ArgumentException>(() => set.CreateDocument(path2));
        }

        [Theory]
        [InlineData("../some/path/document.md")]
        [InlineData("../../some/path/document.md")]
        [InlineData("some/path/../../../document.md")]
        [InlineData("/document.md")]
        [InlineData(@"C:\document.md")]
        public void CreateDocument_throw_ArgumentException_for_invalid_paths(string path)
        {
            var set = new MdDocumentSet();            
            Assert.Throws<ArgumentException>(() => set.CreateDocument(path));
        }

        [Theory]
        [InlineData("some/path/document.md")]
        [InlineData("some/path/../document.md")]
        public void CreateDocument_creates_a_new_Document_for_valid_paths(string path)
        {
            var set = new MdDocumentSet();
            var document = set.CreateDocument(path);
            Assert.NotNull(document);
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
        public void CreateDocument_normalizes_paths(string path, string expectedNormalizedPath)
        {
            var set = new MdDocumentSet();
            var document = set.CreateDocument(path);

            var actualNormalizedPath = set.GetPath(document);

            Assert.Equal(expectedNormalizedPath, actualNormalizedPath);
        }


        [Fact]
        public void Add_throws_ArgumentException_is_document_is_added_twice()
        {
            var set = new MdDocumentSet();
            var document = new MdDocument();

            set.Add("doc1.md", document);

            Assert.Throws<ArgumentException>(() => set.Add("doc2.md", document));
        }


        [Fact]
        public void GetPath_returns_a_documents_path()
        {
            var path = "some/path/doc.md";
            var set = new MdDocumentSet();
            var document = set.CreateDocument(path);

            Assert.Equal(path, set.GetPath(document));
        }


        [Theory]
        [InlineData("doc1.md", "doc2.md", "doc2.md")]
        [InlineData("some/path/doc1.md", "some/path/doc2.md", "doc2.md")]
        [InlineData("some/path/doc1.md", "somePath/doc2.md", "../../somePath/doc2.md")]
        [InlineData("some/path/doc1.md", "some/path/../doc2.md", "../doc2.md")]
        public void GetLink_returns_expected_link(string fromPath, string toPath, string expectedLinkUri)
        {
            var set = new MdDocumentSet();

            var from = set.CreateDocument(fromPath);
            var to = set.CreateDocument(toPath);

            var link = set.GetLink(from, to, "Link Text");

            Assert.NotNull(link);
            Assert.Equal(new Uri(expectedLinkUri, UriKind.Relative), link.Uri);
        }

        [Fact]
        public void Save_saves_all_documents()
        {
            using(var directory = new TemporaryDirectory())
            {
                // ARRANGE
                var set = new MdDocumentSet();
                var document1 = set.CreateDocument("doc1.md");
                var document2 = set.CreateDocument("subDir/doc2.md");

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

                var set = new MdDocumentSet();
                var document1 = set.CreateDocument("doc1.md");
                var document2 = set.CreateDocument("subDir/doc2.md");

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

                var set = new MdDocumentSet();
                var document1 = set.CreateDocument("doc1.md");
                var document2 = set.CreateDocument("subDir/doc2.md");

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
