using System;
using PipelinePattern.Steps;

namespace PipelinePattern.Services
{
    public interface IPipeService<TPipeModel> : IPipeServiceExecution<TPipeModel>
    {
        IPipeService<TPipeModel> Add(Func<IPipeStep<TPipeModel>> pipeStep);
    }
}
