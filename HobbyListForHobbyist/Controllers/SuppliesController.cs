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
using System.Dynamic;

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
        /// <summary>
        /// this method allows a user to display all supplies within their table based off of the dto properties
        /// </summary>
        /// <returns>all supplies in the table, only showing the properites outlined in the dto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplyDTO>>> GetSupply()
        {
            return await _supply.GetSupplies(GetUserEmail());
        }

        // GET: api/Supplies/5
        /// <summary>
        /// this method allows a user to retrieve data on a specific supply item
        /// </summary>
        /// <param name="id">the id of the particular supply item</param>
        /// <returns>the supply item being researched</returns>
        [HttpGet("{supplyId}")]
        public async Task<ActionResult<SupplyDTO>> GetSupply(int supplyId)
        {
            SupplyDTO supply = await _supply.GetSupply(supplyId, GetUserEmail());
            return supply;
        }

        // PUT: api/Supplies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// this method allows a user to augment an existing supply item's properties
        /// </summary>
        /// <param name="id">the id of the supply item to augment</param>
        /// <param name="miniModel">the supply item to be augmented</param>
        /// <returns>status code 200 once method successfully executed</returns>
        [HttpPut("{supplyId}")]
        public async Task<IActionResult> PutSupply(int supplyId, SupplyDTO supplyDTO)
        {
            if (supplyId != supplyDTO.Id)
            {
                return BadRequest();
            }

            var updatedSupply = await _supply.Update(supplyDTO, GetUserEmail());
            return Ok(updatedSupply);
        }

        // POST: api/Supplies
        // To protect from overposting attacks, enable the specific properties you may want to bind to, for
        // more details, please see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// this method allows a user to create a new supply item
        /// </summary>
        /// <param name="supply">the variable representing the supply dto</param>
        /// <returns>status code 201 that the operation worked</returns>
        [HttpPost]
        public async Task<ActionResult<SupplyDTO>> PostSupply(SupplyDTO supply)
        {
            await _supply.Create(supply, GetUserEmail());
            return CreatedAtAction("GetSupply", new { id = supply.Id }, supply);
        }

        // DELETE: api/Supplies/5
        /// <summary>
        /// this method allows a user to delete a supply item from their database
        /// </summary>
        /// <param name="id">the supply item in question's id</param>
        /// <returns>status code 200 when method works correctly</returns>
        [HttpDelete("{supplyId}")]
        public async Task<ActionResult<SupplyDTO>> DeleteSupply(int supplyId)
        {
            await _supply.Delete(supplyId);
            return NoContent();
        }
        /// <summary>
        /// this method allows for the user email to be retrieved for id verification
        /// </summary>
        /// <returns>the user email</returns>
        protected string GetUserEmail()
        {
            return User.Claims.First(x => x.Type == "Email").Value;
        }      
    }
}
