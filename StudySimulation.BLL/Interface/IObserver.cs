using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation.BLL
{
    public interface IObserver
    {
        void Update(string text);
        void Update(string text, int state);
    }
}
