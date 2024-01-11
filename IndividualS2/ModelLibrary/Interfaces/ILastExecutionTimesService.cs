using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ModelLibrary.Interfaces
{
    public interface ILastExecutionTimesService
    {
        DateTime GetLastExecutionTime(INewsletterStrategy strategy);
        void UpdateLastExecutionTime(INewsletterStrategy strategy, DateTime executionTime);
        System.Timers.Timer GetOrAddTimer(INewsletterStrategy strategy, ElapsedEventHandler elapsedEventHandler);
    }
}
