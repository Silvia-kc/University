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
    public class UniversityController
    {
        UniversityDBContext context = new UniversityDBContext();
        public async Task AddUniversity(string name)
        {
            University university = new University()
            { 
                Name=name
            };
            await context.Universities.AddAsync(university);
            await context.SaveChangesAsync();
        }
        public async Task<List<University>> GetAllUniversities()
        {
            var universities = await context.Universities.ToListAsync();
            return universities;
        }
        public async Task<University> GetUniversityByName(string name)
        {
            var university = await context.Universities.FirstOrDefaultAsync(u => u.Name == name);
            return university;
        }
        public async Task<University> GetUniversityIdByName(string name)
        {
            var university = await context.Universities.FirstOrDefaultAsync(u => u.Name == name);
            return university;
        }
    }
    
}
