using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PipelinePattern.Steps;

namespace PipelinePattern.Services
{
    public class PipeService<TPipeModel> : IPipeService<TPipeModel>
    {
        private readonly IList<Func<IPipeStep<TPipeModel>>> _pipeSteps;

        public PipeService()
        {
            _pipeSteps = new List<Func<IPipeStep<TPipeModel>>>();
        }

        public IPipeService<TPipeModel> Add(Func<IPipeStep<TPipeModel>> pipeStep)
        {
            _pipeSteps.Add(pipeStep);
            return this;
        }

        public async Task ExecuteAsync(TPipeModel pipeModel)
        {
            foreach (var pipeStep in _pipeSteps)
            {
                await pipeStep.Invoke().ExecuteAsync(pipeModel);
            }
        }
    }
}
