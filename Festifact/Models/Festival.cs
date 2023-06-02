namespace Festifact.Models
{
    public class Festival
    {
        public int? Id { get; set; }
        public string? Naam { get; set; }
        public string? Beschrijving { get; set; }
        public string? BannerAfbeelding { get; set; }
        public string? Type { get; set; }
        public string? Genre { get; set; }
        public int? LeeftijdscategorieVan { get; set; }
        public int? LeeftijdscategorieTot { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? EindDatum { get; set; }

        // Foreign key for Organisator
        public int? OrganisatorId { get; set; }

        // Navigation properties
        public virtual Organisator? Organisator { get; set; }
        public virtual ICollection<Voorstelling>? Voorstellingen { get; set; }
        public virtual ICollection<Locatie>? Locaties { get; set; }

    }

}
