using PipelinePattern.Models;

namespace PipelinePattern.Steps
{
    public interface IOutQueuePipeStep<TPipeModel> : IPipeStep<TPipeModel> where TPipeModel : IInQueuePipeModel
    {
    }
}
