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
        public async Task<SupplyDTO> Create(SupplyDTO supplyName)
        {
            _context.Entry(supplyName).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return supplyName;
        }
        // GetAllSupplies
        public async Task<List<SupplyDTO>> GetSupplies()
        {
            var supplies = await _context.Supply.ToListAsync();
            List<SupplyDTO> dtos = new List<SupplyDTO>();
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
        public async Task<SupplyDTO> GetSupply(int supplyId)
        {
            var supplyItem = await _context.Supply.FindAsync(supplyId);
            SupplyDTO supply = new SupplyDTO()
            {
                Id= supplyItem.Id,
                Name = supplyItem.Name,
                Category = supplyItem.Category

            };
            return supply;
        }
        // UpdateASupply
        public async Task Update(int supplyId, SupplyDTO supplyName)
        {
            _context.Entry(supplyName).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        // DeleteASupply
        public async Task Delete(int supplyId)
        {
            var supply = await GetSupply(supplyId);
            _context.Entry(supply).State = EntityState.Deleted;
        }
    }
}

