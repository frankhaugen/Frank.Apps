using System.Windows;
using System.Xml.Linq;

namespace Frank.Apps.XamlGenerator
{
    public static class XamlSerializer
    {
        public static string Serialize(this UIElement element)
        {
            var xaml = System.Windows.Markup.XamlWriter.Save(element);
            XElement xElement = XElement.Parse(xaml);
            return xElement.ToString(SaveOptions.None);
        }
    }
}
