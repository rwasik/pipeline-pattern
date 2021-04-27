using PipelinePattern.Models;

namespace PipelinePattern.Steps
{
    public interface IInQueuePipeStep<TPipeModel> : IPipeStep<TPipeModel> where TPipeModel : IQueuePipeModel
    {
        string InQueueName { get; }
    }
}
