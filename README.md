# SmartCon
A small collection of console tools for .NET.

## Processing of commandline arguments 
You can use SmartCon to handle commandline arguments of console apps.
There's no neet to parse the arguments, check fo a trailing dash etc.

### Basic Example:

```C#
using SmartCon;
  
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
    // ...
}
  
private static void GetHelp()
{ 
    // ...
}
  
private static void SetFilename(string filename)
{
    // ...
}
```

The previous example will give you a console app, which accepts the commandline arguments `-h` and `-f`.
Parameters are specified with an equal-sign, for example `-f=myfile.txt`.

### Different flavours of commandlines

#### Choosing the commandline flavour
You can change the commandline style by setting the `CommandlineDescription` property:

```C#
var handler = new ArgumentProcessor();
handler.CommandLineDescription = CommandLineDescription.CmdStyle;
```

SmartCon defines the following styles:

#### Default style
Arguments are prefixed with a dash, parameters are separated by an equal-sign:
```
-f=myfile.txt
```
```C#
var handler = new ArgumentProcessor();
handler.CommandLineDescription = CommandLineDescription.DefaultCommandLine;
```

#### DotNet-Style
Arguments are prefixed with a dash, parameters are separated by a colon:
```
-f:myfile.txt
```
```C#
var handler = new ArgumentProcessor();
handler.CommandLineDescription = CommandLineDescription.DotNetStyle;
```

#### CMD-Style
Arguments are prefixed with a forward-slash, parameters are separated by a space:
```
/f myfile.txt
```
```C#
var handler = new ArgumentProcessor();
handler.CommandLineDescription = CommandLineDescription.CmdStyle;
```

#### GNU-Style
Arguments are prefixed with two dashes, parameters are separated by an equal-sign:
```
--f=myfile.txt
```
```C#
var handler = new ArgumentProcessor();
handler.CommandLineDescription = CommandLineDescription.GnuStyle;
```


#### NPM-Style
SmartCon can also be set up to understand a command line style like npm. For example "npm adduser --registry=url" or "npm install package1 package2".

For a complete example see https://github.com/kenareb/SmartCon/tree/master/DemoNPM


## Defining Commandline Help

SmartCon offers two possibilities of defining data for the commandline help.

### Define help in the App.config file.

Example:

```XML
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="Help" type="SmartCon.Help.HelpSection, SmartCon" />
  </configSections>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
  </startup>
  <Help>
    <Commands>
      <add key="f" arg="filename" description="Looks for the given file." />
      <add key="h" description="Shows this help page." />
    </Commands>
  </Help>
</configuration>
```

To read the data from the App.Config use the following code:

```C#
class Program
{
	private static SmartConsole _console = new SmartConsole();

	private static void Main(string[] args)
	{
		var handler = new ArgumentProcessor();
		handler.RegisterArgument("h", (v) => GetHelp());
		handler.RegisterArgument("f", (v) => SetFilename(v));
		handler.Process(args);
	}

	private static void GetHelp()
	{
		var hp = new ArgumentHelpProvider();
		var help = hp.GetDocumentation();

		_console.WriteLine();
		_console.WriteLine(help);

		Environment.Exit(0);
	}

	// ...
}
```

This will produce the following output:

```
C:\> .\Demo.exe -h

Usage: Demo -f=filename  -h

-f=filename
    Looks for the given file.

-h
    Shows this help page.

```



### Define help with class attributes

To define the help with attributes use the following code:

```C#
[Documentation(Key = "h", Description = "Shows this help page.")]
[Documentation(Key = "f", ArgumentExample = "filename", Description = "Looks for the given file.")]
class Program
{
	private static SmartConsole _console = new SmartConsole();

	private static void Main(string[] args)
	{
		var handler = new ArgumentProcessor();
		handler.RegisterArgument("h", (v) => GetHelp());
		handler.RegisterArgument("f", (v) => SetFilename(v));
		handler.Process(args);
	}

	private static void GetHelp()
	{
		var hp = new ArgumentHelpProvider(typeof(Program));
		var help = hp.GetDocumentation();

		_console.WriteLine();
		_console.WriteLine(help);

		Environment.Exit(0);
	}

	// ...
}
```

This will produce the following output:

```
C:\> .\Demo.exe -h

Usage: Demo -f=filename  -h

-f=filename
    Looks for the given file.

-h
    Shows this help page.

```

Furhter description of how to process command line switches and how to set up command line help can be found on my 
blog posts [SmartCon Part-1](https://blog.beranek.de/2023/02/11/smartcon-part-1/) and [SmartCon Part-2](https://blog.beranek.de/2023/04/01/smartcon-part-2/).
