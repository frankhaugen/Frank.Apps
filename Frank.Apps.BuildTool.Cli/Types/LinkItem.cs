namespace Frank.Apps.BuildTool.Cli.Types
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
    public partial class LinkItem : SimpleItemType
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AddModuleNamesToAssembly", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("AdditionalDependencies", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("AdditionalLibraryDirectories", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("AdditionalManifestDependencies", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("AllowIsolation", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("AssemblyDebug", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("AssemblyLinkResource", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("BaseAddress", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("CLRImageType", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("CLRSupportLastError", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("CLRThreadAttribute", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("CLRUnmanagedCodeCheck", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("CreateHotPatchableImage", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("DataExecutionPrevention", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("DelayLoadDLLs", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("DelaySign", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("Driver", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("EmbedManagedResourceFile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("EnableCOMDATFolding", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("EnableUAC", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("EntryPointSymbol", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("FixedBaseAddress", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("ForceFileOutput", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("ForceSymbolReferences", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("FunctionOrder", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("GenerateDebugInformation", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("GenerateMapFile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("HeapCommitSize", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("HeapReserveSize", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("IgnoreAllDefaultLibraries", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("IgnoreEmbeddedIDL", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("IgnoreSpecificDefaultLibraries", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("IgnoreStandardIncludePath", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("ImageHasSafeExceptionHandlers", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("ImportLibrary", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("KeyContainer", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("KeyFile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("LargeAddressAware", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("LinkErrorReporting", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("LinkStatus", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("LinkTimeCodeGeneration", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("MSDOSStubFileName", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("MapExports", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("MapFileName", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("MergeSections", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("MergedIDLBaseFileName", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("MidlCommandFile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("MinimumRequiredVersion", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("ModuleDefinitionFile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("OptimizeReferences", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("OutputFile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("PreventDllBinding", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("Profile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("ProfileGuidedDatabase", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("ProgramDatabaseFile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("RandomizedBaseAddress", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("RegisterOutput", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("SectionAlignment", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("ShowProgress", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("SpecifySectionAttributes", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("StackCommitSize", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("StackReserveSize", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("StripPrivateSymbols", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("SubSystem", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("SupportNobindOfDelayLoadedDLL", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("SupportUnloadOfDelayLoadedDLL", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("SuppressStartupBanner", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("SwapRunFromCD", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("SwapRunFromNET", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("TargetMachine", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("TerminalServerAware", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("TreatLinkerWarningAsErrors", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("TypeLibraryFile", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("TypeLibraryResourceID", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("UACExecutionLevel", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("UACUIAccess", typeof(object))]
        [System.Xml.Serialization.XmlElementAttribute("Version", typeof(object))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get { return this.itemsElementNameField; }
            set { this.itemsElementNameField = value; }
        }
    }
}