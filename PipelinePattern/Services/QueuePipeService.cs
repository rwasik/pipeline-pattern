using System.Collections.Generic;
using PipelinePattern.Extensions;
using PipelinePattern.Models;
using PipelinePattern.Steps;

namespace PipelinePattern.Services
{
    public class QueuePipeService<TPipeModel> : PipeServiceBase<TPipeModel> where TPipeModel : IQueuePipeModel
    {
        protected override IEnumerable<IPipeStep<TPipeModel>> GetFinalSteps(IEnumerable<IPipeStep<TPipeModel>> steps, TPipeModel pipeModel)
        {
            return steps.SkipUntil(s => !(s is IInQueuePipeStep<TPipeModel> && (s as IInQueuePipeStep<TPipeModel>).InQueueName == pipeModel.QueueName))
                        .TakeUntil(s => !(s is IOutQueuePipeStep<TPipeModel>));
        }
    }
}
