using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class NewsletterBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private System.Timers.Timer _timer;

    public NewsletterBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _timer = new System.Timers.Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
        _timer.Elapsed += async (sender, e) => await SendNewsletterAsync();
        _timer.Start();

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken); // Delay to prevent high CPU usage
        }
    }

    private async Task SendNewsletterAsync()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var compositeNewsletterStrategy = scope.ServiceProvider.GetRequiredService<CompositeNewsletterStrategy>();
            compositeNewsletterStrategy.SendNewsletter();
            
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _timer?.Stop();
        await base.StopAsync(stoppingToken);
    }
}
