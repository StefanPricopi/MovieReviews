using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelLibrary.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class NewsletterBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILastExecutionTimesService _lastExecutionTimesService;

    public NewsletterBackgroundService(IServiceProvider serviceProvider, ILastExecutionTimesService lastExecutionTimesService)
    {
        _serviceProvider = serviceProvider;
        _lastExecutionTimesService = lastExecutionTimesService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var compositeNewsletterStrategy = scope.ServiceProvider.GetRequiredService<CompositeNewsletterStrategy>();

            foreach (var strategy in compositeNewsletterStrategy._strategies)
            {
                
                var timer = _lastExecutionTimesService.GetOrAddTimer(strategy, async (sender, e) => await SendNewsletterAsync(strategy));
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken); // Delay to prevent high CPU usage
            }
        }
    }

    private async Task SendNewsletterAsync(INewsletterStrategy strategy)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var compositeNewsletterStrategy = scope.ServiceProvider.GetRequiredService<CompositeNewsletterStrategy>();
            compositeNewsletterStrategy.SendNewsletter();
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await base.StopAsync(stoppingToken);
    }
}
