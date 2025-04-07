// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using UniversityMVC.View;

namespace UniversityMVC
{ 
    public class Program
    {
        static async Task Main(string[] args)
        {
            Display display = new Display();
            await display.ShowMenu();
        }
    }
}

