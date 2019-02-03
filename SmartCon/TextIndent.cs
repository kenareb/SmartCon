namespace SmartCon
{
    using System;

    /// <summary>
    /// The <c>TextIndent</c> class is responsible for the indentation of text.
    /// </summary>
    public class TextIndent
    {
        /// <summary>
        /// The options used for this instance.
        /// </summary>
        private SmartConsoleOptions _options;

        /// <summary>
        /// The default indentation object.
        /// </summary>
        public static TextIndent DefaultIndent { get; private set; } = new TextIndent();

        /// <summary>
        /// Initializes a new instance of the <c>TextIndent</c> class.
        /// </summary>
        public TextIndent()
        {
            _options = SmartConsoleOptions.DefaultOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <c>TextIndent</c> class with the
        /// specified options.
        /// </summary>
        /// <param name="options">The options to be used for this instance.</param>
        public TextIndent(SmartConsoleOptions options)
        {
            _options = options;
        }

        /// <summary>
        /// Increases the indentation level.
        /// </summary>
        public void IncreaseIndentationLevel()
        {
            _options.IncreaseIndent();
        }

        /// <summary>
        /// Decreases the indentation level.
        /// </summary>
        public void DecreaseIndentationLevel()
        {
            _options.DecreaseIndent();
        }

        /// <summary>
        /// Processes the specified text and adds an indentation at the beginning
        /// of each line. The characters used for indentation are defined in the
        /// <see cref="SmartConsoleOptions"/>.
        /// </summary>
        /// <param name="input">The text to be indented.</param>
        /// <returns>The indented text.</returns>
        public string IndentInput(string input)
        {
            var indent = String.Empty;
            var builder = new System.Text.StringBuilder();
            builder.Append(indent);
            for (var i = 0; i < _options.IndentationLevel; i++)
            {
                builder.Append(_options.IndentationText);
            }
            indent = builder.ToString();

            builder.Clear();

            var indentedText = String.Empty;
            var lines = SplitInput(input, _options.LineBreak);
            var endsWithLineBreak = input.EndsWith(_options.LineBreak);
            var row = 0;

            foreach (var l in lines)
            {
                row++;

                builder.Append(indent);
                builder.Append(l);

                if (row == lines.Length)
                {
                    if (endsWithLineBreak) { builder.Append(_options.LineBreak); }
                }
                else
                {
                    builder.Append(_options.LineBreak);
                }
            }

            indentedText = builder.ToString();
            return indentedText;
        }

        /// <summary>
        /// Splits the given input by the specified linebreak.
        /// </summary>
        /// <param name="input">The text to be splitted.</param>
        /// <param name="linebreak">The string used to identify the linebreak.</param>
        /// <returns>An array containing a line per entry.</returns>
        private static string[] SplitInput(string input, string linebreak)
        {
            var lines = input.Split(new[] { linebreak }, StringSplitOptions.None);
            return lines;
        }
    }
}