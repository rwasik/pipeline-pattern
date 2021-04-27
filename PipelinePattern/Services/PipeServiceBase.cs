using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PipelinePattern.Steps;

namespace PipelinePattern.Services
{
    public abstract class PipeServiceBase<TPipeModel> : IPipeService<TPipeModel>
    {
        protected readonly IList<Func<IPipeStep<TPipeModel>>> _pipeSteps;
        protected readonly IList<Func<IPipeStep<TPipeModel>>> _errorSteps;

        protected abstract IEnumerable<IPipeStep<TPipeModel>> GetFinalSteps(IEnumerable<IPipeStep<TPipeModel>> steps, TPipeModel pipeModel);

        protected PipeServiceBase()
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
                var steps = GetInitializedSteps();

                steps = GetFinalSteps(steps, pipeModel);

                foreach (var pipeStep in steps)
                {
                    await pipeStep.ExecuteAsync(pipeModel);
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

        private IEnumerable<IPipeStep<TPipeModel>> GetInitializedSteps()
        {
            return _pipeSteps.Select(s => s.Invoke());
        }
    }
}
