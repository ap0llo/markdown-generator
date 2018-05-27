using System;

namespace Grynwald.MarkdownGenerator.Model
{
    public sealed class MdHeading : MdLeafBlock
    {

        public string Text { get; }

        public int Level { get; }


        public MdHeading(string text, int level)
        {
            if (level <= 0)
                throw new ArgumentOutOfRangeException(nameof(level));

            Text = text ?? throw new ArgumentNullException(nameof(text));
            Level = level;
        }

    }
}
