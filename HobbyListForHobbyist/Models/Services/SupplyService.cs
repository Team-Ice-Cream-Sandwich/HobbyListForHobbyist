using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace HobbyListForHobbyist.Models.Services
{
    public class SupplyService : ISupply {
        private HobbyListDbContext _context;
        public SupplyService(HobbyListDbContext context)
        {
            _context = context;
        }

        // CreateASupply
        /// <summary>
        /// The below method allows one to create an item to be stored within Supply
        /// </summary>
        /// <param name="supplyName">the name of the supply item</param>
        /// <returns>the newly added supply item</returns>
        public async Task<SupplyDTO> Create(SupplyDTO supplyName)
        {
            Supply supply = new Supply() { Name = supplyName.Name, Category = supplyName.Category };
            _context.Entry(supply).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return supplyName;
        }
        // GetAllSupplies
        /// <summary>
        /// the below method allows one to seach for a particular supply item
        /// </summary>
        /// <param name="email">this is the email associated with the current user (ensures they have access to supply item)</param>
        /// <returns>the supply item in question</returns>
        public async Task<List<SupplyDTO>> GetSupplies(string email)
        {
            var supplies = await _context.Supplies.Where(x => x.Email == email).ToListAsync();
            var dtos = new List<SupplyDTO>();
            foreach (var item in supplies)
            {
                dtos.Add(new SupplyDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category,                    
                });
            }
            return dtos;
        }

        // GetASupply
        /// <summary>
        /// the below method brings up to the user all supply items currently in their table
        /// </summary>
        /// <param name="supplyId">the id number of each particular supply item (the method checks for them all)</param>
        /// <param name="email">authenticates the user's access level for the supply items</param>
        /// <returns>the suppply items in the database</returns>
        public async Task<SupplyDTO> GetSupply(int supplyId, string email)
        {
            Supply supplyName = await _context.Supplies.Where(x => x.Email == email)
                                                            .FirstOrDefaultAsync(x => x.Id == supplyId);
            var supplyItem = await _context.Supplies.FindAsync(supplyId);

            SupplyDTO supply = new SupplyDTO()
            {
                Id= supplyItem.Id,
                Name = supplyItem.Name,
                Category = supplyItem.Category
            };

            return supply;
        }
        // UpdateASupply
        /// <summary>
        /// the below method updates a particular supply item in the database
        /// </summary>
        /// <param name="supplyDTO">this selects the supply DTO (what parameters are shown to user)</param>
        /// <param name="email">checks to see if user has authorization for selected supply item</param>
        /// <returns>the supply dto with the updated supply item</returns>
        public async Task<SupplyDTO> Update(SupplyDTO supplyDTO, string email)
        {
            Supply supply = new Supply() { Id = supplyDTO.Id, Name = supplyDTO.Name, Category = supplyDTO.Category };
            _context.Entry(supply).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return supplyDTO;
        }
        // DeleteASupply
        /// <summary>
        /// the below method deletes a supply item from the database
        /// </summary>
        /// <param name="supplyId">the supply item to be deleted</param>
        /// <returns>nothing, the item is deleted</returns>
        public async Task Delete(int supplyId)
        {
            Supply supply = await _context.Supplies.FindAsync(supplyId);
            _context.Entry(supply).State = EntityState.Deleted;
           await  _context.SaveChangesAsync();
        }
    }
}

