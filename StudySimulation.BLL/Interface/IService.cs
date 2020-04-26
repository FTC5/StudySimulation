using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation.BLL.Interface
{
    public interface IService
    {
        void AddGroup(List<PersoneDTO> persones, int course, string name);
        bool AddTeacher(PersoneDTO person, int sub);
        string AddGroupToTecher(int teacherInd, int groupInd, int sub);
        bool StartActivity(int sub, EQUIPMENT Equip, SUBACTIVITIES SubAct, ROOM Room, int tIndex, int gIndex, int activity);
    }
}
