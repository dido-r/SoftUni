using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                string type = Console.ReadLine();

                if (type == "Beast!")
                {
                    break;
                }

                string[] animalData = Console.ReadLine().Split();
                Animal animal = default;

                if (int.Parse(animalData[1]) < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (type == "Dog")
                {
                    animal = new Dog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                }
                else if (type == "Cat")
                {
                    animal = new Cat(animalData[0], int.Parse(animalData[1]), animalData[2]);
                }
                else if (type == "Frog")
                {
                    animal = new Frog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                }
                else if (type == "Tomcat")
                {
                    animal = new Tomcat(animalData[0], int.Parse(animalData[1]));
                }
                else if (type == "Kitten")
                {
                    animal = new Kitten(animalData[0], int.Parse(animalData[1]));
                }
                Console.WriteLine(type);
                Console.WriteLine(animal);
                animal.ProduceSound();
            }
        }
    }
}
