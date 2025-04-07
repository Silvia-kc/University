using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UniversityMVC.Controllers;
using UniversityMVC.Data.Models;

namespace UniversityMVC.View
{
    public class Display
    {
        UniversityController universityController = new UniversityController();
        FacultyController facultyController = new FacultyController();
        MajorController majorController = new MajorController();
        public async Task ShowMenu()
        {
            Console.WriteLine("Welcome to University");
            while(true)
            {
                Menu();
                int num = int.Parse(Console.ReadLine());
                if(num==10)
                {
                    break;
                }
                switch(num)
                {
                    case 1:
                        await InputUniversity();
                        Console.WriteLine();
                        break;
                    case 2:
                        await InputFaculty();
                        Console.WriteLine();
                        break;
                    case 3:
                        await InputMajor();
                        Console.WriteLine();
                        break;
                    case 4:
                        await GetAllUniversities();
                        Console.WriteLine();
                        break;
                    case 5:
                        await GetFacultiesByUniversityId();
                        Console.WriteLine();
                        break;
                    case 6:
                        await GetMajorsByFacultyId();
                        Console.WriteLine();
                        break;
                    case 7:
                        await GetUniversityIdByName();
                        Console.WriteLine();
                        break;
                    case 8:
                        await GetFacultyIdAndNameByName();
                        Console.WriteLine();
                        break;
                    case 9:
                        await GetMajorIdAndNameByName();
                        Console.WriteLine();
                        break;

                }
            }
        }
        public void Menu()
        {
            Console.WriteLine("1.Add university");
            Console.WriteLine("2.Add faculty");
            Console.WriteLine("3.Add major");
            Console.WriteLine("4.Show all universities");
            Console.WriteLine("5.Show faculties by university ID");
            Console.WriteLine("6.Show majors by faculty ID");
            Console.WriteLine("7.Show university ID by name");
            Console.WriteLine("8.Show faculty ID and name by name");
            Console.WriteLine("9.Show major ID and name by name");
            Console.WriteLine("10.Exit");
        }
        public async Task InputUniversity()
        {
            Console.WriteLine("Enter university name: ");
            string name = Console.ReadLine();
            await universityController.AddUniversity(name);
            Console.WriteLine("University was added successfully!");
        }
        public async Task InputFaculty()
        {
            Console.WriteLine("Enter faculty name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter faculty university ID: ");
            int id = int.Parse(Console.ReadLine());
            await facultyController.AddFaculty(name, id);
            Console.WriteLine("Faculty was added successfully!");
        }
        public async Task InputMajor()
        {
            Console.WriteLine("Enter major name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter major faculty id: ");
            int id = int.Parse(Console.ReadLine());
            await majorController.AddMajor(name, id);
            Console.WriteLine("Major was added successfully!");
        }
        public async Task GetAllUniversities()
        {
            List<University> universities = await universityController.GetAllUniversities();
            foreach(var university in universities)
            {
                Console.WriteLine(university.Name);
            }
            if(universities.Count == 0)
            {
                Console.WriteLine("There are no universities!");
            }
        }
        public async Task GetFacultiesByUniversityId()
        {
            Console.WriteLine("Enter faculty university id: ");
            int id = int.Parse(Console.ReadLine());
            List<Faculty> faculties = await facultyController.GetFacultiesByUniversityId(id);
            foreach(var faculty in faculties)
            {
                Console.WriteLine(faculty.Name);
            }
            if(faculties==null)
            {
                Console.WriteLine("There is no faculty with this university id!");
            }
        }
        public async Task GetMajorsByFacultyId()
        {
            Console.WriteLine("Enter major faculty id: ");
            int id = int.Parse(Console.ReadLine());
            List<Major> majors = await majorController.GetMajorsByFacultyId(id);
            foreach(var major in majors)
            {
                Console.WriteLine(major.Name);
            }
            if(majors==null)
            {
                Console.WriteLine("There is no major with this faculty id!");
            }
        }
        public async Task GetUniversityIdByName()
        {
            Console.WriteLine("Enter university name: ");
            string name = Console.ReadLine();
            University university = await universityController.GetUniversityIdByName(name);
            Console.WriteLine(university.Id);
            if(university==null)
            {
                Console.WriteLine("There is no university with this name: ");
            }
        }
        public async Task GetFacultyIdAndNameByName()
        {
            Console.WriteLine("Enter faculty name: ");
            string name = Console.ReadLine();
            List<Faculty> faculties = await facultyController.GetFacultiesByName(name);
            foreach(var faculty in faculties)
            {
                Console.WriteLine($"{faculty.Id} {faculty.Name}");
            }
            if(faculties==null)
            {
                Console.WriteLine("There is no faculty with this name!");
            }
        }
        public async Task GetMajorIdAndNameByName()
        {
            Console.WriteLine("Enter major name: ");
            string name = Console.ReadLine();
            List<Major> majors = await majorController.GetMajorsByName(name);
            foreach(var major in majors)
            {
                Console.WriteLine($"{major.Id} {major.Name}");
            }
            if(majors==null)
            {
                Console.WriteLine("There is no major with this name");
            }
                
        }
    }
}
