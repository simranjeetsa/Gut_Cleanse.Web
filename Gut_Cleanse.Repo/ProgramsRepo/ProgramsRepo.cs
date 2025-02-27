﻿using Gut_Cleanse.Common;
using Gut_Cleanse.Data;
using Gut_Cleanse.Data.Tables;
using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gut_Cleanse.Repo.ProgramsRepo.ProgramsRepo;

namespace Gut_Cleanse.Repo.ProgramsRepo
{
    public class ProgramsRepo : IProgramsRepo
    {
        private readonly ApplicationDbContext _context;
        public ProgramsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProgramModel> GetPrograms()
        {
            List<ProgramModel> result = new List<ProgramModel>();
            result.AddRange(_context.Programs.Select(x => x.AutoMap<ProgramModel>()).ToList());
            return result;
        }

        public IEnumerable<TestimonialModel> GetTestimonialProgramsById(int programId)
        {
            return _context.Testimonials
                             .Where(x => x.ProgramId == programId)
                             .Select(x => x.AutoMap<TestimonialModel>())
                             .ToList();

        }
        public IEnumerable<ProgramDetailModel> GetProgramDetailByProgramId(int programId)
        {
            return _context.ProgramDetails.Where(x => x.ProgramId == programId).Select(x => x.AutoMap<ProgramDetailModel>()).ToList();
        }
        public  ProgramModel GetProgramById(int Id)
        {
            ProgramModel result = new ProgramModel();
            var program = _context.Programs.FirstOrDefault(x => x.Id == Id);
            if (program != null)
            {
                result.Id = Id;
                result.Name = program.Name;
                result.Description = program.Description;
                result.Amount = program.Amount;
                result.StartDate = program.StartDate;
                result.EndDate = program.EndDate;
            }
            return result;

        }
 



   
   
        public IEnumerable<ProgramModel> GetProgramWithDetails(int programId)
        {
            // First, get the Program along with its related entities
            var result = (from program in _context.Programs
                          where program.Id == programId
                          select new
                          {
                              program.Id,
                              program.Name,
                              program.Description,
                              program.StartDate,
                              program.EndDate,
                              program.Amount,
                              ProgramDetails = _context.ProgramDetails.Where(pd => pd.ProgramId == program.Id).ToList(),
                              Testimonials = _context.Testimonials.Where(t => t.ProgramId == program.Id).ToList()
                          }).AsEnumerable()
                          .Select(programData => new ProgramModel
                          {
                              Id = programData.Id,
                              Name = programData.Name,
                              Description = programData.Description,
                              StartDate = programData.StartDate,
                              EndDate = programData.EndDate,
                              Amount = programData.Amount,
                              ProgramDetail = programData.ProgramDetails.Select(pd => new ProgramDetailModel
                              {
                                  Name = pd.Name,
                                  Description = pd.Description,
                                  Id = pd.Id
                              }).ToList(),
                              TestimonialPrograms = programData.Testimonials.Select(t => new TestimonialModel
                              {
                                  Name = t.Name,
                                  Description = t.Description,
                                  Id = t.Id,
                                  CreatedBy = t.CreatedBy,
                              }).ToList()
                          });

            return result.ToList(); 
        }


        public bool UpdateProgram(ProgramModel program, string currentUser)
        {
            try
            {
               
                var existingProgram = _context.Programs
                    .Include(p => p.ProgramDetails)
                    .Include(p => p.Testimonials)
                    .FirstOrDefault(p => p.Id == program.Id);

                if (existingProgram == null)
                {
                    return false; 
                }

              
                existingProgram.Name = program.Name;
                existingProgram.Description = program.Description;
                existingProgram.StartDate = program.StartDate;
                existingProgram.EndDate = program.EndDate;
                existingProgram.Amount = program.Amount;

               
                if (existingProgram.ProgramDetails != null)
                {
                    // Update existing details
                    foreach (var existingDetail in existingProgram.ProgramDetails.ToList())
                    {
                        var updatedDetail = program.ProgramDetail.FirstOrDefault(pd => pd.Id == existingDetail.Id);
                        if (updatedDetail != null)
                        {
                            existingDetail.Name = updatedDetail.Name;
                            existingDetail.Description = updatedDetail.Description;
                        }

                    }

                 
                }

                if (existingProgram.Testimonials != null)
                {
                
                    foreach (var existingTestimonial in existingProgram.Testimonials.ToList())
                    {
                        var updatedTestimonial = program.TestimonialPrograms.FirstOrDefault(t => t.Id == existingTestimonial.Id);
                        if (updatedTestimonial != null)
                        {
                            existingTestimonial.Name = updatedTestimonial.Name;
                            existingTestimonial.Description = updatedTestimonial.Description;
                            existingTestimonial.CreatedBy = updatedTestimonial.CreatedBy;
                        }
                     
                    }

                }

              
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                Console.Error.WriteLine(ex.Message); 

                return false;
            }
        }




    }
}


