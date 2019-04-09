namespace SmartCon.Help
{
    using System.Configuration;

    public class HelpEntryElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("arg", IsRequired = false)]
        public string Arg
        {
            get { return (string)this["arg"]; }
            set { this["arg"] = value; }
        }

        [ConfigurationProperty("description", IsRequired = false)]
        public string Description
        {
            get { return (string)this["description"]; }
            set { this["description"] = value; }
        }
    }
}