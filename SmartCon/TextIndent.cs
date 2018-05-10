namespace SmartCon
{
    using System;

    public class TextIndent
    {
        private SmartConsoleOptions _options;

        public TextIndent()
        {
            _options = SmartConsoleOptions.DefaultOptions;
        }

        public TextIndent(SmartConsoleOptions options)
        {
            _options = options;
        }

        public string IndentInput(string input)
        {
            var indent = String.Empty;
            var builder = new System.Text.StringBuilder();
            builder.Append(indent);
            for (var i = 0; i <= _options.IndentationLevel; i++)
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

            return indentedText;
        }

        private static string[] SplitInput(string input, string linebreak)
        {
            var lines = input.Split(new[] { linebreak }, StringSplitOptions.None);
            return lines;
        }
    }
}