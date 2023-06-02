namespace Festifact.Models
{
    public class ArtiestFavoriet
    {
        public int? Id { get; set; }
        public int? BezoekerId { get; set; }
        public virtual Bezoeker? Bezoeker { get; set; }
        public int? ArtiestId { get; set; }
        public virtual Artiest? Artiest { get; set; }
    }
}
