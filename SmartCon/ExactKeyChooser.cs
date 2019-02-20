namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExactKeySelector : DelegateSelector
    {
        private bool _caseSensitive;

        public ExactKeySelector(bool caseSensitiv) : base(caseSensitiv)
        {
            _caseSensitive = caseSensitiv;
        }

        protected override ArgumentHandler FindHandler(IDictionary<string, ArgumentHandler> handlers, string key)
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