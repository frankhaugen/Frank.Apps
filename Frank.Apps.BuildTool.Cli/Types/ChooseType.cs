namespace Frank.Apps.BuildTool.Cli.Types;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public partial class ChooseType
{

    private WhenType[] whenField;

    private OtherwiseType otherwiseField;

    private string labelField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("When")]
    public WhenType[] When
    {
        get { return this.whenField; }
        set { this.whenField = value; }
    }

    /// <remarks/>
    public OtherwiseType Otherwise
    {
        get { return this.otherwiseField; }
        set { this.otherwiseField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Label
    {
        get { return this.labelField; }
        set { this.labelField = value; }
    }
}