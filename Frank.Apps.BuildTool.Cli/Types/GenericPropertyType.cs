namespace Frank.Apps.BuildTool.Cli.Types;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public partial class GenericPropertyType
{

    private System.Xml.XmlNode[] anyField;

    private string conditionField;

    private string labelField;

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlNode[] Any
    {
        get { return this.anyField; }
        set { this.anyField = value; }
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