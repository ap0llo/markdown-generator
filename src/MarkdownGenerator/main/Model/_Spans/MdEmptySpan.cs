namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdEmptySpan : MdSpan
    {
        public static readonly MdEmptySpan Instance = new MdEmptySpan();

        private MdEmptySpan()
        {
        }


        public override string ToString() => string.Empty;


        internal override MdSpan DeepCopy() => Instance;        
    }
}
