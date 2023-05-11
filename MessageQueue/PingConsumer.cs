using MassTransit;

namespace MessageQueue
{
    public class PingConsumer : IConsumer<Ping>
    {

        private readonly ILogger<Ping> _logger;
        public PingConsumer(ILogger<Ping> logger)
        {
            _logger = logger;
        }
    
        public Task Consume(ConsumeContext<Ping> context)
        {
            var button = context.Message.Button;
            _logger.LogInformation("Button Pressed {Button}",button);
            return Task.CompletedTask;
        }
    }
}
