using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public static class CreateObject
    {
        public static Animal Factory(string[] animalData)
        {
            Animal animal = default;

            switch (animalData[0])
            {
                case "Owl":
                    animal = new Owl(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3]));
                    break;
                case "Hen":
                    animal = new Hen(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3]));
                    break;
                case "Mouse":
                    animal = new Mouse(animalData[1], double.Parse(animalData[2]), animalData[3]);
                    break;
                case "Dog":
                    animal = new Dog(animalData[1], double.Parse(animalData[2]), animalData[3]);
                    break;
                case "Cat":
                    animal = new Cat(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]);
                    break;
            }
            return animal;
        }
    }
}
