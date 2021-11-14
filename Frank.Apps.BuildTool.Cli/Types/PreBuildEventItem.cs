namespace Frank.Apps.BuildTool.Cli.Types;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public partial class PreBuildEventItem : SimpleItemType
{

    private object[] itemsField;

    private ItemsChoiceType2[] itemsElementNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Command", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("Message", typeof(object))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
        get { return this.itemsField; }
        set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType2[] ItemsElementName
    {
        get { return this.itemsElementNameField; }
        set { this.itemsElementNameField = value; }
    }
}