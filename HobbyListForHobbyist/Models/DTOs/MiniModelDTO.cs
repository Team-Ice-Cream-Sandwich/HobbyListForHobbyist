using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.DTOs
{
    public class MiniModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string PartNumber { get; set; }
        public string Faction { get; set; }
        public int PointCost { get; set; }
        public string BuildState { get; set; }
        public List<PaintDTO> Paints { get; set; }
        public List<SupplyDTO> Supplies { get; set; }
    }
}
