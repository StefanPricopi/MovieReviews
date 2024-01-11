using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.Interfaces;

using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.Interfaces;

public class CompositeNewsletterStrategy : INewsletterStrategy
{
    public readonly List<INewsletterStrategy> _strategies;
    private readonly UserProfileManager _userPreferencesService;
    private readonly ILastExecutionTimesService _lastExecutionTimesService;

    public string StrategyIdentifier => "Composite";

    public CompositeNewsletterStrategy(List<INewsletterStrategy> strategies, UserProfileManager userProfileManager, ILastExecutionTimesService lastExecutionTimesService)
    {
        _strategies = strategies;
        _userPreferencesService = userProfileManager;
        _lastExecutionTimesService = lastExecutionTimesService;
    }

    public void SendNewsletter()
    {
        List<string> userPreferences = _userPreferencesService.GetUserNewsletterPreferences(5);
        List<INewsletterStrategy> selectedStrategies = _strategies
            .Where(strategy => userPreferences.Contains(strategy.StrategyIdentifier))
            .ToList();
        foreach (var strategy in selectedStrategies)
        {
            if (ShouldExecute(strategy))
            {
                Console.WriteLine($"Executing strategy: {strategy.StrategyIdentifier}");
                strategy.SendNewsletter();
                _lastExecutionTimesService.UpdateLastExecutionTime(strategy, DateTime.UtcNow);
            }
        }
    }

    private bool ShouldExecute(INewsletterStrategy strategy)
    {
        DateTime lastExecutionTime = _lastExecutionTimesService.GetLastExecutionTime(strategy);

        Console.WriteLine($"Last execution time for strategy {strategy.StrategyIdentifier}: {lastExecutionTime}");

        if (strategy.Interval == TimeSpan.Zero)
        {
            return false; 
        }

        TimeSpan interval = DateTime.UtcNow - lastExecutionTime;
        if (strategy.Interval == TimeSpan.FromDays(1) && DateTime.UtcNow.Date == lastExecutionTime.Date)
        {
            return false; 
        }
        else if (strategy.Interval == TimeSpan.FromDays(7) && interval.TotalDays < 7)
        {
            return false; 
        }
        else if (strategy.Interval == TimeSpan.FromSeconds(60) && interval < TimeSpan.FromSeconds(60))
        {
            return false; 
        }

        return interval >= strategy.Interval;
    }







    public TimeSpan Interval
    {
        
        get
        {
            var strategiesWithInterval = _strategies.Where(strategy => strategy.Interval > TimeSpan.Zero);

            if (!strategiesWithInterval.Any())
            {
                return TimeSpan.Zero;
            }

            return TimeSpan.FromMilliseconds(strategiesWithInterval.Min(strategy =>
                (DateTime.UtcNow - _lastExecutionTimesService.GetLastExecutionTime(strategy)).TotalMilliseconds));
        }
    }
}
