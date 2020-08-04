using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models
{
    public class MiniToPaint
    {
        // Composite key
        public int MiniModelId { get; set; }
        public int PaintId { get; set; }
     

        // Nav Properties
        public Paint Paint { get; set; }
        public MiniModel MiniModel { get; set; }
       
    }
}
