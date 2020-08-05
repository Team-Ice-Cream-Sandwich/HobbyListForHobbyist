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
        Task<PaintDTO> Create(PaintDTO paintdto, string email);
        // GetAllPaints
        Task<List<PaintDTO>> GetPaints(string email);
        // GetAPaint
        Task<PaintDTO> GetPaint(int id, string email);
        // UpdateAPaint
        Task<PaintDTO> Update(PaintDTO paintdto);
        // DeleteAPaint
        Task Delete(int id);
    }
}
