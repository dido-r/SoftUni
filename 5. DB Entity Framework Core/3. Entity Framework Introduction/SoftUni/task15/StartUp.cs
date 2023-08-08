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
                Console.WriteLine(RemoveTown(context));
            }
        }

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employeesInSeattle = context.Employees
                .Include(x => x.Address)
                .Include(x => x.Address.Town)
                .Where(x => x.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var employee in employeesInSeattle)
            {
                employee.AddressId = null;
            }

            var addresses = context.Addresses.Include(x => x.Town).Where(x => x.Town.Name == "Seattle").ToList();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            var town = context.Towns.First(x => x.Name == "Seattle");
            context.Towns.Remove(town);
            context.SaveChanges();
            sb.AppendLine($"{addresses.Count} addresses in Seattle were deleted");

            return sb.ToString().Trim();
        }
    }
}
