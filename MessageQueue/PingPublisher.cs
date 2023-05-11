using MassTransit;

namespace MessageQueue
{
    public class PingPublisher : BackgroundService
    {
        private readonly ILogger<PingPublisher> _logger;
        private readonly IBus _bus;
        public PingPublisher(ILogger<PingPublisher> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken )
        {
           
           while(!stoppingToken.IsCancellationRequested) {

                await Task.Yield();

                var KeyPressed = Console.ReadKey(true);
                if(KeyPressed.Key != ConsoleKey.Escape)
                {
                    //_logger.LogInformation("Pressed {Button}",KeyPressed.Key.ToString());
                   await _bus.Publish(new Ping(KeyPressed.Key.ToString()));
                }

                await Task.Delay(200);
           }
        }
    }
}
