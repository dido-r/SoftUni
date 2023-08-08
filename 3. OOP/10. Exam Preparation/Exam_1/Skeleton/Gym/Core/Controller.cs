using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    class Controller : IController
    {
        private readonly IRepository<IEquipment> equipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            gyms = new List<IGym>();
            equipment = new EquipmentRepository();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            var gym = gyms.First(x => x.Name == gymName);

            if ((athleteType == "Boxer" && gym.GetType().Name != "BoxingGym") || (athleteType == "Weightlifter" && gym.GetType().Name != "WeightliftingGym"))
            {
                throw new InvalidOperationException(OutputMessages.InappropriateGym);
            }

            IAthlete athlete = default;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            IEquipment instance = default;

            if (equipmentType == "BoxingGloves")
            {
                instance = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                instance = new Kettlebell();
            }

            equipment.Add(instance);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym instance = default;

            if (gymType == "BoxingGym")
            {
                instance = new BoxingGym(gymName);

            }
            else if (gymType == "WeightliftingGym")
            {
                instance = new WeightliftingGym(gymName);
            }
            gyms.Add(instance);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            double value = gyms.First(x => x.Name == gymName).EquipmentWeight;
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, value);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (equipment.FindByType(equipmentType) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            if (!gyms.Any(x => x.Name == gymName))
            {
                throw new InvalidOperationException();
            }

            var currentEquipmnet = equipment.Models.First(x => x.GetType().Name == equipmentType);
            equipment.Remove(currentEquipmnet);
            gyms.First(x => x.Name == gymName).AddEquipment(currentEquipmnet);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine($"{gym.GymInfo()}");
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var currentGym = gyms.First(x => x.Name == gymName);
            currentGym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, currentGym.Athletes.Count);
        }
    }
}
