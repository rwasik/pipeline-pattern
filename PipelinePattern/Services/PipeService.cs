using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PipelinePattern.Steps;

namespace PipelinePattern.Services
{
    public class PipeService<TPipeModel> : IPipeService<TPipeModel>
    {
        private readonly IList<Func<IPipeStep<TPipeModel>>> _pipeSteps;
        private readonly IList<Func<IPipeStep<TPipeModel>>> _errorSteps;

        public PipeService()
        {
            _pipeSteps = new List<Func<IPipeStep<TPipeModel>>>();
            _errorSteps = new List<Func<IPipeStep<TPipeModel>>>();
        }

        public IPipeService<TPipeModel> Add(Func<IPipeStep<TPipeModel>> pipeStep)
        {
            _pipeSteps.Add(pipeStep);
            return this;
        }

        public IPipeService<TPipeModel> AddErrorStep(Func<IPipeStep<TPipeModel>> errorStep)
        {
            _errorSteps.Add(errorStep);
            return this;
        }

        public async Task ExecuteAsync(TPipeModel pipeModel)
        {
            try
            {
                foreach (var pipeStep in _pipeSteps)
                {
                    await pipeStep.Invoke().ExecuteAsync(pipeModel);
                }
            }
            catch (Exception ex)
            {
                foreach (var errorStep in _errorSteps)
                {
                    await errorStep.Invoke().ExecuteAsync(pipeModel);
                }
                throw ex;
            }
        }
    }
}
