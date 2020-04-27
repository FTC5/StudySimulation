using StudySimulation.BLL.Abstract;
using StudySimulation.DAL;
using StudySimulation.DAL.Abstract;
using StudySimulation.DAL.Equipments;
using StudySimulation.DAL.Interface;
using StudySimulation.DAL.SubActivities;
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
        public override int Practice(Group group, Equipment equipment, ISubActivities subActivities)
        {
            MessageEventArgs message = new MessageEventArgs();
            SuccessFactorEventArgs factor = new SuccessFactorEventArgs();
            bool CheckAct()
            {
                if (subActivities is ReadText)
                {
                    return true;
                }
                else if (subActivities is TellText)
                {
                    return true;
                }
                else if (subActivities is WriteText)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (subActivities == null)
            {
                message.text = "Students do nothing, it is impossible to conduct classes";
                CallMessageEvent(this, message);
                return 0;
            }
            else if (!CheckAct())
            {
                message.text = "Students perform the wrong actions, it is impossible to conduct classes";
                CallMessageEvent(this, message);
                return 0;
            }
            else if(!(equipment is TapeRecorder))
            {
                message.text = "We dont have TapeRecorder, it is impossible to conduct classes";
                CallMessageEvent(this, message);
                return 0;
            }
            
            successFactor = 0;
            message.text = "Practice start : ";
            CallMessageEvent(this, message);
            successFactor += CheckEquipment(equipment);
            successFactor += 1;
            factor.text = subActivities.Action() + ".Student success factor: ";
            factor.successFactor = successFactor;
            CallFactorEvent(this, factor);
            message.text = "Students study";
            CallMessageEvent(this, message);
            groupRating.SetGroupGrades(group, name);
            return successFactor;
        }
    }
}
