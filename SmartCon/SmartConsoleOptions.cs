namespace SmartCon
{
    using System;

    public class SmartConsoleOptions
    {
        public static SmartConsoleOptions DefaultOptions { get; private set; } = new SmartConsoleOptions();

        public string LineBreak { get; set; } = Environment.NewLine;

        public int IndentationLevel { get; private set; } = 0;

        public string IndentationText { get; set; } = "    ";

        public void IncreaseIndent()
        {
            IndentationLevel += 1;
        }

        public void DecreaseIndent()
        {
            var level = IndentationLevel - 1;
            IndentationLevel = level >= 0 ? level : 0;
        }
    }
}