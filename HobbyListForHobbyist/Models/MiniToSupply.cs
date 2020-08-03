using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models
{
    public class MiniToSupply
    {
        // Properties
        public int MiniModelId { get; set; }
        public int SupplyId { get; set; }

        // Nav Properties
        public List<MiniToSupply> MinisToSupply { get; set; }
        public List<Supply> Supply { get; set; }
    }
}
