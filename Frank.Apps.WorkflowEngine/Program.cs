using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Frank.Apps.WorkflowEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var workflow = new TransformStringToCharactersWorkflow();


            Console.WriteLine("Hello World!");
        }
    }

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class CreateUser : StepBody
    {
        public readonly User _user;

        public CreateUser(string name, int age)
        {
            _user = new User()
            {
                Name = name,
                Age = age
            };
        }

        /// <inheritdoc />
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }

    class TransformStringToCharactersWorkflow : IWorkflow
    {
        /// <inheritdoc />
        public void Build(IWorkflowBuilder<object> builder)
        {
            builder.StartWith<CreateUser>();
        }

        /// <inheritdoc />
        public string Id { get; }

        /// <inheritdoc />
        public int Version { get; }
    }

    //class ManualTrigger : ITrigger<string>
    //{
    //    public ManualTrigger(IConnection<string> connection) => Connection = connection;

    //    /// <inheritdoc />
    //    public IConnection<string> Connection { get; }

    //    /// <inheritdoc />
    //    public string? CollectData() => Console.ReadLine();
    //}
}
