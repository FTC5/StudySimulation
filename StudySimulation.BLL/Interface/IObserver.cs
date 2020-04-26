using StudySimulation.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation.BLL
{
    public interface IObserver
    {
        void Update(object sender, MessageEventArgs eventArgs);
        void Update(object sender, EvaluationEventArgs eventArgs);
        void Update(object sender, SuccessFactorEventArgs eventArgs);
    }
}
