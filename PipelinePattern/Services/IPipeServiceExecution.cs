using System.Threading.Tasks;

namespace PipelinePattern.Services
{
    public interface IPipeServiceExecution<TPipeModel>
    {
        Task ExecuteAsync(TPipeModel pipeModel);
    }
}
