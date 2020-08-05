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
        /// <summary>
        /// Creates A paint and saves it into the db
        /// </summary>
        /// <param name="paintdto"> instance of the PaintDTO</param>
        /// <param name="email"> users email</param>
        /// <returns> a paintdto </returns>
        Task<PaintDTO> Create(PaintDTO paintdto, string email);


        // GetAllPaints
        /// <summary>
        /// Gets all of the paint
        /// </summary>
        /// <param name="email"> Users email</param>
        /// <returns> all paintdto objects</returns>
        Task<List<PaintDTO>> GetPaints(string email);


        // GetAPaint
        /// <summary>
        /// Gets a singular paint 
        /// </summary>
        /// <param name="id">integer for the id  </param>
        /// <param name="email"> users email </param>
        /// <returns> a singular paintdto object </returns>
        Task<PaintDTO> GetPaint(int id, string email);


        // UpdateAPaint
        /// <summary>
        /// Updates a paint and saves it into the db 
        /// </summary>
        /// <param name="paintdto"> dto for paint</param>
        /// <param name="email">users email</param>
        /// <returns> paintdto object</returns>
        Task<PaintDTO> Update(PaintDTO paintdto, string email);


        // DeleteAPaint
        /// <summary>
        /// Deletes a paint from the db
        /// </summary>
        /// <param name="id">integer for id </param>
        /// <returns>task completion</returns>
        Task Delete(int id);
    }
}
