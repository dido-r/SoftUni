using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using System;

namespace NavalVessels
{
    class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode  { get; private set; }

        public void ToggleSubmergeMode()
        {
            switch (SubmergeMode)
            {
                case true:
                    SubmergeMode = false;
                    MainWeaponCaliber -= 40;
                    Speed += 5;
                    break;
                case false:
                    SubmergeMode = true;
                    MainWeaponCaliber += 40;
                    Speed -= 4;
                    break;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 200)
            {
                ArmorThickness = 200;
            }
        }

        public override string ToString()
        {
            string submergeStatus = "ON";

            if (!SubmergeMode)
            {
                submergeStatus = "OFF";
            }
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {submergeStatus}";
        }
    }
}
