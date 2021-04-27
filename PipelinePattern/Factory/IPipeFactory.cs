using PipelinePattern.Services;

namespace PipelinePattern.Factory
{
    public interface IPipeFactory<TPipeModel>
    {
        IPipeServiceExecution<TPipeModel> CreatePipe();
    }
}
