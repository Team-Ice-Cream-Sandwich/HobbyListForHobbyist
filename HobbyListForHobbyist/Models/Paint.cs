using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models
{
    public class Paint
    {
        // Properties
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string Manufacturer { get; set; }
        public string ProductNumber { get; set; }
        public int UserId { get; set; }
        // Nav Properties
        public List<MiniToPaint> MinisToPaint { get; set; }

       
    }
}
