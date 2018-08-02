﻿namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Defines the available serializaton styles for headings (see <see cref="MdHeading"/>).
    /// For specification see https://spec.commonmark.org/0.28/#atx-headings 
    /// respectively https://spec.commonmark.org/0.28/#setext-headings
    /// </summary>
    public enum MdHeadingStyle
    {
        /// <summary>
        /// Prefix headings with '#' 
        /// </summary>
        Atx = 0,

        /// <summary>
        /// Underscore level 1 and 2 headings with "======" respectively "------"
        /// </summary>
        /// <remarks>
        /// Setext heading are only available for level 1 and 2 headings.
        /// Even with the heading style set to Setext, Atx style will be used 
        /// for level 3 and above headings.
        /// </remarks>
        Setext = 1
    }
}
