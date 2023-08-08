namespace Homies.Services.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string Organiser { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}
