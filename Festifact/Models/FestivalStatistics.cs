using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models
{
    public class FestivalStatistics
    {
        public int NumberOfVoorstellingen { get; set; }
        public int NumberOfArtiesten { get; set; }
        public int NumberOfTicketsBought { get; set; }
        public int NumberOfTicketsLeft { get; set; }
        public Dictionary<int, int> Ratings { get; set; }
    }
}
