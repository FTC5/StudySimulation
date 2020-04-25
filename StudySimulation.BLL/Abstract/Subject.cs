using StudySimulation.DAL;
using StudySimulation.DAL.Abstract;
using StudySimulation.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudySimulation.BLL.Abstract
{
    public class MessageEventArgs : EventArgs
    {
        public string text;
    }
    public class SuccessFactorEventArgs : EventArgs
    {
        public string text;
        public int successFactor;
    }
    public delegate void SuccessFactorHandler(object source, SuccessFactorEventArgs arg);
    public delegate void MessageHandler(object source, MessageEventArgs arg);
    public abstract class Subject
    {
        public event SuccessFactorHandler Factor;
        public event MessageHandler Message;
        public GroupRating groupRating;
        protected string name;
        protected int successFactor = 0;

        public Subject(GroupRating groupRating)
        {
            this.groupRating = groupRating;
            name = this.GetType().Name;
        }

        public abstract int Lab(Group group, Equipment equipment, Room room, ISubActivities subActivities);
        public abstract int Credit(Group group);
        protected void CallFactorEvent(object source, SuccessFactorEventArgs arg)
        {
            Factor?.Invoke(source, arg);
        }
        protected void CallMessageEvent(object source, MessageEventArgs arg)
        {
            Message?.Invoke(source, arg);
        }
        protected virtual int CheckEquipment(Equipment equipment)
        {
            SuccessFactorEventArgs factor = new SuccessFactorEventArgs();
            if (equipment != null)
            {
                if (equipment.Name == "Computer")
                {
                    successFactor += 3;
                    factor.text = "Students use computer. Student success factor: ";
                    factor.successFactor = successFactor;
                    Factor?.Invoke(this,factor);
                }
                if (equipment.Name == "Tape recorder")
                {
                    successFactor += -1;
                    factor.text = "Teacher use tape recorder. Student success factor: ";
                    factor.successFactor = successFactor;
                    Factor?.Invoke(this, factor);
                }
            }
            return successFactor;
        }
        protected bool neglectCheack(Student student)
        {
            List<int> evaluations;
            evaluations = student.Evaluations[name];
            foreach (int item in evaluations)
            {
                if (item == 0)
                {
                    return false;
                }
            }
            return true;

        }
        public virtual int Examination(Group group,Equipment equipment)
        {
            MessageEventArgs message = new MessageEventArgs();
            successFactor = 0;
            message.text = "Examination start (-_-): ";
            Message?.Invoke(this,message);
            successFactor += CheckEquipment(equipment);
            message.text = "Students write the exam";
            Message?.Invoke(this, message);
            foreach (Student student in group.Students)
            {
                if(neglectCheack(student)==true)
                {
                    groupRating.Neglect(student, name);
                }
                else
                {
                    groupRating.SetGrades(student, name, group.Students.Count, successFactor);
                }
            }
            return successFactor;
        }
        public virtual int Lectures(List<Group> groups, Equipment equipment)
        {
            MessageEventArgs message = new MessageEventArgs();
            successFactor = 0;
            message.text = "Lectures start : ";
            Message?.Invoke(this,message);
            successFactor += CheckEquipment(equipment);
            message.text = "Students study";
            Message?.Invoke(this, message);
            foreach (Group group in groups)
            {
                groupRating.SetRandGroupGrade(group, name);
            }  
            return successFactor;
        }
        public virtual int ModulControlWork(Group group, Equipment equipment)
        {
            MessageEventArgs message = new MessageEventArgs();
            successFactor = 0;
            message.text = "Modul control work start (-_-): ";
            Message?.Invoke(this, message);
            successFactor += CheckEquipment(equipment);
            message.text = "Students write the modul control work";
            Message?.Invoke(this, message);
            foreach (Student student in group.Students)
            {
                if (neglectCheack(student) == true)
                {
                    groupRating.Neglect(student, name);
                }
                else
                {
                    groupRating.SetGrades(student, name, group.Students.Count, successFactor);
                }
            }
            return successFactor;
        }
        public virtual int Practice(Group group, Equipment equipment, ISubActivities subActivities)
        {
            MessageEventArgs message = new MessageEventArgs();
            successFactor = 0;
            message.text = "Practice start : ";
            Message?.Invoke(this, message);
            successFactor += CheckEquipment(equipment);
            if (subActivities != null)
            {
                SuccessFactorEventArgs factor = new SuccessFactorEventArgs();
                successFactor += 1;      
                factor.text = subActivities.Action() + ".Student success factor: ";
                factor.successFactor = successFactor;
                Factor?.Invoke(this, factor);
            }
            message.text = "Students study";
            Message?.Invoke(this, message);
            groupRating.SetGroupGrades(group, name);
            return successFactor;
        }
        public virtual int TermPaper(Group group, Equipment equipment)
        {
            MessageEventArgs message = new MessageEventArgs();
            successFactor = 0;
            message.text = "TermPaper start: \nStudents defend coursework";
            Message?.Invoke(this, message);
            successFactor += CheckEquipment(equipment);
            groupRating.SetGroupGrades(group,name);
            return successFactor;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
