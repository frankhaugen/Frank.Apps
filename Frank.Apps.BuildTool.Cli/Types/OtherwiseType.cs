﻿namespace Frank.Apps.BuildTool.Cli.Types;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public partial class OtherwiseType
{

    private object[] itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Choose", typeof(ChooseType))]
    [System.Xml.Serialization.XmlElementAttribute("ItemGroup", typeof(ItemGroupType))]
    [System.Xml.Serialization.XmlElementAttribute("PropertyGroup", typeof(PropertyGroupType))]
    public object[] Items
    {
        get { return this.itemsField; }
        set { this.itemsField = value; }
    }
}