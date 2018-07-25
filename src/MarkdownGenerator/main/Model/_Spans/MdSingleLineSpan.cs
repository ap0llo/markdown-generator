﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Grynwald.MarkdownGenerator.Model
{
    /// <summary>
    /// Represents a span that will be written to the output as a single line.
    /// All line breaks will be removed and replaced by spaces.
    /// Trailng line breaks are removed
    /// </summary>
    public sealed class MdSingleLineSpan : MdSpan
    {
        private static readonly Regex s_LineBreakPattern = new Regex(@"(\s)*[\r\n]+(\s)*", RegexOptions.Compiled);
        private static readonly Regex s_TrailingLineBreakRegex = new Regex(@"[\r\n]+$", RegexOptions.Compiled);


        public MdSpan Content { get; }

        public MdSingleLineSpan(MdSpan content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public override MdSpan Copy() => new MdSingleLineSpan(Content.Copy());

        public override string ToString()
        {
            var content = Content.ToString();

            // remove trailing line breaks
            content = s_TrailingLineBreakRegex.Replace(content, "");

            // replace other line breaks with spaces. 
            // If linebreaks are folowed/precedded by whitespace
            // replace whitespace and line break with a single
            // space
            content = s_LineBreakPattern.Replace(content, " ");

            return content;
        }
    }
}