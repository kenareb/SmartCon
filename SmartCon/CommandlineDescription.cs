namespace SmartCon
{
    public class CommandLineDescription
    {
        public char KeyValueSeparator { get; set; }
        public char KeyPrefix { get; set; }
        public bool AcceptSwitches { get; set; }

        public static CommandLineDescription DefaultCommandLine = new CommandLineDescription();

        public CommandLineDescription()
            : this('-', '=', true)
        { }

        public CommandLineDescription(char prefix, char separator, bool switches)
        {
            KeyPrefix = prefix;
            KeyValueSeparator = separator;
            AcceptSwitches = switches;
        }
    }
}