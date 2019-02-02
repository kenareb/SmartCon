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

