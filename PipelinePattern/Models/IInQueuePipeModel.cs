namespace PipelinePattern.Models
{
    public interface IInQueuePipeModel
    {
        string QueueName { get; set; }
        string InMessage { get; set; }
    }
}
