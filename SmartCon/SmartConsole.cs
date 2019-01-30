namespace SmartCon
{
    using System;
    using System.IO;

    public class SmartConsole
    {
        private SmartConsoleOptions _options;
        private TextIndent _indent;
        private TextWriter _writer = Console.Out;
        private TextReader _reader = Console.In;

        public SmartConsole()
        {
            _options = SmartConsoleOptions.DefaultOptions;
            _indent = TextIndent.DefaultIndent;
        }

        public SmartConsole(SmartConsoleOptions options, TextIndent indent)
        {
            _options = options;
            _indent = indent;
        }

        public SmartConsole(TextWriter writer, SmartConsoleOptions options, TextIndent indent)
        {
            _writer = writer;
            _options = options;
            _indent = indent;
        }

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

        public void WriteLine(string format, params object[] arg)
        {
            if (_options.IndentationLevel > 0)
            {
                var text = String.Format(_writer.FormatProvider, format, arg);
                var indented = _indent.IndentInput(text);
                _writer.WriteLine(indented);
            }
            else
            {
                _writer.WriteLine(format, arg);
            }
        }

        public void Write(string format, params object[] arg)
        {
            if (_options.IndentationLevel > 0)
            {
                var text = String.Format(_writer.FormatProvider, format, arg);
                var indented = _indent.IndentInput(text);
                _writer.Write(indented);
            }
            else
            {
                _writer.WriteLine(format, arg);
            }
        }

        public string ReadLine()
        {
            return _reader.ReadLine();
        }
    }
}