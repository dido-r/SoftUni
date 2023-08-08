using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnect = new SqlConnection(@"Server=DESKTOP-I51906\SQLEXPRESS;Database=MinionsDB;Integrated security=true;Encrypt=false");
            sqlConnect.Open();
            int villainId = int.Parse(Console.ReadLine());
            int minionsCount = 0;
            string villain = string.Empty;

            using (sqlConnect)
            {
                var command = new SqlCommand($"SELECT Name FROM Villains WHERE Id = {villainId}", sqlConnect);

                if (command.ExecuteScalar() == null)
                {
                    Console.WriteLine("No such villain was found.");
                    Environment.Exit(0);
                }
                else
                {
                    villain = (string)command.ExecuteScalar();
                    command = new SqlCommand($"SELECT COUNT([MinionId]) FROM MinionsVillains WHERE VillainId = {villainId}", sqlConnect);
                    minionsCount = (int)command.ExecuteScalar();
                    command = new SqlCommand($"DELETE FROM MinionsVillains WHERE VillainId = {villainId}", sqlConnect);
                    command.ExecuteNonQuery();
                    command = new SqlCommand($"DELETE FROM Villains WHERE Id = {villainId}", sqlConnect);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"{villain} was deleted.");
            Console.WriteLine($"{minionsCount} minions were released.");
        }
    }
}
