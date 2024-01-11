using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.Interfaces;

public class CompositeNewsletterStrategy : INewsletterStrategy
{
    private readonly List<INewsletterStrategy> _strategies;
    private readonly UserProfileManager _userPreferencesService;
    public string StrategyIdentifier => "Composite";

    public CompositeNewsletterStrategy(List<INewsletterStrategy> strategies,UserProfileManager userProfileManager)
    {
        _strategies = strategies;
        _userPreferencesService = userProfileManager;
    }

    public void SendNewsletter()
    {
        // Retrieve user preferences from the service
        List<string> userPreferences = _userPreferencesService.GetUserNewsletterPreferences(5);

        // Use user preferences to filter the strategies
        List<INewsletterStrategy> selectedStrategies = _strategies
    .Where(strategy => userPreferences.Contains(strategy.StrategyIdentifier))
    .ToList();

        // Send newsletters using the selected strategies
        foreach (var strategy in selectedStrategies)
        {
            strategy.SendNewsletter();
        }
    }
}


