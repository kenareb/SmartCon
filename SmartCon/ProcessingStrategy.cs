namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public abstract class ProcessingStrategy
    {
        public abstract void Process(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers);
    }
}