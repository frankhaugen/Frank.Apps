namespace Frank.Apps.BuildTool.Cli.Types;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public partial class ResourceCompile : SimpleItemType
{

    private object[] itemsField;

    private ItemsChoiceType1[] itemsElementNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AdditionalIncludeDirectories", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("Culture", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("IgnoreStandardIncludePath", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("NullTerminateStrings", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("PreprocessorDefinitions", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("ResourceOutputFileName", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("ShowProgress", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("SuppressStartupBanner", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("UndefinePreprocessorDefinitions", typeof(object))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
        get { return this.itemsField; }
        set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType1[] ItemsElementName
    {
        get { return this.itemsElementNameField; }
        set { this.itemsElementNameField = value; }
    }
}