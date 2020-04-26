using StudySimulation.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation.BLL
{
    public class EventManager : IEventService
    {
        Dictionary<string,List<IObserver>> eventObserver=new Dictionary<string, List<IObserver>>();
        GroupRating groupRating;
        List<Subject> subjects;

        public EventManager(GroupRating groupRating, List<Subject> subjects)
        {
            this.groupRating = groupRating;
            this.subjects = subjects;
        }
        public EventManager(IUniversity university)
        {
            this.groupRating = university.GroupRating;
            this.subjects = university.Subjects;
        }
        private bool Subscribe(string key, IObserver observer)
        {
            if (eventObserver[key].Contains(observer))
            {
                return false;
            }
            eventObserver[key].Add(observer);
            return true;
        }
        private void UnSubscribe(string key, IObserver observer)
        {
            eventObserver[key].Remove(observer);
        }
        public bool SubscribeToGetPoints(IObserver observer)
        {
            string key = "getPoints";
            groupRating.GetEvaluation += (source, arg) => observer.Update(arg.text);
            return Subscribe(key,observer);
        }
        public void UnSubscribeToGetPoints(IObserver observer)
        {

            string key = "getPoints";
            groupRating.GetEvaluation -= (source, arg) => observer.Update(arg.text);
            UnSubscribe(key, observer);
        }
        public bool SubscribeToMessage(IObserver observer)
        {
            string key = "message";
            foreach (Subject item in subjects)
            {
                item.Message+= (source, arg) => observer.Update(arg.text);
            }
            return Subscribe(key, observer);
        }
        public void UnSubscribeToMessage(IObserver observer)
        {
            string key = "message";
            foreach (Subject item in subjects)
            {
                item.Message -= (source, arg) => observer.Update(arg.text);
            }
            UnSubscribe(key, observer);
        }
        public bool SubscribeToSuccessFactor(IObserver observer)
        {
            string key = "successFactor";
            foreach (Subject item in subjects)
            {
                item.Factor += (source, arg) => observer.Update(arg.text,arg.successFactor);
            }
            return Subscribe(key, observer);
        }
        public void UnSubscribeToSuccessFactor(IObserver observer)
        {
            string key = "successFactor";
            foreach (Subject item in subjects)
            {
                item.Factor -= (source, arg) => observer.Update(arg.text, arg.successFactor);
            }
            UnSubscribe(key, observer);
        }
    }
}
