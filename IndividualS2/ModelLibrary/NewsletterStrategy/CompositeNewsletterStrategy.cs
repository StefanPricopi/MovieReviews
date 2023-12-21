using ModelLibrary.Interfaces;

public class CompositeNewsletterStrategy : INewsletterStrategy
{
    private readonly IEnumerable<INewsletterStrategy> _strategies;

    public CompositeNewsletterStrategy(IEnumerable<INewsletterStrategy> strategies)
    {
        _strategies = strategies;
    }

    public void SendNewsletter()
    {
        foreach (var strategy in _strategies)
        {
            strategy.SendNewsletter();
        }
    }
}
