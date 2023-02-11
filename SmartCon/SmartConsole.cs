namespace SmartCon
{
    using System;
    using System.IO;

    /// <summary>
    /// The <c>SmartConsole</c> class is a wrapper for the <see cref="System.Console"/> class.
    /// </summary>
    public class SmartConsole
    {
        private SmartConsoleOptions _options;
        private TextIndent _indent;
        private TextWriter _writer = Console.Out;
        private TextReader _reader = Console.In;

        /// <summary>
        /// Initializes a new instance of the <c>SmartConsole</c> class.
        /// </summary>
        public SmartConsole()
        {
            _options = SmartConsoleOptions.DefaultOptions;
            _indent = TextIndent.DefaultIndent;
        }

        /// <summary>
        /// Initializes a new instance of the <c>SmartConsole</c> class with the specified
        /// options and text indentation.
        /// </summary>
        /// <param name="options">The options to use.</param>
        /// <param name="indent">The text indentation to use.</param>
        public SmartConsole(SmartConsoleOptions options, TextIndent indent)
        {
            _options = options;
            _indent = indent;
        }

        /// <summary>
        /// Initializes a new instance of the <c>SmartConsole</c> classwith the specified
        /// options and text indentation.
        /// </summary>
        /// <param name="writer">The writer class to me wrapped.</param>
        /// <param name="options">The options to use.</param>
        /// <param name="indent">The text indentation to use.</param>
        public SmartConsole(TextWriter writer, SmartConsoleOptions options, TextIndent indent)
        {
            _writer = writer;
            _options = options;
            _indent = indent;
        }

        /// <summary>
        /// Initializes a new instance of the <c>SmartConsole</c> classwith the specified
        /// options and text indentation.
        /// </summary>
        /// <param name="writer">The writer class to me wrapped.</param>
        /// <param name="reader">The reader class to me wrapped.</param>
        /// <param name="options">The options to use.</param>
        /// <param name="indent">The text indentation to use.</param>
        public SmartConsole(TextWriter writer, TextReader reader, SmartConsoleOptions options, TextIndent indent)
        {
            _writer = writer;
            _reader = reader;
            _options = options;
            _indent = indent;
        }

        /// <summary>
        /// The options for this <c>SmartConsole</c>.
        /// </summary>
        public SmartConsoleOptions Options
        {
            get { return _options; }
        }

        private void SetOptions(SmartConsoleOptions options)
        {
            _options = options;
        }

        private void SetIndent(TextIndent indent)
        {
            _indent = indent;
        }

        /// <summary>
        /// Writes a linefeed to the writer, depending on <see cref="Environment.NewLine"/>.
        /// </summary>
        public void WriteLine()
        {
            _writer.WriteLine();
        }

        /// <summary>
        /// Writes the specified objects and a linefeed to the writer, depending on <see cref="Environment.NewLine"/>.
        /// </summary>
        /// <param name="format">The text format.</param>
        /// <param name="arg">The arguments used for formatting.</param>
        /// <seealso cref="Console.WriteLine(string, object[])"/>
        public void WriteLine(string format, params object[] arg)
        {
            var text = arg.Length == 0
                ? format
                : String.Format(_writer.FormatProvider, format, arg);

            string indented = _options.IndentationLevel > 0
                ? _indent.IndentInput(text)
                : text;

            _writer.WriteLine(indented);
        }

        /// <summary>
        /// Writes the specified objects to the writer.
        /// </summary>
        /// <param name="format">The text format.</param>
        /// <param name="arg">The arguments used for formatting.</param>
        /// <seealso cref="Console.Write(string, object[])"/>
        public void Write(string format, params object[] arg)
        {
            var text = arg.Length == 0
               ? format
               : String.Format(_writer.FormatProvider, format, arg);

            string indented = _options.IndentationLevel > 0
                ? _indent.IndentInput(text)
                : text;

            _writer.Write(indented);
        }

        /// <summary>
        /// Reads a line from the wrapped reader.
        /// </summary>
        /// <returns>The string read from the reader.</returns>
        public string ReadLine()
        {
            return _reader.ReadLine();
        }
    }
}