using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.PaymentRepo;
using Gut_Cleanse.Repo.ProgramsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Service.ProgramsService
{
    public interface IProgramsServices
    {
        IEnumerable<ProgramModel> GetPrograms();
        IEnumerable<ProgramDetailModel> GetProgramDetailByProgramId(int programId);
        IEnumerable<TestimonialModel> GetTestimonialProgramsById(int programId);
        ProgramModel GetProgramById(int Id);
    
        bool UpdateProgram(ProgramModel Program ,string currentUser);
       
        IEnumerable<ProgramModel> GetProgramWithDetails(int programId);

    }
}
