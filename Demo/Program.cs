namespace Demo
{
    using SmartCon;
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

            handler.RegisterArgument("h", (v) => GetHelp());
            handler.RegisterArgument("f", (v) => SetFilename(v));
            handler.RegisterPostProcessor(DoWork);
            handler.Process(args);
        }

        private static void DoWork()
        {
            _console.Options.IncreaseIndent();
            if (File.Exists(_file))
            {
                _console.WriteLine("File exists.");
            }
            else
            {
                _console.WriteLine("File does not exist.");
            }
        }

        private static void GetHelp()
        {
            _console.WriteLine("Usage: Demo.exe [-h] -f=<filename>");
            Environment.Exit(0);
        }

        private static void SetFilename(string filename)
        {
            _file = Path.Combine(Environment.CurrentDirectory, filename);
            _console.WriteLine(_file);
        }
    }
}