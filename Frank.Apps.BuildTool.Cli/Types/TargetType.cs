namespace Frank.Apps.BuildTool.Cli.Types
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class TargetType
    {

        private object[] itemsField;

        private OnErrorType[] onErrorField;

        private string nameField;

        private string dependsOnTargetsField;

        private string inputsField;

        private string outputsField;

        private string conditionField;

        private string keepDuplicateOutputsField;

        private string returnsField;

        private string beforeTargetsField;

        private string afterTargetsField;

        private string labelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemGroup", typeof(ItemGroupType))]
        [System.Xml.Serialization.XmlElementAttribute("PropertyGroup", typeof(PropertyGroupType))]
        [System.Xml.Serialization.XmlElementAttribute("Task", typeof(TaskType))]
        public object[] Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OnError")]
        public OnErrorType[] OnError
        {
            get { return this.onErrorField; }
            set { this.onErrorField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DependsOnTargets
        {
            get { return this.dependsOnTargetsField; }
            set { this.dependsOnTargetsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Inputs
        {
            get { return this.inputsField; }
            set { this.inputsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Outputs
        {
            get { return this.outputsField; }
            set { this.outputsField = value; }
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
        public string KeepDuplicateOutputs
        {
            get { return this.keepDuplicateOutputsField; }
            set { this.keepDuplicateOutputsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Returns
        {
            get { return this.returnsField; }
            set { this.returnsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BeforeTargets
        {
            get { return this.beforeTargetsField; }
            set { this.beforeTargetsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AfterTargets
        {
            get { return this.afterTargetsField; }
            set { this.afterTargetsField = value; }
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