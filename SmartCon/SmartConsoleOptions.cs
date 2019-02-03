namespace SmartCon
{
    using System;

    /// <summary>
    /// The <c>SmartConsoleOptions</c> class contains a set of options
    /// affecting the behaviour of the <c>SmartConsole</c> class.
    /// </summary>
    public class SmartConsoleOptions
    {
        /// <summary>
        /// The default options.
        /// </summary>
        public static SmartConsoleOptions DefaultOptions { get; private set; } = new SmartConsoleOptions();

        /// <summary>
        /// The <c>LineBreak</c> sting, <see cref="Environment.NewLine"/>.
        /// </summary>
        public string LineBreak { get; set; } = Environment.NewLine;

        /// <summary>
        /// The indentaion level of the text.
        /// </summary>
        public int IndentationLevel { get; private set; } = 0;

        /// <summary>
        /// The text used for indentation. Defaults to four spaces.
        /// </summary>
        public string IndentationText { get; set; } = "    ";

        /// <summary>
        /// Increases the indentation level by one.
        /// </summary>
        public void IncreaseIndent()
        {
            IndentationLevel += 1;
        }

        /// <summary>
        /// Reduces the indentation level by one.
        /// </summary>
        /// <remarks>
        /// The indentation level will never be a negative value.
        /// </remarks>
        public void DecreaseIndent()
        {
            var level = IndentationLevel - 1;
            IndentationLevel = level >= 0 ? level : 0;
        }
    }
}