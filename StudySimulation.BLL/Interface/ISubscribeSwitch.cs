using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation.BLL
{
    public interface ISubscribeSwitch
    {
        bool StudentInfo { get; }
        bool EducationalMes { get; }
        bool EducationalFactor { get; }
        void StudentInfoSwitch();
        void EducationalMesSwitch();
        void EducationalFactorInfoSwitch();
    }
}
