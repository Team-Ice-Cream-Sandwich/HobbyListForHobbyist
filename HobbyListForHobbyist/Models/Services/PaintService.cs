using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.Services
{
    public class PaintService : IPaint
    {
      private  HobbyListDbContext _context;

        /// <summary>
        /// injects the db into the class
        /// </summary>
        /// <param name="context"> Database</param>
        public PaintService(HobbyListDbContext context)
        {
            _context = context;
        }

        // CreateAPaint
        /// <summary>
        /// Creates A paint and saves it into the db
        /// </summary>
        /// <param name="paintdto"> instance of the PaintDTO</param>
        /// <param name="email"> users email</param>
        /// <returns> a paintdto </returns>
        public async Task<PaintDTO> Create(PaintDTO paintdto, string email)
        {
            Paint paint = new Paint()
            {
                ColorName = paintdto.ColorName,
                ProductNumber = paintdto.ProductNumber,
                Manufacturer = paintdto.Manufacturer,
                Email = email
            };
                
            _context.Entry(paint).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return paintdto;
        }

        // GetAPaint
        /// <summary>
        /// Gets a singular paint 
        /// </summary>
        /// <param name="id">integer for the id  </param>
        /// <param name="email"> users email </param>
        /// <returns> a singular paintdto object </returns>
        public async Task<PaintDTO> GetPaint(int id, string email)
        {
            Paint paint = await _context.Paints.Where(x => x.Email == email)
                                               .FirstOrDefaultAsync(x => x.Id == id);

            PaintDTO paintdto = new PaintDTO()
            {
                Id = id,
                ColorName = paint.ColorName,
                ProductNumber = paint.ProductNumber,
                Manufacturer = paint.Manufacturer
            };
            return paintdto;
        }

        // GetAllPaints
        /// <summary>
        /// Gets all of the paint
        /// </summary>
        /// <param name="email"> Users email</param>
        /// <returns> all paintdto objects</returns>
        public async Task<List<PaintDTO>> GetPaints(string email)
        {
            var paint = await _context.Paints.Where(x => x.Email == email)
                                             .ToListAsync();

            var paintdto = new List<PaintDTO>();

            foreach (var item in paint)
            {
                paintdto.Add(await GetPaint(item.Id, email));
            }

            return paintdto;
        }

        // UpdateAPaint
        /// <summary>
        /// Updates a paint and saves it into the db 
        /// </summary>
        /// <param name="paintdto"> dto for paint</param>
        /// <param name="email">users email</param>
        /// <returns> paintdto object</returns>
        public async Task<PaintDTO> Update(PaintDTO paintdto , string email)
        {
            Paint paint = new Paint()
            {
                Id = paintdto.Id,
                ColorName = paintdto.ColorName,
                ProductNumber = paintdto.ProductNumber,
                Manufacturer = paintdto.Manufacturer,
                Email = email
            };
            _context.Entry(paint).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return paintdto;
        }

        // DeleteAPaint
        /// <summary>
        /// Deletes a paint from the db
        /// </summary>
        /// <param name="id">integer for id </param>
        /// <returns>task completion</returns>
        public async Task Delete(int id)
        {
            Paint paint = await _context.Paints.FindAsync(id);

            _context.Entry(paint).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
