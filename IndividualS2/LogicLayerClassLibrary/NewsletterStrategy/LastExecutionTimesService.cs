using ModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LogicLayerClassLibrary.NewsletterStrategy
{
    public class LastExecutionTimesService : ILastExecutionTimesService
    {
        private readonly Dictionary<INewsletterStrategy, (DateTime LastExecutionTime, System.Timers.Timer Timer)> _strategyInfo =
        new Dictionary<INewsletterStrategy, (DateTime, System.Timers.Timer)>();
        private readonly Dictionary<INewsletterStrategy, System.Timers.Timer> _strategyTimers = new Dictionary<INewsletterStrategy, System.Timers.Timer>();

        public System.Timers.Timer GetOrAddTimer(INewsletterStrategy strategy, ElapsedEventHandler elapsedEventHandler)
        {
            if (_strategyTimers.TryGetValue(strategy, out var existingTimer))
            {
                return existingTimer;
            }

            var newTimer = new System.Timers.Timer(strategy.Interval.TotalMilliseconds);
            newTimer.Elapsed += elapsedEventHandler;
            newTimer.Start();

            _strategyTimers[strategy] = newTimer;

            // Add an entry for the strategy in the _strategyInfo dictionary
            _strategyInfo[strategy] = (DateTime.UtcNow, newTimer);

            // Log timer creation
            Console.WriteLine($"Timer created for {strategy.StrategyIdentifier}");

            return newTimer;
        }

        // If you have a method to dispose or stop timers, you can log it there
        public void DisposeTimer(INewsletterStrategy strategy)
        {
            if (_strategyTimers.TryGetValue(strategy, out var timer))
            {
                // Stop the timer
                timer.Stop();

                // Dispose the timer (if applicable)
                timer.Dispose();

                // Log timer disposal
                Console.WriteLine($"Timer disposed for {strategy.StrategyIdentifier}");
            }
            else
            {
                Console.WriteLine($"Timer not found for {strategy.StrategyIdentifier}");
            }
        }

        public DateTime GetLastExecutionTime(INewsletterStrategy strategy)
        {
            if (_strategyInfo.TryGetValue(strategy, out var info))
            {
                Console.WriteLine($"GetLastExecutionTime for {strategy.StrategyIdentifier}: {info.LastExecutionTime}");
                return info.LastExecutionTime;
            }

            Console.WriteLine($"GetLastExecutionTime for {strategy.StrategyIdentifier}: No last execution time found");
            return default(DateTime); // or throw an exception if you prefer
        }

        public void UpdateLastExecutionTime(INewsletterStrategy strategy, DateTime lastExecutionTime)
        {
            if (_strategyInfo.TryGetValue(strategy, out var info))
            {
                // Update both the last execution time and the timer
                _strategyInfo[strategy] = (lastExecutionTime, info.Timer);
            }
            else
            {
                Console.WriteLine($"Strategy not found: {strategy.StrategyIdentifier}");
            }

            Console.WriteLine($"UpdateLastExecutionTime for {strategy.StrategyIdentifier}: {lastExecutionTime}");
        }



        public void SetTimer(INewsletterStrategy strategy, System.Timers.Timer timer)
        {
            _strategyInfo[strategy] = (_strategyInfo[strategy].LastExecutionTime, timer);
        }

        // Optionally, you may want a method to get the timer for a strategy if needed
        public System.Timers.Timer GetTimer(INewsletterStrategy strategy)
        {
            return _strategyInfo[strategy].Timer;
        }
    }



}
