namespace SmartCon.Help
{
    /// <summary>
    /// The <c>ArgumentHelpEntry</c> contains a documentation of an argument
    /// passed via the commandline.
    /// </summary>
    public class ArgumentHelpEntry
    {
        public ArgumentHelpEntry()
        {
        }

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

        public string GetShortInfo(CommandLineDescription cmd)
        {
            if (string.IsNullOrEmpty(ExampleArgumentValue))
            {
                return cmd.KeyPrefix + Key + " ";
            }
            else
            {
                return cmd.KeyPrefix + Key + cmd.KeyValueSeparator + ExampleArgumentValue + " ";
            }
        }
    }
}