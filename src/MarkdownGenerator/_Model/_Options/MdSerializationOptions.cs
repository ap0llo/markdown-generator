using System;

namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Encapsulates settings that control how a document is serialized.
    /// A instance of <see cref="MdSerializationOptions"/> can be passed to
    /// the ToString overloads in <see cref="MdBlock"/>, <see cref="MdSpan"/> and <see cref="MdDocument"/>
    /// as well as the Save() method of <see cref="MdDocument"/>
    /// </summary>
    public class MdSerializationOptions
    {        
        public static readonly MdSerializationOptions Default = new MdSerializationOptions(isReadOnly: true);

        private readonly bool m_IsReadOnly;

        private MdEmphasisStyle m_EmphasisStyle = MdEmphasisStyle.Asterisk;
        private MdThematicBreakStyle m_ThematicBreakStyle = MdThematicBreakStyle.Underscore;
        private MdHeadingStyle m_HeadingStyle = MdHeadingStyle.Atx;
        private MdCodeBlockStyle m_CodeBlockStyle = MdCodeBlockStyle.Backtick;
        private MdBulletListStyle m_BulletListStyle = MdBulletListStyle.Dash;
        private MdOrderedListStyle m_OrderedListStyle = MdOrderedListStyle.Dot;
        private MdTableStyle m_TableStyle = MdTableStyle.GFM;
        private int m_MaxLineLength = -1;
        private ITextFormatter m_TextFormatter = DefaultTextFormatter.Instance;


        public MdSerializationOptions() : this(isReadOnly: false)
        { }

        private MdSerializationOptions(bool isReadOnly)
        {
            m_IsReadOnly = isReadOnly;
        }


        /// <summary>
        /// Gets or sets the style for emphasized and strongly emphasized text
        /// </summary>
        public MdEmphasisStyle EmphasisStyle
        {
            get => m_EmphasisStyle;
            set => SetValue(nameof(EmphasisStyle), value, ref m_EmphasisStyle);
        }

        /// <summary>
        /// Gets or sets the style to use for thematic breaks
        /// </summary>
        public MdThematicBreakStyle ThematicBreakStyle
        {
            get => m_ThematicBreakStyle;
            set => SetValue(nameof(ThematicBreakStyle), value, ref m_ThematicBreakStyle);
        }

        /// <summary>
        /// Gets or sets the style for headings
        /// </summary>
        public MdHeadingStyle HeadingStyle
        {
            get => m_HeadingStyle;
            set => SetValue(nameof(HeadingStyle), value, ref m_HeadingStyle);
        }

        /// <summary>
        /// Gets or sets the style of code blocks
        /// </summary>
        public MdCodeBlockStyle CodeBlockStyle
        {
            get => m_CodeBlockStyle;
            set => SetValue(nameof(CodeBlockStyle), value, ref m_CodeBlockStyle);
        }

        /// <summary>
        /// Gets or sets the style for bullet list items
        /// </summary>
        public MdBulletListStyle BulletListStyle
        {
            get => m_BulletListStyle;
            set => SetValue(nameof(BulletListStyle), value, ref m_BulletListStyle);
        }

        /// <summary>
        /// Gets or sets the style for ordered list items
        /// </summary>
        public MdOrderedListStyle OrderedListStyle
        {
            get => m_OrderedListStyle;
            set => SetValue(nameof(OrderedListStyle), value, ref m_OrderedListStyle);
        }

        /// <summary>
        /// Gets or sets the style for tables
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
