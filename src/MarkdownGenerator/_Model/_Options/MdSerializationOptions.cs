using System;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Encapsulates settings that control how a document is serialized.
    /// A instance of <see cref="MdSerializationOptions"/> can be passed to
    /// the ToString overloads in <see cref="MdBlock"/>, <see cref="MdSpan"/> and <see cref="MdDocument"/> as
    /// well as the Save() method of <see cref="MdDocument"/>
    /// </summary>
    public class MdSerializationOptions
    {
        public static readonly MdSerializationOptions Default = new MdSerializationOptions(isReadOnly: true);

        public static class Presets
        {
            public static readonly MdSerializationOptions Default = MdSerializationOptions.Default;

            /// <summary>
            /// Gets serialization options optimized for rendering the generated Markdown file
            /// using <see href="https://www.mkdocs.org/">MkDocs</see>.
            /// </summary>
            /// <remarks>
            /// The MkDocs preset changes the following settings compared to the default preset:
            /// <list type="bullet">
            ///     <item>
            ///         <description>
            ///         Increase <see cref="MinimumListIndentationWidth"/> to 4 so nested lists
            ///         are rendered properly when using MkDocs default settings (see 
            ///         <see href="https://github.com/mkdocs/mkdocs/issues/545">GitHub issue 545</see>)
            ///         </description>
            ///     </item>
            ///     <item>
            ///         <description>
            ///         Change escaping of some characters because documents are not rendered correctly
            ///         when using the default escaping (see <see cref="MkDocsTextFormatter"/>)
            ///         </description>
            ///     </item>
            /// </list>
            /// </remarks>
            public static readonly MdSerializationOptions MkDocs = new MdSerializationOptions(
                isReadOnly: true,
                minimumListIndentationWidth: 4,
                textFormatter: MkDocsTextFormatter.Instance);
            
            public static MdSerializationOptions Get(string name)
            {
                switch (name.ToLower())
                {
                    case "default":
                        return Default;

                    case "mkdocs":
                        return MkDocs;

                    default:
                       throw new PresetNotFoundException($"Unknown preset '{name}'");
                }
            }
        }

        private readonly bool m_IsReadOnly;

        private MdEmphasisStyle m_EmphasisStyle;
        private MdThematicBreakStyle m_ThematicBreakStyle;
        private MdHeadingStyle m_HeadingStyle;
        private MdCodeBlockStyle m_CodeBlockStyle;
        private MdBulletListStyle m_BulletListStyle;
        private MdOrderedListStyle m_OrderedListStyle;
        private int m_MinimumListIndentationWidth;
        private MdTableStyle m_TableStyle;
        private int m_MaxLineLength;
        private ITextFormatter m_TextFormatter;

        public MdSerializationOptions() : this(isReadOnly: false)
        { }

        private MdSerializationOptions(
            bool isReadOnly,
            MdEmphasisStyle emphasisStyle = MdEmphasisStyle.Asterisk,
            MdThematicBreakStyle thematicBreakStyle = MdThematicBreakStyle.Underscore,
            MdHeadingStyle headingStyle = MdHeadingStyle.Atx,
            MdCodeBlockStyle codeBlockStyle = MdCodeBlockStyle.Backtick,
            MdBulletListStyle bulletListStyle = MdBulletListStyle.Dash,
            MdOrderedListStyle orderedListStyle = MdOrderedListStyle.Dot,
            int minimumListIndentationWidth = 2,
            MdTableStyle tableStyle = MdTableStyle.GFM,
            int maxLineLength = -1,
            ITextFormatter textFormatter = null)
        {
            m_IsReadOnly = isReadOnly;
            m_EmphasisStyle = emphasisStyle;
            m_ThematicBreakStyle = thematicBreakStyle;
            m_HeadingStyle = headingStyle;
            m_CodeBlockStyle = codeBlockStyle;
            m_BulletListStyle = bulletListStyle;
            m_OrderedListStyle = orderedListStyle;
            m_MinimumListIndentationWidth = minimumListIndentationWidth;
            m_TableStyle = tableStyle;
            m_MaxLineLength = maxLineLength;
            m_TextFormatter = textFormatter ?? DefaultTextFormatter.Instance;
        }

        /// <summary>
        /// Gets or sets the style for emphasized and strongly emphasized text.
        /// <para>
        /// Default value: <see cref="MdEmphasisStyle.Asterisk"/>.
        /// </para>
        /// </summary>
        public MdEmphasisStyle EmphasisStyle
        {
            get => m_EmphasisStyle;
            set => SetValue(nameof(EmphasisStyle), value, ref m_EmphasisStyle);
        }

        /// <summary>
        /// Gets or sets the style to use for thematic breaks.
        /// <para>
        /// Default value: <see cref="MdThematicBreakStyle.Underscore"/>.
        /// </para>
        /// </summary>
        public MdThematicBreakStyle ThematicBreakStyle
        {
            get => m_ThematicBreakStyle;
            set => SetValue(nameof(ThematicBreakStyle), value, ref m_ThematicBreakStyle);
        }

        /// <summary>
        /// Gets or sets the style for headings.
        /// <para>
        /// Default value: <see cref="MdHeadingStyle.Atx"/>.
        /// </para>
        /// </summary>
        public MdHeadingStyle HeadingStyle
        {
            get => m_HeadingStyle;
            set => SetValue(nameof(HeadingStyle), value, ref m_HeadingStyle);
        }

        /// <summary>
        /// Gets or sets the style of code blocks.
        /// <para>
        /// Default value: <see cref="MdCodeBlockStyle.Backtick"/>.
        /// </para>
        /// </summary>
        public MdCodeBlockStyle CodeBlockStyle
        {
            get => m_CodeBlockStyle;
            set => SetValue(nameof(CodeBlockStyle), value, ref m_CodeBlockStyle);
        }

        /// <summary>
        /// Gets or sets the style for bullet list items.
        /// <para>
        /// Default value: <see cref="MdBulletListStyle.Dash"/>.
        /// </para>
        /// </summary>
        public MdBulletListStyle BulletListStyle
        {
            get => m_BulletListStyle;
            set => SetValue(nameof(BulletListStyle), value, ref m_BulletListStyle);
        }

        /// <summary>
        /// Gets or sets the style for ordered list items.
        /// <para>
        /// Default value: <see cref="MdOrderedListStyle.Dot"/>.
        /// </para>
        /// </summary>
        public MdOrderedListStyle OrderedListStyle
        {
            get => m_OrderedListStyle;
            set => SetValue(nameof(OrderedListStyle), value, ref m_OrderedListStyle);
        }

        /// <summary>
        /// Gets or sets the minimum number of characters to use for indenting list items
        /// in multi-level lists (compared to items of the outer list level).
        /// <para>
        /// The value indicates a minimum indentation.
        /// List items are always indented at least by the length of the list marker.
        /// </para>
        /// <para>
        /// Default value: <c>2</c>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Setting the indentation to less than <c>2</c> will cause multi-level lists to
        /// be "flattened" to a single level.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when setting the property to a negative value.</exception>
        public int MinimumListIndentationWidth
        {
            get => m_MinimumListIndentationWidth;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Value must not be less than 0");

                SetValue(nameof(MinimumListIndentationWidth), value, ref m_MinimumListIndentationWidth);
            }
        }

        /// <summary>
        /// Gets or sets the style for tables.
        /// <para>
        /// Default value: <see cref="MdTableStyle.GFM"/>.
        /// </para>
        /// </summary>
        public MdTableStyle TableStyle
        {
            get => m_TableStyle;
            set => SetValue(nameof(TableStyle), value, ref m_TableStyle);
        }

        /// <summary>
        /// Gets or sets the maximum length of a line in the output.
        /// When set to a value greater than 0, line breaks
        /// will be inserted after the specified number of characters
        /// when possible.
        /// <para>
        /// Default value: <c>-1</c> (no line length limitation)
        /// </para>
        /// </summary>
        /// <remarks>
        /// Not all types of blocks can be split into multiple lines.
        /// Also line breaks will only be inserted between words, so if
        /// the length of a word exceeds the maximum line length the max length
        /// cannot be adhered to
        /// </remarks>
        public int MaxLineLength
        {
            get => m_MaxLineLength;
            set => SetValue(nameof(MaxLineLength), value, ref m_MaxLineLength);
        }

        /// <summary>
        /// Gets or sets the implementation to use for escaping text when saving a Markdown document.
        /// </summary>
        /// <remarks>
        /// The implementation of <see cref="ITextFormatter" /> set here will be used to escape
        /// plain text before writing it to the output document.
        /// <para>
        /// When no escaper is set, <see cref="DefaultTextFormatter"/> will be used.
        /// </para>
        /// </remarks>
        public ITextFormatter TextFormatter
        {
            get => m_TextFormatter;
            set => SetValue(nameof(TextFormatter), value, ref m_TextFormatter);
        }


        private void SetValue<T>(string propertyName, T value, ref T backingField)
        {
            if (m_IsReadOnly)
                throw new InvalidOperationException($"Cannot set property '{propertyName}' of read-only instance of {nameof(MdSerializationOptions)}");

            backingField = value;
        }
    }
}
