using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityMVC.Data;
using UniversityMVC.Data.Models;

namespace UniversityMVC.Controllers
{
    public class MajorController
    {
        UniversityDBContext context = new UniversityDBContext();
        public async Task AddMajor(string name, int facultyId)
        {
            Major major = new Major()
            {
                Name=name,
                FacultyId=facultyId
            };
            await context.Majors.AddAsync(major);
            await context.SaveChangesAsync();
        }
        public async Task<List<Major>> GetMajorsByFacultyId(int facultyId)
        {
            var majors = await context.Majors.Where(m => m.FacultyId == facultyId)
                                             .ToListAsync();
            return majors;
        }
        public async Task<List<Major>> GetMajorsByName(string name)
        {
            var majors = await context.Majors.Where(m => m.Name == name)
                                             .ToListAsync();
            return majors;
        }
        public async Task<Major> GetMajorByNameAndFacultyId(string name, int facultyId)
        {
            var major = await context.Majors.FirstOrDefaultAsync(m => m.Name == name && m.FacultyId == facultyId);
            return major;
        }
    }
}
