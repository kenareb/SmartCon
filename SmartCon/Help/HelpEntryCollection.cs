namespace SmartCon.Help
{
    using System.Configuration;
    using System.Xml;

    public class HelpEntryCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new HelpEntryElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((HelpEntryElement)element).Key;
        }
    }
}