using System.Collections.Generic;
using PipelinePattern.Steps;

namespace PipelinePattern.Services
{
    public class PipeService<TPipeModel> : PipeServiceBase<TPipeModel>
    {
        protected override IEnumerable<IPipeStep<TPipeModel>> GetFinalSteps(IEnumerable<IPipeStep<TPipeModel>> steps, TPipeModel pipeModel)
        {
            return steps;
        }
    }
}

