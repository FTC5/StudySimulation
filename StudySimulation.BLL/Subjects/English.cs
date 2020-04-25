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
    public class English : Subject
    {
        public English(GroupRating groupRating) : base(groupRating)
        {
        }

        public override int Credit(Group group)
        {
            MessageEventArgs message = new MessageEventArgs();
            message.text = "Ooo Students have credit: /nstudents receive grades";
            CallMessageEvent(this, message);
            groupRating.SetAverageMark(group, name);
            return 0;
        }

        public override int Lab(Group group, Equipment equipment, Room room, ISubActivities subActivities)
        {
            MessageEventArgs message = new MessageEventArgs();
            message.text = name + " dont have a lab!";
            CallMessageEvent(this, message);
            return 0;
        }

        public override int Lectures(List<Group> groups, Equipment equipment)
        {
            MessageEventArgs message = new MessageEventArgs();
            message.text = name + " dont have a lectures!";
            CallMessageEvent(this, message);
            return 0;
        }

        public override int TermPaper(Group group, Equipment equipment)
        {
            MessageEventArgs message = new MessageEventArgs();
            message.text = name + " dont have a term paper!";
            CallMessageEvent(this, message);
            return 0;
        }
    }
}
