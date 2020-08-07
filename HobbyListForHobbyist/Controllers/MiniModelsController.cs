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
        /// <summary>
        /// below makes the minimodel controller public so other files can reference it
        /// </summary>
        /// <param name="miniModel">this is the variable representing the Iminimodel interface</param>
        public MiniModelsController(IMiniModel miniModel)
        {
            _miniModel = miniModel;
        }

        // POST: api/MiniModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// this method allows a user to create a minimodel and add it to the database
        /// </summary>
        /// <param name="miniModel">the variable reprsenting the minimodel dto</param>
        /// <returns>a 201 response that signifies the action was successfully completed</returns>
        [HttpPost]
        public async Task<ActionResult<MiniModelDTO>> PostMiniModel(MiniModelDTO miniModel)
        {
            await _miniModel.Create(miniModel, GetUserEmail());            

            return CreatedAtAction("GetMiniModel", new { id = miniModel.Id }, miniModel);
        }

        // GET: api/MiniModels
        /// <summary>
        /// this method allows a user to display all models within their table based off of the dto properties
        /// </summary>
        /// <returns>all minimodels in the table, only showing the properites outlined in the dto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniModelDTO>>> GetMiniModels()
        {
            List<MiniModelDTO> miniModels = await _miniModel.GetAllMiniModels(GetUserEmail());
            
            return miniModels;
        }

        // GET: api/MiniModels/BuildState/built
        /// <summary>
        /// this method allows a user to see the build state of their models
        /// </summary>
        /// <param name="buildState">the variable representing the enum buildstate</param>
        /// <returns>the buildstate of all minimodels</returns>
        [HttpGet("BuildState/{buildState}")]
        public async Task<ActionResult<IEnumerable<MiniModelDTO>>> GetMiniModelsOfState(BuildState buildState)
        {
            var miniModels = await _miniModel.GetAMiniModelOfState(buildState, GetUserEmail());

            return miniModels;
        }

        // GET: api/MiniModels/5
        /// <summary>
        /// this method allows a user to retrieve data on a specific minimodel
        /// </summary>
        /// <param name="id">the id of the particular minimodel</param>
        /// <returns>the minimodel being researched</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniModelDTO>> GetMiniModel(int id)
        {
            MiniModelDTO miniModel = await _miniModel.GetMiniModel(id, GetUserEmail());

            return miniModel;
        }

        // PUT: api/MiniModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// this method allows a user to augment an existing minimodel's properties
        /// </summary>
        /// <param name="id">the id of the minimodel to augment</param>
        /// <param name="miniModel">the minimodel to be augmented</param>
        /// <returns>status code 200 once method successfully executed</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniModel(int id, MiniModelDTO miniModel)
        {
            if (id != miniModel.Id)
            {
                return BadRequest();
            }

            var updatedMini = await _miniModel.Update(miniModel, id, GetUserEmail());

            return Ok(updatedMini);
        }

        // DELETE: api/MiniModels/5
        /// <summary>
        /// this method allows a user to delete a minimodel from their database
        /// </summary>
        /// <param name="id">the minimodel in question's id</param>
        /// <returns>status code 200 when method works correctly</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MiniModel>> DeleteMiniModel(int id)
        {
            await _miniModel.Delete(id);

            return Ok();
        }

        // POST: api/MiniModels/5/Paint/5
        /// <summary>
        /// this method allows a user to add a paint to their database
        /// </summary>
        /// <param name="miniId">the id of the mini that paint will be added to</param>
        /// <param name="paintId">the id of the paint to be added</param>
        /// <returns>status code 200 when method works correctly</returns>
        [HttpPost("{miniId}/Paint/{paintId}")]
        public async Task<IActionResult> PostPaintToMini(int miniId, int paintId)
        {
            await _miniModel.AddAPaintToAModel(miniId, paintId);
            return Ok();
        }
        /// <summary>
        /// this method allows a user to delete paint from a minimodel object
        /// </summary>
        /// <param name="miniId">the minimodel who will have their paint deleted</param>
        /// <param name="paintId">the paint to be deleted</param>
        /// <returns>status code 200 when method works correctly</returns>
        // DELETE: api/MiniModels/5/Paint/5
        [HttpDelete("{miniId}/Paint/{paintId}")]
        public async Task<IActionResult> DeletePaintFromMini(int miniId, int paintId)
        {
            await _miniModel.RemoveAPaintToAModel(miniId, paintId);
            return Ok();
        }
        /// <summary>
        /// this method allows a user to add a supply item to a minimodel
        /// </summary>
        /// <param name="miniId">the minimodel who will get the new supply item</param>
        /// <param name="supplyId">the specific supply item to be added</param>
        /// <returns>status code 200 when method works correctly</returns>
        // POST: api/MiniModels/5/Supply/5
        [HttpPost("{miniId}/Supply/{supplyId}")]
        public async Task<IActionResult> PostSupplyToMini(int miniId, int supplyId)
        {
            await _miniModel.AddASupplytToAModel(miniId, supplyId);
            return Ok();
        }
        /// <summary>
        /// this method allows a user to delete a supply item from a minimodel
        /// </summary>
        /// <param name="miniId">the minimodel who will have thier supply item deleted</param>
        /// <param name="supplyId">the supply item to be deleted</param>
        /// <returns>status code 200 when method works correctly</returns>
        // DELETE: api/MiniModels/5/Supply/5
        [HttpDelete("{miniId}/Supply/{supplyId}")]
        public async Task<IActionResult> DeleteSupplyFromMini(int miniId, int supplyId)
        {
            await _miniModel.RemoveASupplyToAModel(miniId, supplyId);
            return Ok();
        }
        /// <summary>
        /// this method allows for the user Id to be retrieved for user verification
        /// </summary>
        /// <returns>the user id</returns>
        protected string GetUserId()
        {
            return User.Claims.First(x => x.Type == "UserId").Value;
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
