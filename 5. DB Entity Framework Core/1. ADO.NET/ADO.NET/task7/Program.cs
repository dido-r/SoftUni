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

            using (sqlConnect)
            {
                SqlCommand command = new SqlCommand("SELECT Name FROM Minions", sqlConnect);
                SqlDataReader reader = command.ExecuteReader();
                List<string> minions = new List<string>();

                using (reader)
                {
                    while (reader.Read())
                    {
                        minions.Add((string)reader["Name"]);
                    }
                }

                for (int i = 0; i < minions.Count; i++)
                {
                    Console.WriteLine(minions[0]);
                    minions.RemoveAt(0);
                    minions.Reverse();
                    i = -1;
                }
            }
        }
    }
}
