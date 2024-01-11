using LogicLayerClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interfaces
{
    public interface INewsletterStrategy
    {
        string StrategyIdentifier { get; }
        TimeSpan Interval { get; }
        void SendNewsletter();
    }
}
