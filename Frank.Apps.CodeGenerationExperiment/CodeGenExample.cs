using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodegenCS;

namespace Frank.Apps.CodeGenerationExperiment
{
    public class CodeGenExample
    {
        public string Execute()
        {
            var w = new CodegenTextWriter();

            string ns = "myNamespace";
            string cl = "myClass";
            string method = "MyMethod";

            w.WithCurlyBraces($"namespace {ns}", () =>
            {
                w.WithCurlyBraces($"public class {cl}", () => {
                    w.WithCurlyBraces($"public void {method}()", () =>
                    {
                        w.WriteLine(@"test");
                    });
                });
            });

            return w.GetContents();
        }

        public string ExecuteReal(string namespaceName, string className)
        {
            var w = new CodegenTextWriter();

            var typesOverride = new List<string>();
            typesOverride.Add("int");
            typesOverride.Add("short");
            typesOverride.Add("long");

            var types = new List<string>();
            types.Add("int");
            //types.Add("uint");
            types.Add("short");
            //types.Add("ushort");
            types.Add("long");
            //types.Add("ulong");
            types.Add("float");
            types.Add("double");
                        types.Add("decimal");
            
            var operators = new Dictionary<Operator, string>();
            operators.Add(Operator.Add, "+");
            operators.Add(Operator.Subtract, "-");
            operators.Add(Operator.Multiply, "*");
            operators.Add(Operator.Divide, "/");

            var functionInfo = new List<FunctionInfo>();
            
            w.WithCurlyBraces($"namespace {namespaceName}", () =>
            {
                w.WithCurlyBraces($"public static class {className}", () => {
                    foreach (var @operator in operators)
                    //foreach (var type in types)
                    {
                        w.WriteLine(w.NewLine);
                        w.WriteLine($"// {@operator.Key} ");
                        //foreach (var @operator in operators)
                        foreach (var type in types)
                        {
                            var returnType = type;
                            if (@operator.Key == Operator.Divide && typesOverride.Contains(type)) returnType = "decimal";
                            w.WriteLine($"public static {returnType} {@operator.Key}(this {type} source, {type} value) => ({returnType}) (source {@operator.Value} value);");
                        }
                    }
                });
            });

            return w.GetContents();
        }
    }

    public enum Operator
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public class FunctionInfo
    {
        public FunctionInfo(string name, string type, Operator @operator)
        {
            Name = name;
            Type = type;
            Operator = @operator;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public Operator Operator { get; set; }
    }
}
