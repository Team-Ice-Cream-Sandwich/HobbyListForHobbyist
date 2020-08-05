using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models
{
    public class MiniWishList
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string PartNumber { get; set; }
        public string Faction { get; set; }
        public int PointCost { get; set; }
        public decimal Price { get; set; }
        public string Email { get; set; }

        // Nav Properties
        public MiniModel MiniModel{ get; set; }
       
    }
}
