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
    public class FacultyController
    {
        UniversityDBContext context = new UniversityDBContext();
        public async Task AddFaculty(string name, int universityId)
        {
            Faculty faculty = new Faculty()
            {
                Name = name,
                UniversityId = universityId
            };
            await context.Faculties.AddAsync(faculty);
            await context.SaveChangesAsync();
        }
        public async Task<List<Faculty>> GetFacultiesByUniversityId(int universityId)
        {
            var faculties = await context.Faculties.Where(f => f.UniversityId == universityId)
                                                   .ToListAsync();
            return faculties;
        }
        public async Task<List<Faculty>> GetFacultiesByName(string name)
        {
            var faculties = await context.Faculties.Where(f => f.Name == name)
                                                   .ToListAsync();
            return faculties;
        }
        public async Task<Faculty> GetFacultyByNameAndUniversityId(string name, int universityId)
        {
            var faculty = await context.Faculties.FirstOrDefaultAsync(f => f.Name == name && f.UniversityId == universityId);
            return faculty;
        }
    }
}
