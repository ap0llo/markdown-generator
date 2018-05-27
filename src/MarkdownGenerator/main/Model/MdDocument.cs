using Grynwald.MarkdownGenerator.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// A markdown document
    /// </summary>
    public sealed class MdDocument
    {
        /// <summary>
        /// The root container block containing all of the document's blocks
        /// </summary>
        public MdContainerBlock Root { get; }


        public MdDocument(MdContainerBlock root) => 
            Root = root ?? throw new ArgumentNullException(nameof(root));

        public MdDocument(params MdBlock[] content) : this(new MdContainerBlock(content))
        { }

        public MdDocument(IEnumerable<MdBlock> content) : this(new MdContainerBlock(content))
        { }

        // MdList implements IEnumerable<MdListItem> so this constructor is necessary to prevent ambiguities
        public MdDocument(MdList list) : this((MdBlock)list)
        { }

        public void Save(string path)
        {
            using(var stream = File.Open(path, FileMode.Create))            
            {
                Save(stream);
            }
        }

        public void Save(Stream stream)
        {
            using (var writer = new StreamWriter(stream, Encoding.Default, 1024, true))                
            {
                Save(writer);
            }
        }

        private void Save(TextWriter writer)
        {
            var serializer = new DocumentSerializer(writer);
            serializer.Serialize(this);           
        }

        public override string ToString()
        {            
            using (var stringWriter = new StringWriter())
            {
                Save(stringWriter);                
                return stringWriter.ToString();            
            }
        }
    }
}
