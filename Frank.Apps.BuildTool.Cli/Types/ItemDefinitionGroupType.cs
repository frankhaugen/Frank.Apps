namespace Frank.Apps.BuildTool.Cli.Types;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public partial class ItemDefinitionGroupType
{

    private SimpleItemType[] itemsField;

    private string conditionField;

    private string labelField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Item", typeof(SimpleItemType))]
    [System.Xml.Serialization.XmlElementAttribute("Link", typeof(LinkItem))]
    [System.Xml.Serialization.XmlElementAttribute("PostBuildEvent", typeof(PostBuildEventItem))]
    [System.Xml.Serialization.XmlElementAttribute("PreBuildEvent", typeof(PreBuildEventItem))]
    [System.Xml.Serialization.XmlElementAttribute("ResourceCompile", typeof(ResourceCompile))]
    public SimpleItemType[] Items
    {
        get { return this.itemsField; }
        set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Condition
    {
        get { return this.conditionField; }
        set { this.conditionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Label
    {
        get { return this.labelField; }
        set { this.labelField = value; }
    }
}