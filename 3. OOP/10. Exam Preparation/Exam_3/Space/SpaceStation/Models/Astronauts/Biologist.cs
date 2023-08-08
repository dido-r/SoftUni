namespace SpaceStation.Models.Astronauts
{
    class Biologist : Astronaut
    {
        public Biologist(string name) : base(name, 70)
        {
        }

        public override void Breath()
        {
            Oxygen -= 5;

            if (Oxygen <= 0)
            {
                Oxygen = 0;
            }
        }
    }
}
