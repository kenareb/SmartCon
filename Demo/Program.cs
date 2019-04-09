namespace Demo
{
    using SmartCon;
    using SmartCon.Help;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        private static SmartConsole _console = new SmartConsole();
        private static string _file = string.Empty;

        private static void Main(string[] args)
        {
            var handler = new ArgumentProcessor();
            // handler.CommandLineDescription = CommandLineDescription.DotNetStyle; // Demo -f=Demo.exe
            // handler.CommandLineDescription = CommandLineDescription.CmdStyle; // Demo /f Demo.exe

            handler.RegisterArgument("h", (v) => GetHelp());
            handler.RegisterArgument("f", (v) => SetFilename(v));
            handler.RegisterPostProcessor(DoWork);
            handler.Process(args);
        }

        private static void DoWork()
        {
            _console.WriteLine("Info:");
            _console.Options.IncreaseIndent();
            if (File.Exists(_file))
            {
                _console.WriteLine("File exists.");
            }
            else
            {
                _console.WriteLine("File does not exist.");
            }
            _console.Options.DecreaseIndent();
        }

        private static void GetHelp()
        {
            var hp = new ArgumentHelpProvider();
            var help = hp.GetDocumentation();

            _console.WriteLine();
            _console.WriteLine(help);

            Environment.Exit(0);
        }

        private static void SetFilename(string filename)
        {
            _file = Path.Combine(Environment.CurrentDirectory, filename);
            _console.WriteLine(_file);
        }
    }
}