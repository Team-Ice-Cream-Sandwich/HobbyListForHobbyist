﻿using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace HobbyListForHobbyist.Models.Services
{
    public class MiniModelService : IMiniModel
    {
        private HobbyListDbContext _context;
        private IPaint _paint;
        private ISupply _supply;

        public MiniModelService(HobbyListDbContext context, IPaint paint, ISupply supply)
        {
            _context = context;
            _paint = paint;
            _supply = supply;
        }

        // CreateAMiniModel
        /// <summary>
        /// The below method allows one to create an minimodel to be stored within MiniModel
        /// </summary>
        /// <param name="supplyName">the name of the minimodel item</param>
        /// <returns>the newly added minimodel item</returns>
        public async Task<MiniModelDTO> Create(MiniModelDTO miniModel, string email)
        {            
            Enum.TryParse(miniModel.BuildState, out BuildState buildState);

            MiniModel entity = new MiniModel()
            {
                Name = miniModel.Name,
                Manufacturer = miniModel.Manufacturer,
                PartNumber = miniModel.PartNumber,
                Faction = miniModel.Faction,
                PointCost = miniModel.PointCost,
                BuildState = buildState,
                Email = email                
            };

            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return miniModel;
        }

        // GetAMiniModel
        /// <summary>
        /// the below method allows one to search for a particular minimodel item
        /// </summary>
        /// <param name="email">this is the email associated with the current user (ensures they have access to minimodel item)</param>
        /// <returns>the minimodel item in question</returns>
        public async Task<MiniModelDTO> GetMiniModel(int id, string email)
        {
            MiniModel miniModel = await _context.MiniModels.Where(x=>x.Email == email)
                                                           .FirstOrDefaultAsync(x=>x.Id == id);

            var paintList = await _context.MinisToPaint.Where(x => x.MiniModelId == id)
                                                       .Include(x => x.Paint)
                                                       .ToListAsync();

            var suppliesList = await _context.MinisToSupply.Where(x => x.MiniModelId == id)
                                                           .Include(x=>x.Supply)
                                                           .ToListAsync();
                        
            List<PaintDTO> paints = new List<PaintDTO>();
            List<SupplyDTO> supplies = new List<SupplyDTO>();
            foreach (var item in paintList)
            {
                paints.Add(await _paint.GetPaint(item.Paint.Id, email));
            }

            foreach (var item in suppliesList)
            {
                supplies.Add(await _supply.GetSupply(item.Supply.Id, email));
            }

            MiniModelDTO miniDto = new MiniModelDTO()
            {
                Id = miniModel.Id,
                Name = miniModel.Name,
                Manufacturer = miniModel.Manufacturer,
                PartNumber = miniModel.PartNumber,
                Faction = miniModel.Faction,
                PointCost = miniModel.PointCost,
                BuildState = miniModel.BuildState.ToString(),
                Paints = paints,
                Supplies = supplies
            };

            return miniDto;
        }

        // GetAllMiniModelsOfState
        /// <summary>
        /// the below method brings up to the user all minimodels oh a sepcified buildstate items currently in their table
        /// </summary>
        /// <param name="buildState">takes a buildstate enum</param>
        /// <param name="email">a string for the the email</param>
        /// <returns></returns>
        public async Task<List<MiniModelDTO>> GetAMiniModelOfState(BuildState buildState, string email)
        {
            List<MiniModel> miniList = await _context.MiniModels.Where(x => x.BuildState == buildState && x.Email == email)
                                                                .ToListAsync();

            List<MiniModelDTO> miniDTOList = new List<MiniModelDTO>();

            foreach (var mini in miniList)
            {
                var paintList = await _context.MinisToPaint.Where(x => x.MiniModelId == mini.Id)
                                                      .Include(x => x.Paint)
                                                      .ToListAsync();

                var suppliesList = await _context.MinisToSupply.Where(x => x.MiniModelId == mini.Id)
                                                           .Include(x => x.Supply)
                                                           .ToListAsync();

                List<PaintDTO> paints = new List<PaintDTO>();
                List<SupplyDTO> supplies = new List<SupplyDTO>();
                foreach (var item in paintList)
                {
                    paints.Add(await _paint.GetPaint(item.Paint.Id, email));
                }

                foreach (var item in suppliesList)
                {
                    supplies.Add(await _supply.GetSupply(item.Supply.Id, email));
                }

                miniDTOList.Add(new MiniModelDTO
                {
                    Id = mini.Id,
                    Name = mini.Name,
                    Manufacturer = mini.Manufacturer,
                    PartNumber = mini.PartNumber,
                    Faction = mini.Faction,
                    PointCost = mini.PointCost,
                    BuildState = mini.BuildState.ToString(),
                    Paints = paints,
                    Supplies = supplies
                }
                );
            }
            return miniDTOList;
        }

        // GetAllMiniModels
        /// <summary>
        /// the below method brings up to the user all minimodels items currently in their table
        /// </summary>
        /// <param name="supplyId">the id number of each particular minimodel item (the method checks for them all)</param>
        /// <param name="email">authenticates the user's access level for the minimodel items</param>
        /// <returns>the minimodels items in the database</returns>
        public async Task<List<MiniModelDTO>> GetAllMiniModels(string email)
        {
            List<MiniModel> miniList = await _context.MiniModels.Where(x=>x.Email==email)
                                                                .ToListAsync();            

            List<MiniModelDTO> miniDTOList = new List<MiniModelDTO>();

            foreach (var mini in miniList)
            {
                var paintList = await _context.MinisToPaint.Where(x => x.MiniModelId == mini.Id)
                                                           .Include(x => x.Paint)
                                                           .ToListAsync();

                var suppliesList = await _context.MinisToSupply.Where(x => x.MiniModelId == mini.Id)
                                                               .Include(x => x.Supply)
                                                               .ToListAsync();
             
                List<PaintDTO> paints = new List<PaintDTO>();
                List<SupplyDTO> supplies = new List<SupplyDTO>();
                foreach (var item in paintList)
                {
                    paints.Add(await _paint.GetPaint(item.Paint.Id, email));
                }

                foreach (var item in suppliesList)
                {
                    supplies.Add(await _supply.GetSupply(item.Supply.Id, email));
                }

                miniDTOList.Add(new MiniModelDTO
                {
                    Id = mini.Id,
                    Name = mini.Name,
                    Manufacturer = mini.Manufacturer,
                    PartNumber = mini.PartNumber,
                    Faction = mini.Faction,
                    PointCost = mini.PointCost,
                    BuildState = mini.BuildState.ToString(),
                    Paints = paints,
                    Supplies = supplies
                }
                );
            }
            return miniDTOList;
        }

        // UpdateAMiniModel
        /// <summary>
        /// the below method updates a particular minimodel item in the database
        /// </summary>
        /// <param name="supplyDTO">this selects the minimodel DTO (what parameters are shown to user)</param>
        /// <param name="email">checks to see if user has authorization for selected minimodel item</param>
        /// <returns>the minimodel dto with the updated minimodel item</returns>
        public async Task<MiniModelDTO> Update(MiniModelDTO miniModel, int id, string email)
        {
            Enum.TryParse(miniModel.BuildState, out BuildState buildState);

            MiniModel updatedMiniModel = new MiniModel()
            {
                Id = miniModel.Id,
                Name = miniModel.Name,
                Manufacturer = miniModel.Manufacturer,
                PartNumber = miniModel.PartNumber,
                Faction = miniModel.Faction,
                PointCost = miniModel.PointCost,
                BuildState = buildState,
                Email = email
            };

            _context.Entry(updatedMiniModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return miniModel;
        }

        // DeleteAMiniModel
        /// <summary>
        /// the below method deletes a minimodel item from the database
        /// </summary>
        /// <param name="supplyId">the minimodel item to be deleted</param>
        /// <returns>nothing, the item is deleted</returns>
        public async Task Delete(int id)
        {
            MiniModel miniModel = await _context.MiniModels.FindAsync(id);
            _context.Entry(miniModel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Add a Paint to a Model
        /// </summary>
        /// <param name="miniModelId">Int for the miniModelId</param>
        /// <param name="paintId">Int for the paintId</param>
        /// <returns>Async version of void</returns>
        public async Task AddAPaintToAModel(int miniModelId, int paintId)
        {            
            MiniToPaint miniPaint = new MiniToPaint()
            {
                MiniModelId = miniModelId,
                PaintId = paintId
            };

            _context.Entry(miniPaint).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Remove a Paint from a Model
        /// </summary>
        /// <param name="miniModelId">Int for the miniModelId</param>
        /// <param name="paintId">Int for the paintId</param>
        /// <returns>Async version of void</returns>
        public async Task RemoveAPaintToAModel(int miniModelId, int paintId)
        {            
            var result = await _context.MinisToPaint.FirstOrDefaultAsync(x => x.MiniModelId == miniModelId && x.PaintId == paintId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
                
        /// <summary>
        /// Add a Supply to a Model
        /// </summary>
        /// <param name="miniModelId">Int for the miniModelId</param>
        /// <param name="paintId">Int for the supplyId</param>
        /// <returns>Async version of void</returns>
        public async Task AddASupplytToAModel(int miniModelId, int supplyId)
        {            
            MiniToSupply miniSupply = new MiniToSupply()
            {
                MiniModelId = miniModelId,
                SupplyId = supplyId
            };

            _context.Entry(miniSupply).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
  
        /// <summary>
        /// Remove a Supply from a Model
        /// </summary>
        /// <param name="miniModelId">Int for the miniModelId</param>
        /// <param name="paintId">Int for the supplyId</param>
        /// <returns>Async version of void</returns>
        public async Task RemoveASupplyToAModel(int miniModelId, int supplyId)
        {            
            var result = await _context.MinisToSupply.FirstOrDefaultAsync(x => x.MiniModelId == miniModelId && x.SupplyId == supplyId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }     
    }
}
