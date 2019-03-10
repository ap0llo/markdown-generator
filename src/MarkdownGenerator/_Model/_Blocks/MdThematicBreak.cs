namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a thematic break.
    /// For specification see https://spec.commonmark.org/0.28/#thematic-breaks
    /// </summary>
    public sealed class MdThematicBreak : MdLeafBlock
    {
        public override bool DeepEquals(MdBlock other) => other is MdThematicBreak;
    }
}
