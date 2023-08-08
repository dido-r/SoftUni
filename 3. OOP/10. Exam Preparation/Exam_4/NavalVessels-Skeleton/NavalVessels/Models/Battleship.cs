using NavalVessels.Models.Contracts;
using System;

namespace NavalVessels.Models
{
    class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            switch (SonarMode)
            {
                case true:
                    SonarMode = false;
                    MainWeaponCaliber -= 40;
                    Speed += 5;
                    break;
                case false:
                    SonarMode = true;
                    MainWeaponCaliber += 40;
                    Speed -= 5;
                    break;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 300)
            {
                ArmorThickness = 300;
            }
        }
        public override string ToString()
        {
            string sonarStatus = "ON";

            if (!SonarMode)
            {
                sonarStatus = "OFF";
            }
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {sonarStatus}";
        }
    }
}
