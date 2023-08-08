﻿using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    class Weightlifter : Athlete
    {
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, 50)
        {
        }

        public override void Exercise()
        {
            Stamina += 10;

            if (Stamina > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}