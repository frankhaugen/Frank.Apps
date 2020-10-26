using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frank.Apps.WorkflowEngine
{
    public interface IStep<T, TOut>
    {
        public Connection<TOut> Connection { get; set; }

        bool Execute(T input);
    }

    public class dsgraerhWorkflow<T>
    {
        public ITrigger<T> Trigger { get; set; }
        public IList<Connection<T>> Connections { get; set; }
    }

    public interface ITrigger<T>
    {
        public Connection<T> Connection { get; }
        string? CollectData();
    }

    public class Connection<T>
    {
        public Connection(T data)
        {
            _data = data;
            //_step = step;
        }
        private readonly T _data;
        //private readonly IStep<T, TOut> _step;
        public T GetOutput() => _data;
    }

    public interface ICondition
    {
        public Task<bool> EvaluateCondition();
    }

    public class IsOldEnough : ICondition
    {
        /// <inheritdoc />
        public Task<bool> EvaluateCondition() => null;
    }
}
