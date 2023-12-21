using Microsoft.Extensions.Hosting;

public class NewsletterBackgroundService : BackgroundService
{
    private readonly CompositeNewsletterStrategy _compositeNewsletterStrategy;
    private readonly int _intervalMinutes = 1; // Interval for sending newsletters in minutes
    private System.Timers.Timer _timer;

    public NewsletterBackgroundService(CompositeNewsletterStrategy compositeNewsletterStrategy)
    {
        _compositeNewsletterStrategy = compositeNewsletterStrategy;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _timer = new System.Timers.Timer(TimeSpan.FromMinutes(_intervalMinutes).TotalMilliseconds);
        _timer.Elapsed += async (sender, e) => await SendNewsletterAsync();
        _timer.Start();

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken); // Delay to prevent high CPU usage
        }
    }

    private async Task SendNewsletterAsync()
    {
        _compositeNewsletterStrategy.SendNewsletter();
        Console.WriteLine("Newsletter sent.");
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        // Stop the timer when the service is stopped
        _timer?.Stop();
        await base.StopAsync(stoppingToken);
    }
}
