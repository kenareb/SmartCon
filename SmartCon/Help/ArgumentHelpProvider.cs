namespace SmartCon.Help
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;

    /// <summary>
    /// The <c>ArgumentHelpProvider</c> class is responsible for keeping track of
    /// the documentation used for the 'Usage' or 'GetHelp' method of a console app.
    /// </summary>
    public sealed class ArgumentHelpProvider
    {
        private List<ArgumentHelpEntry> _argHelpEntries = new List<ArgumentHelpEntry>();
        private CommandLineDescription _cmd = CommandLineDescription.DefaultCommandLine;
        private TextIndent _indent = new TextIndent(new SmartConsoleOptions());
        private StringBuilder _builder = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the <c>ArgumentHelpProvider</c> class.
        /// </summary>
        public ArgumentHelpProvider()
        {
            InitFromConfig();
            _indent.IncreaseIndentationLevel();
        }

        /// <summary>
        /// Initializes a new instance of the <c>ArgumentHelpProvider</c> class.
        /// </summary>
        /// <param name="cmd">The <see cref="CommandLineDescription"/> used to build the help text.</param>
        public ArgumentHelpProvider(CommandLineDescription cmd) : base()
        {
            _cmd = cmd;
        }

        /// <summary>
        /// Registers a new documentation entry for a commandline argument.
        /// </summary>
        /// <param name="entry">An arguemnt help entry.</param>
        public void RegisterDocumentation(ArgumentHelpEntry entry)
        {
            _argHelpEntries.Add(entry);
        }

        /// <summary>
        /// Gets the documentation for all registered commandling arguments / keys.
        /// </summary>
        /// <returns>A documentation string as defined in the app.config file.</returns>
        public string GetDocumentation()
        {
            _builder.Clear();

            var exe = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            _builder.Append("Usage: " + exe);

            foreach (var entry in _argHelpEntries)
            {
                _builder.Append(" " + entry.GetShortInfo(_cmd));
            }

            _builder.AppendLine();
            _builder.AppendLine();

            foreach (var entry in _argHelpEntries)
            {
                _builder.AppendLine(entry.GetShortInfo(_cmd));
                _builder.AppendLine(_indent.IndentInput(entry.Documentation));
                _builder.AppendLine();
            }

            return _builder.ToString();
        }

        /// <summary>
        /// Initializes the <c>ArgumentHelpProvider</c> from the configuration defined help data.
        /// </summary>
        private void InitFromConfig()
        {
            var help = ConfigurationManager.GetSection(HelpSection.SectionName) as HelpSection;
            if (help != null)
            {
                foreach (HelpEntryElement entry in help.HelpEntries)
                {
                    var h = new ArgumentHelpEntry(entry);
                    RegisterDocumentation(h);
                }
            }
        }
    }
}