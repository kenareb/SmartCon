namespace SmartCon
{
    using System;
    using System.Linq;

    /// <summary>
    /// Delegate definition of a handler, which takes a commandline argument.
    /// </summary>
    /// <param name="value">The specified value given via the commandline.</param>
    /// <remarks>
    /// For a commandline like "-f=filename", the value is "filename".
    /// </remarks>
    public delegate void ArgumentHandler(string value);
}