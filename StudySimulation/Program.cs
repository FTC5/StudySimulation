using StudySimulation.BLL;
using StudySimulation.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            IUniversity university = new University();
            IService service = new Service(university);
            IInfoService infoService = new InfoService(university);
            IEventService eventService = new EventManager(university.GroupRating,university.Subjects);
            Menu menu = new Menu(service,infoService, eventService);
            menu.MainMenu();
        }
        
    }
}
