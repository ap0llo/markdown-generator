namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represent a inline text element in a markdown document
    /// </summary>
    public abstract class MdSpan
    {        
        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdSpan()
        { }


        // force re-implementation of ToString()
        public abstract override string ToString();


        internal abstract MdSpan DeepCopy();


        public static implicit operator MdSpan(string text) => text == null ? null : new MdTextSpan(text);
    }
}
