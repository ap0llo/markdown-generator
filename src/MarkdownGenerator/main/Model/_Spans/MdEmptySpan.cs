using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdEmptySpan : MdSpan
    {
        public static readonly MdEmptySpan Instance = new MdEmptySpan();

        private MdEmptySpan()
        {
        }


        public override string ToString() => String.Empty;

        public override string ToString(MdSerializationOptions options) => String.Empty;


        internal override MdSpan DeepCopy() => Instance;        
    }
}
