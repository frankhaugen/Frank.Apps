using System.Windows;
using System.Xml.Linq;

namespace Frank.Apps.UblGenerator
{
    public static class XamlSerializerUtility
    {
        public static string SerializeToXAML(UIElement element)
        {
            var strXAML = System.Windows.Markup.XamlWriter.Save(element);
            XElement xmlElement = XElement.Parse(strXAML);
            return xmlElement.ToString(SaveOptions.None);
        }
    }
}
