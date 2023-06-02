namespace Festifact.Models
{
    public class Locatie
    {
        public int? Id { get; set; }
        public string? Adres { get; set; }
        public virtual ICollection<Zaal>? Zalen { get; set; }
        public virtual ICollection<Festival>? Festivals { get; set; }
    }

}
