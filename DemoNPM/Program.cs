namespace DemoNPM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Concurrent;
    using SmartCon;

    public class Program
    {
        private static void Main(string[] args)
        {
            /*
             * The current example demonstrated how to setup a command line handling
             * like the "npm" program has.
             *
             * The "install" command treats all following arguments as packages to install.
             * Whereas the "adduser" command expects a "-registry" argument to provided.
             *
             * You can call this program with the following arguments:
             * DemoNPM.exe install package1 package2 package3
             * DemoNPM.exe adduser --registry=http://npmjs.org
             *
             * */

            var handler = new CommandProcessor();
            handler.RegisterCommand("install", new InstallCommand());
            handler.RegisterCommand("adduser", new AddUserCommand());

            handler.Process(args);
        }
    }
}