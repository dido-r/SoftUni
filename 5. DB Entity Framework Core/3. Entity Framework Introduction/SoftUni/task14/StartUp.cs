using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                Console.WriteLine(DeleteProjectById(context));
            }
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var projectEmployee = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList();

            foreach (var item in projectEmployee)
            {
                context.EmployeesProjects.Remove(item);
            }

            context.SaveChanges();
            var project = context.Projects.First(x => x.ProjectId == 2);
            context.Projects.Remove(project);
            context.SaveChanges();
            var projects = context.Projects.Take(10);

            foreach (var item in projects)
            {
                sb.AppendLine($"{item.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
