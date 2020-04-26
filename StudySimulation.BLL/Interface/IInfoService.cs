using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation.BLL.Interface
{
    public interface IInfoService
    {
        int GetSubjectCount();
        int GetSubjTeacherCount(int sub);
        int GetGroupCount();
        string GetGroup();
        string GetSubject();
        string GetSubjTeacher(int sub);
        string GetTeacherGroup(int sub, int teacherIndex);
        int GetTeacherGroupCount(int sub, int teacherIndex);
        string GetInfo();
        string GetGroupsGrades(int groupId);
    }
}
