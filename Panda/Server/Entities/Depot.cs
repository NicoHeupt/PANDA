using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Server.Entities
{
    [Owned]
    public class Depot
    {

        public int Id { get; set; }
        public ICollection<DepotPosition> Positions { get; set; } = new Collection<DepotPosition>();
        public ICollection<DepotTransaction> Transactions { get; set; } = new Collection<DepotTransaction>();
    }
}
