using PipelinePattern.Models;

namespace PipelinePattern.Steps
{
    public interface IInQueuePipeStep<TPipeModel> : IPipeStep<TPipeModel> where TPipeModel : IInQueuePipeModel
    {
        string InQueueName { get; }
    }
}
