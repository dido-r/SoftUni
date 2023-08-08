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

            string country = Console.ReadLine();

            using (sqlConnect)
            {

                SqlCommand command = new SqlCommand($"SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = '{country}'", sqlConnect);
                SqlDataReader reader = command.ExecuteReader();
                List<string> towns = new List<string>();

                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No town names were affected.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            towns.Add(((string)reader["Name"]).ToUpper());
                        }
                    }
                }

                SqlCommand changeName = new SqlCommand($"UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = '{country}')", sqlConnect);
                changeName.ExecuteNonQuery();
                Console.WriteLine($"{towns.Count} town names were affected.");
                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }
        }
    }
}
