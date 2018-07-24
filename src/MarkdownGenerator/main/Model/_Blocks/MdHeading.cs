﻿using System;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// A markdown heading
    /// </summary>
    public sealed class MdHeading : MdLeafBlock
    {
        /// <summary>
        /// The text of the heading
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The level of the heading, 1 being the top-most heading
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MdHeading"/>
        /// </summary>
        /// <param name="text">The text of the heading. Must not be null.</param>
        /// <param name="level">The heading's level. Value must be in the range [1,6]</param>
        public MdHeading(string text, int level)
        {
            if (level < 1 || level > 6)
                throw new ArgumentOutOfRangeException(nameof(level), "Value must be in the range [1,6]");

            Text = text ?? throw new ArgumentNullException(nameof(text));
            Level = level;
        }

    }
}