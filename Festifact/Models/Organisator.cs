namespace Festifact.Models
{
    public class Organisator
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        // Navigation properties
        public virtual ICollection<Festival>? Festivals { get; set; }
    }
}
