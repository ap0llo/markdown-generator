﻿using Grynwald.MarkdownGenerator.Internal;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Represents a thematic break.
    /// For specification see https://spec.commonmark.org/0.28/#thematic-breaks
    /// </summary>
    public sealed class MdThematicBreak : MdLeafBlock
    {
        /// <inheritdoc />
        public override bool DeepEquals(MdBlock other) => other is MdThematicBreak;
        

        internal override void Accept(IBlockVisitor visitor) => visitor.Visit(this);
    }
}
