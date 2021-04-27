using System.Threading.Tasks;

namespace PipelinePattern.Steps
{
    public interface IPipeStep<TPipeModel>
    {
        Task ExecuteAsync(TPipeModel pipeModel);
    }
}
