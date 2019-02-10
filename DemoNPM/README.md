# npm style command line

This example project shows, how to implement an npm like command line processing.

````C#
using SmartCon;

public class Program
{
	private static void Main(string[] args)
	{
		/*
		 * The current example demonstrated how to setup a command line handling
		 * like the "npm" program has.
		 *
		 * The "install" command treats all following arguments as packeges to install.
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

public class InstallCommand : ArgumentProcessor
{
	public InstallCommand()
	{
		this.CommandLineDescription = CommandLineDescription.CmdStyle;
		this.RegisterArgument("*", (v) => InstallPackage(v));
	}

	protected override ProcessingStrategy GetStrategy()
	{
		return new VisitorStrategy();
	}

	private void InstallPackage(string packageName)
	{
		Console.WriteLine("Installing package " + packageName);
	}
}

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
````
