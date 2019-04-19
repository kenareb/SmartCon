namespace SmartCon.Help
{
    using System.Configuration;

    /// <summary>
    /// The <c>HelpEntryElement</c> class contains all information, which can be stored in
    /// a configuration element of the <c>app.config</c> file.
    /// </summary>
    public class HelpEntryElement : ConfigurationElement
    {
        /// <summary>
        /// The key property.
        /// </summary>
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        /// <summary>
        /// The argument example string.
        /// </summary>
        [ConfigurationProperty("arg", IsRequired = false)]
        public string Arg
        {
            get { return (string)this["arg"]; }
            set { this["arg"] = value; }
        }

        /// <summary>
        /// The description of the key/argument combination.
        /// </summary>
        [ConfigurationProperty("description", IsRequired = false)]
        public string Description
        {
            get { return (string)this["description"]; }
            set { this["description"] = value; }
        }
    }
}