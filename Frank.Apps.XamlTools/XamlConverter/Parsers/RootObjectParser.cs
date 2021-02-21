using System.CodeDom;

namespace Frank.Apps.XamlTools.XamlConverter.Parsers
{
    class RootObjectParser : ObjectParser
    {
        public RootObjectParser(XamlConvertor.State state)
            : base(state)
        {}

        protected override void ParseEnd()
        {
            var returnStatement = new CodeMethodReturnStatement(new CodeVariableReferenceExpression(VariableName));
            State.AddStatement(returnStatement);
            State.SetReturnType(Type);
        }
    }
}