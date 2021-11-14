namespace Frank.Apps.BuildTool.Cli.Types;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public partial class GenericItemType : SimpleItemType
{

    private System.Xml.XmlElement anyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement Any
    {
        get { return this.anyField; }
        set { this.anyField = value; }
    }
}