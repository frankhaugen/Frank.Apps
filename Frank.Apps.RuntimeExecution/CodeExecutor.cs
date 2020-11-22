using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Frank.Apps.RuntimeExecution
{
    public class CodeExecuter
    {
        private readonly ScriptOptions _scriptOptions;

        public CodeExecuter()
        {
            _scriptOptions = ScriptOptions.Default
                .AddReferences(typeof(string).Assembly)
                .AddImports("System");
        }

        public async Task<string?> RoslynScriptingAsync(string? input = null, params Assembly[] assemblies)
        {
            var methodCode = @"return nameof(Exception);";

            if (input is not null)
                methodCode = input;

            _scriptOptions.AddReferences(assemblies);

            var script = CSharpScript.Create(methodCode, _scriptOptions);

            var state = await script.RunAsync();

            var result = state.ReturnValue as string;

            return result;
        }
    }
}