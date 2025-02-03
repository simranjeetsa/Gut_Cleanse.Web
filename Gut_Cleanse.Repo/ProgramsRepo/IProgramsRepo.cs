using Gut_Cleanse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Repo.ProgramsRepo
{
    public interface IProgramsRepo
    {
        IEnumerable<ProgramModel> GetPrograms();
        IEnumerable<ProgramDetailModel> GetProgramDetailByProgramId(int programId);
        IEnumerable<TestimonialModel> GetTestimonialProgramsById(int programId);
        ProgramModel GetProgramById(int programId);


        bool UpdateProgram(ProgramModel Program,string currentUser);
     
        IEnumerable<ProgramModel> GetProgramWithDetails(int programId);
    }
}
