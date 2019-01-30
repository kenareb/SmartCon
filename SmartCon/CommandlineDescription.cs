namespace SmartCon
{
    /// <summary>
    /// The <c>CommandLineDescription</c> class describes the
    /// format of the commandline.
    /// </summary>
    public class CommandLineDescription
    {
        /// <summary>
        /// Describes the separator between the commandline key and the
        /// commandline value.
        /// </summary>
        /// <para>
        /// Example:
        /// </para>
        /// <code>
        /// copy -source=c:\temp
        /// </code>
        /// <para>
        /// In the above example commandline, the "=" character
        /// is the separator between the key and the value.
        /// </para>
        /// <remarks>
        /// The default setting is "=".
        /// </remarks>
        public char KeyValueSeparator { get; set; }

        /// <summary>
        /// Describes the prefix before the commandline key.
        /// </summary>
        /// <para>
        /// Example:
        /// </para>
        /// <code>
        /// copy -source=c:\temp
        /// </code>
        /// <para>
        /// In the above example commandline, the "-" character
        /// is the prefix before the commandline key.
        /// </para>
        /// <remarks>
        /// The default setting is "-".
        /// </remarks>
        public char KeyPrefix { get; set; }

        public static CommandLineDescription DefaultCommandLine = new CommandLineDescription();
        public static CommandLineDescription LinStyle = new CommandLineDescription('-', '=');
        public static CommandLineDescription DotNetStyle = new CommandLineDescription('-', ':');
        public static CommandLineDescription CmdStyle = new CommandLineDescription('/', '=');

        public CommandLineDescription()
            : this('-', '=')
        { }

        public CommandLineDescription(char prefix, char separator)
        {
            KeyPrefix = prefix;
            KeyValueSeparator = separator;
        }
    }
}