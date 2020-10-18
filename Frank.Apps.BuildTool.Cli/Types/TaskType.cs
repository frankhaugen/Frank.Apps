namespace Frank.Apps.BuildTool.Cli.Types
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class TaskType
    {

        private TaskTypeOutput[] outputField;

        private string conditionField;

        private string continueOnErrorField;

        private string architectureField;

        private string runtimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Output")]
        public TaskTypeOutput[] Output
        {
            get { return this.outputField; }
            set { this.outputField = value; }
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
        public string ContinueOnError
        {
            get { return this.continueOnErrorField; }
            set { this.continueOnErrorField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Architecture
        {
            get { return this.architectureField; }
            set { this.architectureField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Runtime
        {
            get { return this.runtimeField; }
            set { this.runtimeField = value; }
        }
    }
}