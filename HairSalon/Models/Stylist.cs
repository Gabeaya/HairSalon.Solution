using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylist
    {
        public Stylist()
        {
            this.JoinEntities = new HashSet<ClientStylist>();
        }

        public int StylistId { get; set; }
        public string Name { get; set; }
        public string Skills { get; set; }
        public virtual ICollection<ClientStylist> JoinEntities { get; set; }
    }
}
