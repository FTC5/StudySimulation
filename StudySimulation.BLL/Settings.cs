using StudySimulation.BLL.Abstract;
using static StudySimulation.BLL.Abstract.GroupRating;
using static StudySimulation.BLL.Abstract.Subject;

namespace StudySimulation.BLL
{
    public class Settings : ISubscribeSwitch
    {
        IObserver observer;
        IEventService eventService;
        bool studentInfo = false;
        bool educationalMes = false;
        bool educationalFactor = false;

        public Settings(IObserver observer, IEventService eventService)
        {
            this.observer = observer;
            this.eventService = eventService;
            CheakAllSubscribe(observer, eventService);
        }

        public bool StudentInfo { get => studentInfo;}
        public bool EducationalMes { get => educationalMes;}
        public bool EducationalFactor { get => educationalFactor;}

        public void StudentInfoSwitch()
        {
            if (studentInfo)
            {
                eventService.UnSubscribeToGetPoints(observer);
            }
            else
            {
                eventService.SubscribeToGetPoints(observer);
            }
            studentInfo = !studentInfo;
        }

        public void EducationalMesSwitch()
        {
            if (EducationalMes)
            {
                eventService.UnSubscribeToMessage(observer);
            }
            else
            {
                eventService.SubscribeToMessage(observer);
            }
            educationalMes = !educationalMes;
        }

        public void EducationalFactorInfoSwitch()
        {
            if (EducationalFactor)
            {
                eventService.UnSubscribeToSuccessFactor(observer);
            }
            else
            {
                eventService.SubscribeToSuccessFactor(observer);
            }
            educationalFactor = !educationalFactor;

        }
        private void CheakAllSubscribe(IObserver observer, IEventService eventService)
        {
            studentInfo = eventService.SubscribeToGetPoints(observer);
            educationalMes = eventService.SubscribeToMessage(observer);
            educationalFactor = eventService.SubscribeToSuccessFactor(observer);
            if (studentInfo)
            {
                StudentInfoSwitch();
            }
            else
            {
                studentInfo = !studentInfo;
            }
            if (educationalMes)
            {
                EducationalMesSwitch();
            }
            else
            {
                educationalMes = !educationalMes;
            }
            if (educationalFactor)
            {
                EducationalFactorInfoSwitch();
            }
            else
            {
                educationalFactor = !educationalFactor;
            }
        }
    }
}
