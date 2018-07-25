using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdEmptySpan : MdSpan
    {
        public static readonly MdEmptySpan Instance = new MdEmptySpan();

        private MdEmptySpan()
        {
        }

        public override MdSpan Copy() => Instance;
    }
}
