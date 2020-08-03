using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models
{
    public class MiniModel
    {
        //Properties
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string PartNumber { get; set; }
        public string Faction { get; set; }
        public int PointCost { get; set; }
        public string UserId { get; set; }

        // Nav Properties
        public List<MinisToSupplies> MinisToSupplies { get; set; }
        public List<MiniToPaint> MinisToPaints { get; set; }
    }
    }

    public enum BuidState
    {
        unBuilt = 0,
        built,
        painted
    }
}
