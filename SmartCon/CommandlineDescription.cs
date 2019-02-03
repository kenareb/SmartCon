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
        public string KeyValueSeparator { get; set; }

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
        public string KeyPrefix { get; set; }

        /// <summary>
        /// The Default commandline style "-f=filename"
        /// </summary>
        public static CommandLineDescription DefaultCommandLine = new CommandLineDescription();

        /// <summary>
        /// Linux commandline style, same as <c>DefaultCommandLine</c>.
        /// </summary>
        public static CommandLineDescription LinStyle = new CommandLineDescription("-", "=");

        /// <summary>
        /// GNU style for the commandline, "--f=filename"
        /// </summary>
        public static CommandLineDescription GnuStyle = new CommandLineDescription("--", "=");

        /// <summary>
        /// .NET style f the commandline, "-f:filename"
        /// </summary>
        public static CommandLineDescription DotNetStyle = new CommandLineDescription("-", ":");

        /// <summary>
        /// CMD style of the commandline, "/f filename"
        /// </summary>
        public static CommandLineDescription CmdStyle = new CommandLineDescription("/", " ");

        /// <summary>
        /// Initializes a new instance of the <c>CommandLineDescription</c> class.
        /// </summary>
        public CommandLineDescription()
            : this("-", "=")
        { }

        /// <summary>
        /// Initializes a new instance of the <c>CommandLineDescription</c> class.
        /// </summary>
        /// <param name="prefix">The prefix used to identify commandline argument keys.</param>
        /// <param name="separator">The separator used to split key and value in a commandline argument.</param>
        public CommandLineDescription(string prefix, string separator)
        {
            KeyPrefix = prefix;
            KeyValueSeparator = separator;
        }
    }
}