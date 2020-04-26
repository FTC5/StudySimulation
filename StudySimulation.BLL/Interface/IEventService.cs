using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation.BLL
{
    public interface IEventService
    {
        //Subscribe* methods returns false if the subscription exists otherwise, true
        bool SubscribeToGetPoints(IObserver observer);
        void UnSubscribeToGetPoints(IObserver observer);
        bool SubscribeToMessage(IObserver observer);
        void UnSubscribeToMessage(IObserver observer);
        bool SubscribeToSuccessFactor(IObserver observer);
        void UnSubscribeToSuccessFactor(IObserver observer);
    }
}
