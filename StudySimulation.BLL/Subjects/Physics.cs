
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
    public class Physics : Subject
    {
        public Physics(GroupRating groupRating) : base(groupRating)
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
            message.text = "Lab start : \n";

            if (room.Name != "Laboratory")
            {
                message.text += "Students cannot study. They dont have laboratory";
                CallMessageEvent(this, message);
                return 0;
            }
            else if (subActivities == null)
            {
                message.text += "Students nothing to do";
                CallMessageEvent(this, message);
                return 0;
            }
            if (subActivities.ToString() != "Perform experiment")
            {
                SuccessFactorEventArgs factor = new SuccessFactorEventArgs();
                successFactor += -3;
                factor.text = subActivities.Action() + ".Student success factor: ";
                factor.successFactor = successFactor;
                CallFactorEvent(this, factor);
            }
            message.text += subActivities.Action() + "\n";
            successFactor += CheckEquipment(equipment);
            message.text += "Students study";
            CallMessageEvent(this, message);
            return successFactor;
        }
    }
}
