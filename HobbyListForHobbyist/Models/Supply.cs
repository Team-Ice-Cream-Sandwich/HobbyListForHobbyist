using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models
{
    public class Supply
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Email { get; set; }

        // Nav Properties
        public List<MiniToSupply> MiniToSupply { get; set; }
    }
}
