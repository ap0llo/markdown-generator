namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represent a inline text element in a markdown document
    /// </summary>
    public abstract class MdSpan
    {        
        // private protected constructor => class cannot be derived from outside this assembly
        private protected MdSpan()
        {
        }

        public abstract MdSpan Copy();

        // force re-implementation of ToString()
        public abstract override string ToString();
    }
}
