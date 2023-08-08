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

            string[] minion = Console.ReadLine().Split();
            string[] villain = Console.ReadLine().Split();
            string minionName = minion[1];
            int minionAge = int.Parse(minion[2]);
            string minionTown = minion[3];
            string villainName = villain[1];

            using (sqlConnect)
            {

                SqlCommand command = new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{minionTown}'", sqlConnect);

                if (command.ExecuteScalar() == null)
                {
                    command = new SqlCommand($"INSERT INTO Towns (Name) VALUES ('{minionTown}')", sqlConnect);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                command = new SqlCommand($"SELECT Id FROM Villains WHERE Name = '{villainName}'", sqlConnect);

                if (command.ExecuteScalar() == null)
                {
                    command = new SqlCommand($"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES ('{villainName}', 4)", sqlConnect);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                command = new SqlCommand($"SELECT Id FROM Minions WHERE Name = '{minionName}'", sqlConnect);

                if (command.ExecuteScalar() == null)
                {
                    command = new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{minionTown}'", sqlConnect);
                    int townId = (int)command.ExecuteScalar();
                    command = new SqlCommand($"INSERT INTO Minions (Name, Age, TownId) VALUES ('{minionName}', {minionAge}, {townId})", sqlConnect);
                    command.ExecuteNonQuery();
                }

                command = new SqlCommand($"SELECT Id FROM Minions WHERE Name = '{minionName}'", sqlConnect);
                int minionId = (int)command.ExecuteScalar();
                command = new SqlCommand($"SELECT Id FROM Villains WHERE Name = '{villainName}'", sqlConnect);
                int villainId = (int)command.ExecuteScalar();
                command = new SqlCommand($"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES ({minionId}, {villainId})", sqlConnect);
                command.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
