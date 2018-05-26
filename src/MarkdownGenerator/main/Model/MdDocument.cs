using MarkdownBuilder.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarkdownBuilder.Model
{
    public class MdDocument
    {
        public MdContainerBlock Root { get; }


        public MdDocument(MdContainerBlock root) => 
            Root = root ?? throw new ArgumentNullException(nameof(root));

        public MdDocument(params MdBlock[] content) : this(new MdContainerBlock(content))
        { }

        public MdDocument(IEnumerable<MdBlock> content) : this(new MdContainerBlock(content))
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
            var visitor = new DocumentSerializer(writer);
            visitor.Serialize(this);           
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                Save(stringWriter);                
            }
            return stringBuilder.ToString();            
        }
    }
}
