using ModelLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public class NewsletterManager
    {
        private List<INewsletterStrategy> _strategies;

        public NewsletterManager()
        {
            _strategies = new List<INewsletterStrategy>();
        }

        public void AddStrategy(INewsletterStrategy strategy)
        {
            _strategies.Add(strategy);
        }

        public void RemoveStrategy(INewsletterStrategy strategy)
        {
            _strategies.Remove(strategy);
        }

        public void ExecuteNewsletterSending()
        {
            foreach (var strategy in _strategies)
            {
                strategy.SendNewsletter();
            }
        }
    }
}
