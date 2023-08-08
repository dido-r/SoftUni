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
            int id = int.Parse(Console.ReadLine());

            using (sqlConnect)
            {
                var command = new SqlCommand($"EXEC dbo.usp_GetOlder {id}", sqlConnect);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{(string)reader["Name"]} – {(int)reader["Age"]} years old");
                }
            }
        }
    }
}
