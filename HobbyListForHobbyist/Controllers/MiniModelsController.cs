using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models;
using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using System.Data.Odbc;
using Microsoft.AspNetCore.Authorization;

namespace HobbyListForHobbyist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MiniModelsController : ControllerBase
    {
        private IMiniModel _miniModel; 

        public MiniModelsController(IMiniModel miniModel)
        {
            _miniModel = miniModel;
        }

        // POST: api/MiniModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MiniModelDTO>> PostMiniModel(MiniModelDTO miniModel)
        {
            await _miniModel.Create(miniModel, GetUserId());            

            return CreatedAtAction("GetMiniModel", new { id = miniModel.Id }, miniModel);
        }

        // GET: api/MiniModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniModelDTO>>> GetMiniModels()
        {
            List<MiniModelDTO> miniModels = await _miniModel.GetAllMiniModels(GetUserId());
            
            return miniModels;
        }

        // GET: api/MiniModels/BuildState/built
        [HttpGet("BuildState/{buildState}")]
        public async Task<ActionResult<IEnumerable<MiniModelDTO>>> GetMiniModelsOfState(BuildState buildState)
        {
            var miniModels = await _miniModel.GetAMiniModelOfState(buildState, GetUserId());

            return miniModels;
        }

        // GET: api/MiniModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniModelDTO>> GetMiniModel(int id)
        {
            MiniModelDTO miniModel = await _miniModel.GetMiniModel(id, GetUserId());

            return miniModel;
        }

        // PUT: api/MiniModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniModel(int id, MiniModelDTO miniModel)
        {
            if (id != miniModel.Id)
            {
                return BadRequest();
            }

            var updatedMini = await _miniModel.Update(miniModel, id);

            return Ok(updatedMini);
        }

        // DELETE: api/MiniModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MiniModel>> DeleteMiniModel(int id)
        {
            await _miniModel.Delete(id);

            return Ok();
        }


        // POST: api/MiniModels/5/Paint/5
        [HttpPost("{miniId}/Paint/{paintId}")]
        public async Task<IActionResult> PostPaintToMini(int miniId, int paintId)
        {
            await _miniModel.AddAPaintToAModel(miniId, paintId);
            return Ok();
        }

        // DELETE: api/MiniModels/5/Paint/5
        [HttpDelete("{miniId}/Paint/{paintId}")]
        public async Task<IActionResult> DeletePaintFromMini(int miniId, int paintId)
        {
            await _miniModel.RemoveAPaintToAModel(miniId, paintId);
            return Ok();
        }

        // POST: api/MiniModels/5/Supply/5
        [HttpPost("{miniId}/Supply/{supplyId}")]
        public async Task<IActionResult> PostSupplyToMini(int miniId, int supplyId)
        {
            await _miniModel.AddASupplytToAModel(miniId, supplyId);
            return Ok();
        }

        // DELETE: api/MiniModels/5/Supply/5
        [HttpDelete("{miniId}/Supply/{supplyId}")]
        public async Task<IActionResult> DeleteSupplyFromMini(int miniId, int supplyId)
        {
            await _miniModel.RemoveASupplyToAModel(miniId, supplyId);
            return Ok();
        }

        protected string GetUserId()
        {
            return User.Claims.First(x => x.Type == "UserId").Value;
        }

        protected string GetUserEmail()
        {
            return User.Claims.First(x => x.Type == "Email").Value;
        }
    }
}
