using Microsoft.EntityFrameworkCore;
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
                Console.WriteLine(GetEmployee147(context));
            }
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees.First(x => x.EmployeeId == 147);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var item in context.EmployeesProjects.Include(x => x.Project).Where(x => x.EmployeeId == 147).OrderBy(x => x.Project.Name))
            {
                sb.AppendLine($"{item.Project.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
