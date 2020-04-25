using StudySimulation.DAL;
using System;
using System.Collections.Generic;

namespace StudySimulation.BLL.Abstract
{
    public class EvaluationEventArgs : EventArgs
    {
        public string text;
    }
    public delegate void EvaluationHandler(object source, EvaluationEventArgs arg);
    public abstract class GroupRating
    {
        public event EvaluationHandler GetEvaluation;
        protected Random rand;
        public GroupRating()
        {
            rand = new Random();
        }
        protected void CallGetMarkHandler(object source,string message)
        {
            EvaluationEventArgs arg = new EvaluationEventArgs();
            arg.text = message;
            GetEvaluation?.Invoke(this,arg);
        }
        protected abstract int CountLuck(int studentCount = 0, int successFactor = 0);
        protected abstract int GetGrade(int luck);
        protected abstract int GetAverageMark(Student student, string subject);
        public virtual void SetGroupGrades(Group group, string subject,int boost = 0)
        {
            EvaluationEventArgs arg = new EvaluationEventArgs();
            int luckNow = 0;
            int evaluation = 0;
            luckNow = CountLuck(group.Students.Count, boost);
            arg.text=group.ToString()+"\n";
            foreach (Student student in group.Students)
            {
                luckNow += student.Luck;
                if (!CheckSub(student, subject))
                {
                    student.Evaluations.Add(subject, new List<int>());
                }
                evaluation = GetGrade(luckNow);
                arg.text += student.ToString() + " : " + evaluation + "\n";
                student.Evaluations[subject].Add(evaluation);
            }
            GetEvaluation?.Invoke(this,arg);
        }
        public virtual void SetGrades(Student student, string subject, int studentCount = 0, int boost = 0)
        {
            EvaluationEventArgs arg = new EvaluationEventArgs();
            int luckNow = 0;
            int evaluation = 0;
            luckNow = CountLuck(studentCount, boost);
            luckNow += student.Luck;
            if (!CheckSub(student, subject))
            {
                student.Evaluations.Add(subject, new List<int>());
            }
            evaluation = GetGrade(luckNow);
            arg.text = student.ToString() + " : " + evaluation;
            GetEvaluation?.Invoke(this,arg);
            student.Evaluations[subject].Add(evaluation);
        }
        public void Neglect(Student student, string subject)
        {
            EvaluationEventArgs arg = new EvaluationEventArgs();
            arg.text = student.ToString() + " : " + 0;
            GetEvaluation?.Invoke(this, arg);
            student.Evaluations[subject].Add(0);
        }
        public void SetAverageMark(Group group, string subject)
        {
            EvaluationEventArgs arg = new EvaluationEventArgs();
            int evaluation = 0;
            foreach (Student student in group.Students)
            {
                evaluation = GetAverageMark(student, subject);
                arg.text += student.ToString() + " : " + evaluation;
                GetEvaluation?.Invoke(this,arg);
                student.Evaluations[subject].Add(evaluation);
            }
        }
        public virtual void SetRandGroupGrade(Group group, string subject, int successFactor = 0)
        {
            EvaluationEventArgs arg = new EvaluationEventArgs();
            int luckNow = 0;
            int randNum = 0;
            int evaluation = 0;
            luckNow = CountLuck(group.Students.Count, successFactor);
            foreach (Student student in group.Students)
            {
                randNum = rand.Next(0, 30);
                if (randNum < 8)
                {
                    luckNow += student.Luck;
                    if (!CheckSub(student, subject))
                    {
                        student.Evaluations.Add(subject, new List<int>());
                    }
                    evaluation = GetGrade(luckNow);
                    if (evaluation == 0)
                    {
                        evaluation = 2;
                    }
                    arg.text = student.ToString() + " : " + evaluation;
                    GetEvaluation?.Invoke(this, arg);
                    student.Evaluations[subject].Add(evaluation);
                }

            }
        }
        private bool CheckSub(Student student, string subject)
        {
            return student.Evaluations.ContainsKey(subject);
        }
    }
}
