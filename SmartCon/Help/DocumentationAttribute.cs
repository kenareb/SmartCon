namespace SmartCon.Help
{
    using System;

    /// <summary>
    /// The <c>DocumentationAttribute</c> provides a custom attribute to
    /// annotate a class with a documentation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class DocumentationAttribute : Attribute
    {
        /// <summary>
        /// The <c>Key</c> of the commandline argument.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// An example to be passed in as argument.
        /// </summary>
        public string ArgumentExample { get; set; }

        /// <summary>
        /// The description used to display.
        /// </summary>
        public string Description { get; set; }
    }
}