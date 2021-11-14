namespace Frank.Apps.BuildTool.Cli.Types;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public partial class TaskTypeOutput
{

    private string taskParameterField;

    private string itemNameField;

    private string propertyNameField;

    private string conditionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TaskParameter
    {
        get { return this.taskParameterField; }
        set { this.taskParameterField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ItemName
    {
        get { return this.itemNameField; }
        set { this.itemNameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string PropertyName
    {
        get { return this.propertyNameField; }
        set { this.propertyNameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Condition
    {
        get { return this.conditionField; }
        set { this.conditionField = value; }
    }
}