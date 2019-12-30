using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// A collection of documents associated with a path.
    /// </summary>
    /// <remarks>
    /// <see cref="DocumentSet{T}"/> allows grouping of multiple <see cref="IDocument"/> instances and associating
    /// them with a path. The document set offers methods to create links between documents and saving all 
    /// documents to a directory at once.
    /// <para>
    /// It implements a 1:1 mapping between documents and paths.
    /// </para>
    /// </remarks>
    public class DocumentSet<T> : IEnumerable<T> where T : notnull, IDocument
    {
        private readonly Dictionary<string, T> m_DocumentsByPath;
        private readonly Dictionary<T, string> m_PathsByDocument;

        /// <summary>
        /// Gets the document associated with the specified path.
        /// </summary>
        /// <param name="path">The path to get the document for.</param>
        /// <returns>Returns the document associated with the specified path.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="path"/> is null.</exception>
        /// <exception cref="DocumentNotFoundException">Thrown when no document associated with the specified path was found.</exception>
        public T this[string path]
        {
            get
            {
                if (path == null)
                    throw new ArgumentNullException(nameof(path));

                if (!m_DocumentsByPath.ContainsKey(path))
                    throw new DocumentNotFoundException($"Document set does not contain a document with path '{path}'.");

                return m_DocumentsByPath[path];
            }
        }

        /// <summary>
        /// Gets the path associated with the specified document.
        /// </summary>
        /// <param name="document">The document which's path to get.</param>
        /// <returns>Returns the path for the specified document.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="document"/> is null.</exception>
        /// <exception cref="DocumentNotFoundException">Thrown when the specified document is not part of this document set.</exception>
        public string this[T document]
        {
            get
            {
                if (document == null)
                    throw new ArgumentNullException(nameof(document));

                if (m_PathsByDocument.TryGetValue(document, out var path))
                    return path;
                else
                    throw new DocumentNotFoundException("Cannot get path for document that is not in document set.");
            }
        }

        /// <summary>
        /// Gets all the documents in this document set.
        /// </summary>
        public IEnumerable<T> Documents => m_DocumentsByPath.Values;


        /// <summary>
        /// Initializes a new instance of <see cref="DocumentSet{T}"/>.
        /// </summary>
        public DocumentSet()
        {
            // treat paths case-insensitive on Windows
            m_DocumentsByPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase)
                : new Dictionary<string, T>(StringComparer.Ordinal);
            
            m_PathsByDocument = new Dictionary<T, string>();            
        }

        /// <summary>
        /// Determines whether the specified document is part of the document set.
        /// </summary>
        public bool ContainsDocument(T document) => m_PathsByDocument.ContainsKey(document);

        /// <summary>
        /// Determines whether a document with the specified path is part of the document set.
        /// </summary>
        public bool ContainsPath(string path)
        {
            path = NormalizeRelativePath(path);
            return m_DocumentsByPath.ContainsKey(path);
        }
      

        /// <summary>
        /// Adds the specified document to the set at the specified path.
        /// </summary>
        /// <param name="path">The document's relative path.</param>
        /// <param name="document">The document to add to the document set.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is null of empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="document"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the document set already contains a document with the specified path.</exception>
        /// <exception cref="ArgumentException">Thrown when the document set already contains the specified document.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="path"/> is not a valid relative path.
        /// Value must not be rooted and must not refer to a location outside the root output directory,
        /// e.g. <c>../doc.md</c>.
        /// </exception>
        public void Add(string path, T document)
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("Value must not be null of empty.", nameof(path));

            if (document == null)
                throw new ArgumentNullException(nameof(document));

            path = NormalizeRelativePath(path);

            if (m_DocumentsByPath.ContainsKey(path))
                throw new ArgumentException($"A document with path '{path}' already exists.", nameof(path));

            if (m_PathsByDocument.ContainsKey(document))
                throw new ArgumentException("The document has already been added.");

            m_DocumentsByPath.Add(path, document);
            m_PathsByDocument.Add(document, path);
        }

        /// <summary>
        /// Gets the relative link between the specified documents.
        /// </summary>
        /// <param name="from">The link source (i.e. the document the link span will be placed in).</param>
        /// <param name="to">The links's target.</param>
        /// <returns>The relative path between the specified documents as <c>string</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="from"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="to"/> is null.</exception>
        /// <exception cref="DocumentNotFoundException">Thrown when <paramref name="from"/> is not part of the document set.</exception>
        /// <exception cref="DocumentNotFoundException">Thrown when <paramref name="to"/> is not part of the document set.</exception>
        public string GetRelativePath(T from, T to)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (to == null)
                throw new ArgumentNullException(nameof(to));
            
            var rootPath = Environment.CurrentDirectory;

            var fromUri = new Uri(Path.Combine(rootPath, this[from]));
            var toUri = new Uri(Path.Combine(rootPath, this[to]));

            var uri = fromUri.MakeRelativeUri(toUri);

            return uri.ToString();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the document set's documents.
        /// </summary>
        public IEnumerator<T> GetEnumerator() => Documents.GetEnumerator();

        /// <summary>
        /// Returns an (non-generic) enumerator that iterates through the document set's documents.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => Documents.GetEnumerator();

        /// <summary>
        /// Saves all the set's documents to the specified output directory.
        /// </summary>
        /// <param name="directoryPath">The directory path to save the documents to.</param>
        public void Save(string directoryPath) =>
            Save(directoryPath, cleanOutputDirectory: false);

        /// <summary>
        /// Saves all the set's documents to the specified output directory.
        /// </summary>
        /// <param name="directoryPath">The directory path to save the documents to.</param>
        /// <param name="cleanOutputDirectory">Determines whether the output directory is deleted before saving the documents.</param>
        public void Save(string directoryPath, bool cleanOutputDirectory) =>
            Save(directoryPath, cleanOutputDirectory, (document, path) => document.Save(path));

        /// <summary>
        /// Saves all the set's documents to the specified output directory.
        /// </summary>
        /// <param name="directoryPath">The directory path to save the documents to.</param>
        /// <param name="cleanOutputDirectory">Determines whether the output directory is deleted before saving the documents.</param>
        /// <param name="saveOperation">
        /// The action to apply to the document when saving.
        /// <para>
        /// Allows customization of the save operation. The specified action will be called instead of
        /// <see cref="IDocument.Save(String)"/>.
        /// </para>
        /// </param>
        public void Save(string directoryPath, bool cleanOutputDirectory, Action<T, string> saveOperation)
        {
            if (directoryPath == null)
                throw new ArgumentNullException(nameof(directoryPath));

            // If selected, delete all files and directories in the output directory
            // Keep the root output directory unchanged (it would be recreated
            // directly afterwards anyways). By keeping the directory
            // we won't run into problems when an application still
            // has the directory open.
            if (Directory.Exists(directoryPath) && cleanOutputDirectory)
            {
                foreach(var childDir in Directory.GetDirectories(directoryPath))
                {
                    Directory.Delete(childDir, recursive: true);
                }

                foreach(var file in Directory.GetFiles(directoryPath))
                {
                    File.Delete(file);
                }
            }

            foreach (var keyValuePair in m_DocumentsByPath)
            {
                var path = keyValuePair.Key;
                var document = keyValuePair.Value;

                var outPath = Path.Combine(directoryPath, path);

                Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                saveOperation(document, outPath);
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
