using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
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
                Console.WriteLine(AddNewAddressToEmployee(context));
            }
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address();
            newAddress.AddressText = "Vitoshka 15";
            newAddress.TownId = 4;
            context.Addresses.Add(newAddress);
            var employee = context.Employees.First(x => x.LastName == "Nakov");
            employee.Address = newAddress;

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();
            var collection = context.Employees
                .Include(x => x.Address)
                .Select(x => new { x.Address.AddressText, x.AddressId })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            foreach (var item in collection)
            {
                sb.AppendLine($"{item.AddressText}");
            }

            return sb.ToString().Trim();
        }
    }
}
