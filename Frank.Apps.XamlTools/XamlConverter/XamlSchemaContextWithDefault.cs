using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xaml;

namespace Frank.Apps.XamlTools.XamlConverter
{
    class XamlSchemaContextWithDefault : XamlSchemaContext
    {
        private readonly Assembly m_defaultAssembly;

        public XamlSchemaContextWithDefault() : this(Assembly.GetEntryAssembly())
        {}

        public XamlSchemaContextWithDefault(Assembly defaultAssembly)
            : base(GetReferenceAssemblies())
        {
            m_defaultAssembly = defaultAssembly;
        }

        static IEnumerable<Assembly> GetReferenceAssemblies()
        {
            return new[] { "WindowsBase", "PresentationCore", "PresentationFramework" }.Select(an => Assembly.LoadWithPartialName(an));
        }

        protected override Assembly OnAssemblyResolve(string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyName))
                return m_defaultAssembly;

            return base.OnAssemblyResolve(assemblyName);
        }
    }
}