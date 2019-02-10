using System;
using System.Linq;
using SmartCon;

namespace DemoNPM
{
    /// <summary>
    /// The <c>AddUserCommand</c> class provides a command line processor
    /// for the following command: adduser --registry=xyz
    /// </summary>
    public class AddUserCommand : ArgumentProcessor
    {
        private string _reg;

        public AddUserCommand()
        {
            this.CommandLineDescription = CommandLineDescription.GnuStyle;
            this.RegisterArgument("registry", (v) => SetRegisty(v));
            this.RegisterPostProcessor(DoAdd);
        }

        private void SetRegisty(string url)
        {
            _reg = url;
        }

        private void DoAdd()
        {
            Console.WriteLine("Adding user to registry " + _reg);
        }
    }
}