using StudySimulation.BLL.Abstract;
using StudySimulation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySimulation.BLL
{
    public interface IUniversity
    {
        List<Subject> Subjects { get; }
        List<Group> Groups { get; set; }
        Dictionary<Subject, List<Teacher>> Staff { get; set; }
        GroupRating GroupRating { get; }
    }
}
