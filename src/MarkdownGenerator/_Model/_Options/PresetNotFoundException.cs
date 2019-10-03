using System;

namespace Grynwald.MarkdownGenerator
{
    public sealed class PresetNotFoundException : Exception
    {
        public PresetNotFoundException(string message) : base(message)
        { }
    }
}
