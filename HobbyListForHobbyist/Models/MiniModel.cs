using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models
{
    public class MiniModel
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string PartNumber { get; set; }
        public string Faction { get; set; }
        public int PointCost { get; set; }
        public BuildState BuildState { get; set; }
        public string Email { get; set; }
        //public string UserId { get; set; }

        // Nav Properties
        public List<MiniToSupply> MinisToSupplies { get; set; }
        public List<MiniToPaint> MinisToPaints { get; set; }
    }
}

public enum BuildState
{
    unBuilt = 0,
    built,
    painted
}

