using InternetServices.SocketServer.Classes;

namespace InternetServices.SocketServer.Services
{
    public class SocketService : BackgroundService
    {
        private readonly ILogger<SocketService> Logger;

        public SocketService(ILogger<SocketService> logger)
        {
            this.Logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var server = new TCPServer();

            while (!stoppingToken.IsCancellationRequested)
            {
                this.Logger.LogInformation($"The Socket is running now {DateTime.Now}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
