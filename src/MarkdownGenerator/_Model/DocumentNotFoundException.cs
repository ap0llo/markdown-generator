using System;

namespace Grynwald.MarkdownGenerator
{
    public sealed class DocumentNotFoundException : Exception
    {
        public DocumentNotFoundException(string message) : base(message)
        {
        }
    }
}
