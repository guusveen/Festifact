namespace Festifact.Models
{
    public class Artiest
    {
        public int? Id { get; set; }
        public string? Naam { get; set; }
        public string? Beschrijving { get; set; }
        public string? Afbeelding { get; set; }
        public string? LandVanHerkomst { get; set; }
        public string? Type { get; set; }
        public string? Genre { get; set; }
        public virtual ICollection<Voorstelling>? Voorstellingen { get; set; }
    }

}
