using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.MarkdownGenerator.Internal
{
    class NullPrefixHandler : IPrefixHandler
    {
        public static readonly NullPrefixHandler Instance = new NullPrefixHandler();


        private NullPrefixHandler()
        { }


        public int PrefixLength => 0;

        public string? GetBlankLinePrefix() => "";

        public string? GetLinePrefix() => "";
    }
}
