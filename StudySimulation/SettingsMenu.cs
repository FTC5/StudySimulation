using StudySimulation.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation
{
    class SettingsMenu
    {
        IObserver observer;
        IEventService eventService;
        ISubscribeSwitch subscribeSwitch;

        public SettingsMenu(IObserver observer, IEventService eventService)
        {
            this.observer = observer;
            this.eventService = eventService;
            subscribeSwitch = new Settings(observer, eventService);
        }

        public void SetSettings()
        {
            void Message(string message, bool result)
            {
                if (result == false)
                {
                    Console.WriteLine("On " + message);
                }
                else
                {
                    Console.WriteLine("Off " + message);
                }
            }
            while (true)
            {
                Message("Educational factor: 1", subscribeSwitch.EducationalFactor);
                Message("Educational message: 2", subscribeSwitch.EducationalMes);
                Message("Student information: 3", subscribeSwitch.StudentInfo);
                Console.WriteLine("All change : 4");
                Console.WriteLine("Exit : other symbols");
                switch (Console.ReadLine())
                {
                    case "1":
                        subscribeSwitch.EducationalFactorInfoSwitch();
                        break;
                    case "2":
                        subscribeSwitch.EducationalMesSwitch();
                        break;
                    case "3":
                        subscribeSwitch.StudentInfoSwitch();
                        break;
                    case "4":
                        subscribeSwitch.EducationalFactorInfoSwitch();
                        subscribeSwitch.EducationalMesSwitch();
                        subscribeSwitch.StudentInfoSwitch();
                        break;
                    default:
                        return;
                }
            }

        }
    }
}
