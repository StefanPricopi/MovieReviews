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
            _strategyInfo[strategy] = (DateTime.UtcNow, newTimer);
            Console.WriteLine($"Timer created for {strategy.StrategyIdentifier}");
            return newTimer;
        }

       

        public DateTime GetLastExecutionTime(INewsletterStrategy strategy)
        {
            if (_strategyInfo.TryGetValue(strategy, out var info))
            {
                Console.WriteLine($"GetLastExecutionTime for {strategy.StrategyIdentifier}: {info.LastExecutionTime}");
                return info.LastExecutionTime;
            }

            Console.WriteLine($"GetLastExecutionTime for {strategy.StrategyIdentifier}: No last execution time found");
            return default(DateTime); 
        }

        public void UpdateLastExecutionTime(INewsletterStrategy strategy, DateTime lastExecutionTime)
        {
            if (_strategyInfo.TryGetValue(strategy, out var info))
            {
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

        
        public System.Timers.Timer GetTimer(INewsletterStrategy strategy)
        {
            return _strategyInfo[strategy].Timer;
        }
    }



}
