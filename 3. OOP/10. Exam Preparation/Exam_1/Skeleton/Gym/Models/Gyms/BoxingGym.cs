namespace Gym.Models.Gyms
{
    class BoxingGym : Gym
    {
        public BoxingGym(string name) : base(name, 15)
        {
            gymType = typeof(BoxingGym).Name;
        }
    }
}
