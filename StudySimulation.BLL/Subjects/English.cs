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
            CallMessageEvent("Ooo Students have credit: ");
            CallMessageEvent("students receive grades");
            groupRating.SetAverageMark(group, name);
            return 0;
        }

        public override int Lab(Group group, Equipment equipment, Room room, ISubActivities subActivities)
        {
            CallMessageEvent(name + " dont have a lab!");
            return 0;
        }

        public override int Lectures(List<Group> groups, Equipment equipment)
        {
            CallMessageEvent(name + " dont have a lectures!");
            return 0;
        }

        public override int TermPaper(Group group, Equipment equipment)
        {
            CallMessageEvent(name + " dont have a term paper!");
            return 0;
        }
    }
}
