using StudySimulation.BLL.Abstract;
using StudySimulation.DAL;
using StudySimulation.DAL.Abstract;
using StudySimulation.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation.BLL.Subjects
{
    public class HigherMathematics : Subject
    {
        public HigherMathematics(GroupRating groupRating) : base(groupRating)
        {
        }
        public override int Credit(Group group)
        {
            MessageEventArgs message = new MessageEventArgs();
            message.text = name + " dont have a credit!";
            CallMessageEvent(this, message);
            return 0;
        }

        public override int Lab(Group group, Equipment equipment, Room room, ISubActivities subActivities)
        {
            MessageEventArgs message = new MessageEventArgs();
            message.text = name + " dont have a lab!";
            CallMessageEvent(this, message);
            return 0;
        }
    }
}
