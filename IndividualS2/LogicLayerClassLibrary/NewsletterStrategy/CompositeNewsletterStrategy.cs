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
        // Retrieve user preferences from the service
        List<string> userPreferences = _userPreferencesService.GetUserNewsletterPreferences(5);

        // Use user preferences to filter the strategies
        List<INewsletterStrategy> selectedStrategies = _strategies
            .Where(strategy => userPreferences.Contains(strategy.StrategyIdentifier))
            .ToList();

        // Check if the time interval has elapsed for each strategy
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
            return false; // Strategy with zero interval should not execute
        }

        TimeSpan interval = DateTime.UtcNow - lastExecutionTime;

        // Check specific logic for different intervals
        if (strategy.Interval == TimeSpan.FromDays(1) && DateTime.UtcNow.Date == lastExecutionTime.Date)
        {
            return false; // Daily strategy: execute only if it's a new day
        }
        else if (strategy.Interval == TimeSpan.FromDays(7) && interval.TotalDays < 7)
        {
            return false; // Weekly strategy: execute only if at least a week has passed
        }
        else if (strategy.Interval == TimeSpan.FromSeconds(60) && interval < TimeSpan.FromSeconds(60))
        {
            return false; // Every 60 seconds strategy: execute only if it's at least 60 seconds later
        }

        // For other intervals, use the original logic
        return interval >= strategy.Interval;
    }







    public TimeSpan Interval
    {
        // Return the minimum interval among the selected strategies
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
