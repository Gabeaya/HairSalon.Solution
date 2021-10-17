using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Client
  {
    public Client()
    {
      this.JoinEntities = new HashSet<ClientStylist>();
    }
    public int ClientId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ClientStylist> JoinEntities { get; }
  }
}