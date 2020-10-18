namespace Frank.Apps.BuildTool.Cli.Types
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class UsingTaskType
    {

        private System.Xml.XmlElement parameterGroupField;

        private UsingTaskBodyType taskField;

        private string conditionField;

        private string assemblyNameField;

        private string assemblyFileField;

        private string taskNameField;

        private string taskFactoryField;

        private string architectureField;

        private string runtimeField;

        /// <remarks/>
        public System.Xml.XmlElement ParameterGroup
        {
            get { return this.parameterGroupField; }
            set { this.parameterGroupField = value; }
        }

        /// <remarks/>
        public UsingTaskBodyType Task
        {
            get { return this.taskField; }
            set { this.taskField = value; }
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
        public string AssemblyName
        {
            get { return this.assemblyNameField; }
            set { this.assemblyNameField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AssemblyFile
        {
            get { return this.assemblyFileField; }
            set { this.assemblyFileField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TaskName
        {
            get { return this.taskNameField; }
            set { this.taskNameField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TaskFactory
        {
            get { return this.taskFactoryField; }
            set { this.taskFactoryField = value; }
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