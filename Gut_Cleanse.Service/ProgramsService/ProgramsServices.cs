using Gut_Cleanse.Data.Tables;
using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.PaymentRepo;
using Gut_Cleanse.Repo.ProgramsRepo;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Service.ProgramsService
{

    public class ProgramsServices : IProgramsServices
    {
        private readonly IProgramsRepo _programsRepo;
        public ProgramsServices(IProgramsRepo programsRepo)
        {
            _programsRepo = programsRepo;
        }

        public ProgramModel GetProgramById(int Id)
        {
            return _programsRepo.GetProgramById(Id);
        }

        public IEnumerable<ProgramDetailModel> GetProgramDetailByProgramId(int programId)
        {
            return _programsRepo.GetProgramDetailByProgramId(programId);
        }

        public IEnumerable<ProgramModel> GetPrograms()
        {
            return _programsRepo.GetPrograms();
        }

        public IEnumerable<TestimonialModel> GetTestimonialProgramsById(int programId)
        {
            return _programsRepo.GetTestimonialProgramsById(programId);
        }
   
        public bool UpdateProgram(ProgramModel Program, string currentUser)
        {
            return _programsRepo.UpdateProgram(Program , currentUser);
        }



        public IEnumerable<ProgramModel> GetProgramWithDetails(int programId)
        {
            return _programsRepo.GetProgramWithDetails(programId);
        }
        public void DeleteTestimonials(int testimonialId)
        {
            _programsRepo.DeleteTestimonials(testimonialId);
        }
    }
}
