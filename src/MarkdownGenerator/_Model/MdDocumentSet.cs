using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Grynwald.Utilities.Collections;

namespace Grynwald.MarkdownGenerator
{
    public sealed class MdDocumentSet
    {
        private readonly Dictionary<string, MdDocument> m_DocumentsByPath;
        private readonly Dictionary<MdDocument, string> m_PathsByDocument;


        public MdDocument this[string path] => m_DocumentsByPath[path ?? throw new ArgumentNullException(nameof(path))];

        public IReadOnlyCollection<MdDocument> Documents { get; }


        public MdDocumentSet()
        {
            m_DocumentsByPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new Dictionary<string, MdDocument>(StringComparer.OrdinalIgnoreCase)
                : new Dictionary<string, MdDocument>(StringComparer.Ordinal);
            m_PathsByDocument = new Dictionary<MdDocument, string>();
            
            Documents = ReadOnlyCollectionAdapter.Create(m_DocumentsByPath.Values);
        }

        
        public MdDocument CreateDocument(string path)
        {
            var document = new MdDocument();
            Add(path, document);
            return document;
        }

        public void Add(string path, MdDocument document)
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("Value must not be null of empty.", nameof(path));

            path = NormalizeRelativePath(path);

            if (m_DocumentsByPath.ContainsKey(path))
                throw new ArgumentException($"A document with path '{path}' already exists.", nameof(path));

            if (m_PathsByDocument.ContainsKey(document))
                throw new ArgumentException("The document has already been added.");

            m_DocumentsByPath.Add(path, document);
            m_PathsByDocument.Add(document, path);
        }

        public string GetPath(MdDocument document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));

            return m_PathsByDocument[document];
        }

        public void Save(string directoryPath) =>
            Save(directoryPath, cleanOutputDirectory: false, serializationOptions: null);

        public void Save(string directoryPath, bool cleanOutputDirectory) =>
            Save(directoryPath, cleanOutputDirectory, serializationOptions: null);

        public void Save(string directoryPath, bool cleanOutputDirectory, MdSerializationOptions serializationOptions)
        {
            if (directoryPath == null)
                throw new ArgumentNullException(nameof(directoryPath));

            // serializationOptions can be null

            if(Directory.Exists(directoryPath) && cleanOutputDirectory)
            {
                Directory.Delete(directoryPath, recursive: true);
            }

            foreach (var keyValuePair in m_DocumentsByPath)
            {
                var path = keyValuePair.Key;
                var document = keyValuePair.Value;

                var outPath = Path.Combine(directoryPath, path);

                Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                document.Save(outPath, serializationOptions);
            }
        }


        private string NormalizeRelativePath(string value)
        {
            if(Path.IsPathRooted(value))
                throw new ArgumentException($"Path '{value}' is not a relative path", nameof(value));

            // normalize directory separators to always use '/'
            value = value.Replace(Path.DirectorySeparatorChar, '/').Replace(Path.AltDirectorySeparatorChar, '/');

            // convert path into absolute path to remove any navigation elements (e.g. '..')

            // use the current directory as root path (any valid path will do)
            var rootPath = Environment.CurrentDirectory;
            if (!rootPath.EndsWith("/"))
                rootPath += "/";
            var rootPathUri = new Uri(rootPath);

            var fullPath = Path.Combine(rootPath, value);
            var fullPathUri = new Uri(fullPath);

            // ensure the relative path does not refer to a location outside the root directory
            if (!fullPathUri.AbsolutePath.StartsWith(rootPathUri.AbsolutePath))
                throw new ArgumentException($"Relative path '{value}' leaves the root directory");

            // return a (normalized) relative path
            return rootPathUri.MakeRelativeUri(fullPathUri).ToString();                       
        }
    }
}
