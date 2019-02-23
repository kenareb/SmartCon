namespace DemoNPM
{
    using System;
    using System.Linq;
    using SmartCon;
    using SmartCon.Strategies;

    /// <summary>
    /// The <c>InstallCommand</c> provides a command line processor
    /// for the folowing command: install package1 package2 package3 ...
    /// </summary>
    public class InstallCommand : ArgumentProcessor
    {
        public InstallCommand()
        {
            this.CommandLineDescription = CommandLineDescription.CmdStyle;
            this.RegisterArgument("*", (v) => InstallPackage(v));
        }

        protected override IProcessingStrategy GetStrategy()
        {
            return new VisitorStrategy();
        }

        private void InstallPackage(string packageName)
        {
            Console.WriteLine("Installing package " + packageName);
        }
    }
}