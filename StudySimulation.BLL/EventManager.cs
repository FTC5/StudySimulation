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
        string[] key= { "getPoints", "message", "successFactor" };

        public EventManager(GroupRating groupRating, List<Subject> subjects)
        {
            this.groupRating = groupRating;
            this.subjects = subjects;
            for (int i = 0; i < key.Length; i++)
            {
                eventObserver.Add(key[i], new List<IObserver>());
            }
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
           
            if (Subscribe(key[0], observer))//key[0]->getPoints
            {
                groupRating.GetEvaluation += observer.Update;
                return true;
            }
            return false;

        }
        public void UnSubscribeToGetPoints(IObserver observer)
        {

            groupRating.GetEvaluation -= observer.Update;
            UnSubscribe(key[0], observer);//key[0]->getPoints
        }
        public bool SubscribeToMessage(IObserver observer)
        {
            if (Subscribe(key[1], observer))//key[1]->message
            {
                foreach (Subject item in subjects)
                {
                    item.Message += observer.Update;
                }
                return true;
            }
            return false;
        }
        public void UnSubscribeToMessage(IObserver observer)
        {
            foreach (Subject item in subjects)
            {
                item.Message -= observer.Update;
            }
            UnSubscribe(key[1], observer);//key[1]->message
        }
        public bool SubscribeToSuccessFactor(IObserver observer)
        {
            if (Subscribe(key[2], observer))//key[2]->successFactor/key[1]->message
            {
                foreach (Subject item in subjects)
                {
                    
                    item.Factor += observer.Update; 
                }
                return true;
            }
            return false;
        }
        public void UnSubscribeToSuccessFactor(IObserver observer)
        {
            foreach (Subject item in subjects)
            {
                item.Factor -= observer.Update;
            }
            UnSubscribe(key[2], observer);//key[2]->successFactor
        }
    }
}
