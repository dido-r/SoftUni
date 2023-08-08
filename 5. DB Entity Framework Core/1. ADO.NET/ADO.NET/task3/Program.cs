using Microsoft.Data.SqlClient;
using System;

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
                int id = int.Parse(Console.ReadLine());
                SqlCommand commandVillain = new SqlCommand($"SELECT Name FROM Villains WHERE Id = {id}", sqlConnect);
                Console.WriteLine($"{commandVillain.ExecuteScalar()}");

                SqlCommand command = new SqlCommand($"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum, m.Name, m.Age FROM MinionsVillains AS mv JOIN Minions As m ON mv.MinionId = m.Id WHERE mv.VillainId = {id} ORDER BY m.Name", sqlConnect);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}
