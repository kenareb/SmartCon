namespace SmartCon
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Text;

    public class ArgumentHandlerFinder
    {
        private bool _caseSensitive = true;
        protected IDictionary<string, ArgumentHandler> ArgHandles { get; set; } = new ConcurrentDictionary<string, ArgumentHandler>();

        public ArgumentHandlerFinder(IDictionary<string, ArgumentHandler> handlers, bool casSensitive)
        {
            _caseSensitive = casSensitive;
            foreach (var h in handlers)
            {
                ArgHandles[_caseSensitive ? h.Key : h.Key.ToLower()] = h.Value;
            }
        }

        public ArgumentHandler Find(string key)
        {
            return FindHandler(key);
        }

        protected virtual ArgumentHandler FindHandler(string key)
        {
            ArgumentHandler h = null;

            var myKey = _caseSensitive ? key : key.ToLower();

            if (ArgHandles.ContainsKey(myKey))
            {
                h = ArgHandles[myKey];
            }

            return h;
        }
    }
}