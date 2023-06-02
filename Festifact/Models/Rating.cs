namespace Festifact.Models
{
    public class Rating
    {
        public int? Id { get; set; }
        public int? BezoekerId { get; set; }
        public virtual Bezoeker? Bezoeker { get; set; }
        public int? VoorstellingId { get; set; }
        public virtual Voorstelling? Voorstelling { get; set; }
        public int? Score { get; set; }
        public string? Opmerking { get; set; }
    }

}
