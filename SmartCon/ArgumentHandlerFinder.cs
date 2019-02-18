namespace SmartCon
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Text;

    public class ArgumentHandlerFinder
    {
        private bool _caseSensitive = true;

        public ArgumentHandlerFinder(bool caseSensitive)
        {
            _caseSensitive = caseSensitive;
        }

        public ArgumentHandler Find(IDictionary<string, ArgumentHandler> handlers, string key)
        {
            return FindHandler(handlers, key);
        }

        protected virtual ArgumentHandler FindHandler(IDictionary<string, ArgumentHandler> handlers, string key)
        {
            ArgumentHandler h = null;

            var myKey = _caseSensitive ? key : key.ToLower();

            if (handlers.ContainsKey(myKey))
            {
                h = handlers[myKey];
            }

            return h;
        }
    }
}