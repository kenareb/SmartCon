namespace SmartCon.Help
{
    /// <summary>
    /// The <c>ArgumentHelpEntry</c> contains a documentation of an argument
    /// passed via the commandline.
    /// </summary>
    public class ArgumentHelpEntry
    {
        /// <summary>
        /// Initialises a new <c>ArgumentHelpEntry</c>
        /// </summary>
        public ArgumentHelpEntry()
        {
        }

        /// <summary>
        /// Initialises a new <c>ArgumentHelpEntry</c>
        /// </summary>
        /// <param name="helpElement">The <see cref="HelpEntryElement"/> to set up initial values.</param>
        public ArgumentHelpEntry(HelpEntryElement helpElement)
        {
            Key = helpElement.Key;
            ExampleArgumentValue = helpElement.Arg;
            Documentation = helpElement.Description;
        }

        /// <summary>
        /// The Key of the commandline argument.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// An example argument for this key.
        /// </summary>
        public string ExampleArgumentValue { get; set; }

        /// <summary>
        /// The documentation describing the key and the example argument.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets the short information about the help entry.
        /// </summary>
        /// <param name="cmd">The <see cref="CommandLineDescription"/> will be used to format the information text.</param>
        /// <returns>A short information text for this help entry.</returns>
        public string GetShortInfo(CommandLineDescription cmd)
        {
            return string.IsNullOrEmpty(ExampleArgumentValue)
                ? cmd.KeyPrefix + Key + " "
                : cmd.KeyPrefix + Key + cmd.KeyValueSeparator + ExampleArgumentValue + " ";
        }
    }
}