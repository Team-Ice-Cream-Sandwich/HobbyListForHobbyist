using HobbyListForHobbyist.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.Interfaces
{
    public interface IPaint
    {
           // CreateAPaint
        Task<PaintDTO> Create(PaintDTO paintdto);
        // GetAllPaints
        Task<List<PaintDTO>> GetPaints();
        // GetAPaint
        Task<PaintDTO> GetPaint(int id);
        // UpdateAPaint
        Task<PaintDTO> Update(PaintDTO paintdto);
        // DeleteAPaint
        Task Delete(int id);
    }
}
