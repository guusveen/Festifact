namespace Festifact.Models
{
    public class Zaal
    {
        public int? Id { get; set; }
        public string? Naam { get; set; }
        public int? Capaciteit { get; set; }
        public int? LocatieId { get; set; }
        public virtual Locatie? Locatie { get; set; }
        public virtual ICollection<Voorstelling>? Voorstellingen { get; set; }
    }
}
