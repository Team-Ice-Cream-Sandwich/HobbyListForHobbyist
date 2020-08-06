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
using Microsoft.AspNetCore.Authorization;

namespace HobbyListForHobbyist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SuppliesController : ControllerBase
    {
        private ISupply _supply;

        public SuppliesController(ISupply supply)
        {
            _supply = supply;
        }

        // GET: api/Supplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplyDTO>>> GetSupply(string email)
        {
            return await _supply.GetSupplies(email);
        }

        // GET: api/Supplies/5
        [HttpGet("{supplyId}")]
        public async Task<ActionResult<SupplyDTO>> GetSupply(int supplyId, string email)
        {
            SupplyDTO supply = await _supply.GetSupply(supplyId, email);
            return supply;
        }

        // PUT: api/Supplies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{supplyId}")]
        public async Task<IActionResult> PutSupply(int supplyId, SupplyDTO supplyDTO, string email)
        {
            if (supplyId != supplyDTO.Id)
            {
                return BadRequest();
            }
            var updatedSupply = await _supply.Update(supplyDTO, email);
            return Ok(updatedSupply);
        }

        // POST: api/Supplies
        // To protect from overposting attacks, enable the specific properties you may want to bind to, for
        // more details, please see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SupplyDTO>> PostSupply(SupplyDTO supply)
        {
            await _supply.Create(supply, GetUserEmail());
            return CreatedAtAction("GetSupply", new { id = supply.Id }, supply);
        }

        // DELETE: api/Supplies/5
        [HttpDelete("{supplyId}")]
        public async Task<ActionResult<SupplyDTO>> DeleteSupply(int supplyId)
        {
            await _supply.Delete(supplyId);
            return NoContent();
        }
        protected string GetUserEmail()
        {
            return User.Claims.First(x => x.Type == "Email").Value;
        }       

    }
}
