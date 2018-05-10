namespace SmartCon
{
    using System;

    public class SmartConsole
    {
        private SmartConsoleOptions _options;
        private TextIndent _indent;

        public SmartConsole(SmartConsoleOptions options, TextIndent indent)
        {
            _options = options;
            _indent = indent;
        }

        public void WriteLine(string format, params object[] arg)
        {
            if (_options.IndentationLevel > 0)
            {
                var text = String.Format(Console.Out.FormatProvider, format, arg);
                var indented = _indent.IndentInput(text);
                Console.WriteLine(indented);
            }
            else
            {
                Console.WriteLine(format, arg);
            }
        }

        public void Write(string format, params object[] arg)
        {
            if (_options.IndentationLevel > 0)
            {
                var text = String.Format(Console.Out.FormatProvider, format, arg);
                var indented = _indent.IndentInput(text);
                Console.Write(indented);
            }
            else
            {
                Console.WriteLine(format, arg);
            }
        }
    }
}