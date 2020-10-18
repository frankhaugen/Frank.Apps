namespace Frank.Apps.BuildTool.Cli.Types
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PostBuildEventItem))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PreBuildEventItem))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ResourceCompile))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkItem))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GenericItemType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class SimpleItemType
    {

        private string conditionField;

        private string includeField;

        private string excludeField;

        private string removeField;

        private string updateField;

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
        public string Include
        {
            get { return this.includeField; }
            set { this.includeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Exclude
        {
            get { return this.excludeField; }
            set { this.excludeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Remove
        {
            get { return this.removeField; }
            set { this.removeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Update
        {
            get { return this.updateField; }
            set { this.updateField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Label
        {
            get { return this.labelField; }
            set { this.labelField = value; }
        }
    }
}