using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnect = new SqlConnection(@"Server=DESKTOP-I51906\SQLEXPRESS;Database=MinionsDB;Integrated security=true;Encrypt=false");
            sqlConnect.Open();
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (sqlConnect)
            {
                var command = new SqlCommand($"UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 WHERE Id IN ({string.Join(", ", ids)})", sqlConnect);
                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT Name, Age FROM Minions", sqlConnect);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{(string)reader["Name"]} {(int)reader["Age"]}");
                }
            }
        }
    }
}
