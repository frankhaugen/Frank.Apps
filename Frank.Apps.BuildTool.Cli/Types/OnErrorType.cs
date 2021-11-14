namespace Frank.Apps.BuildTool.Cli.Types;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public partial class OnErrorType
{

    private string conditionField;

    private string executeTargetsField;

    private string labelField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Condition
    {
        get { return this.conditionField; }
        set { this.conditionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ExecuteTargets
    {
        get { return this.executeTargetsField; }
        set { this.executeTargetsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Label
    {
        get { return this.labelField; }
        set { this.labelField = value; }
    }
}