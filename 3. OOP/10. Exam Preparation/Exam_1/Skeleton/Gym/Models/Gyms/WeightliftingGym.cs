namespace Gym.Models.Gyms
{
    class WeightliftingGym : Gym
    {
        public WeightliftingGym(string name) : base(name, 20)
        {
            gymType = typeof(WeightliftingGym).Name;
        }
    }
}
