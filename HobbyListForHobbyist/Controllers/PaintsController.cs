using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyListForHobbyist.Data;
using HobbyListForHobbyist.Models;
using HobbyListForHobbyist.Models.Interfaces;
using HobbyListForHobbyist.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HobbyListForHobbyist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaintsController : ControllerBase
    {
        private readonly IPaint _paint;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Injecting the IPaint interface and application user model
        /// </summary>
        /// <param name="paint"> IPaint interface</param>
        /// <param name="userManager"> ApplicationUser</param>
        public PaintsController(IPaint paint, UserManager<ApplicationUser> userManager)
        {
            _paint = paint;
            _userManager = userManager;
        }

        // POST: api/Paints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Creates a new paint
        /// </summary>
        /// <param name="paintdto"> dto object</param>
        /// <returns> created paintdto object </returns>
        [HttpPost]
        public async Task<ActionResult<Paint>> PostPaint(PaintDTO paintdto)
        {
            await _paint.Create(paintdto, GetUserEmail());
            return CreatedAtAction("GetPaint", new { id = paintdto.Id }, paintdto);
        }

        // GET: api/Paints
        /// <summary>
        /// Gets all  paints
        /// </summary>
        /// <returns> all paintdto objects </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaintDTO>>> GetPaints()
        {
            return await _paint.GetPaints(GetUserEmail());
        }

        // GET: api/Paints/5
        /// <summary>
        /// Gets an Paint object by an id
        /// </summary>
        /// <param name="id">integer for id</param>
        /// <returns> a single paintdto object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaintDTO>> GetPaint(int id)
        {
            var paintdto = await _paint.GetPaint(id, GetUserEmail());

            if (paintdto == null)
            {
                return NotFound();
            }

            return paintdto;
        }

        // PUT: api/Paints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Updates a paint
        /// </summary>
        /// <param name="id">integer for id</param>
        /// <param name="paintdto"> dto object</param>
        /// <returns> an updated paintdto object</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaint(int id, PaintDTO paintdto)
        {
            if (id != paintdto.Id)
            {
                return BadRequest();
            }

            var updatedPaintdto = await _paint.Update(paintdto, GetUserEmail());

            return Ok(updatedPaintdto);
        }

        // DELETE: api/Paints/5
        /// <summary>
        /// Deletes a paint
        /// </summary>
        /// <param name="id">integer for id</param>
        /// <returns> could not find deleted paint</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaintDTO>> DeletePaint(int id)
        {
            await _paint.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// gets the user id when a user logs in
        /// </summary>
        /// <returns> the user id</returns>
        protected string GetUserId()
        {
            return User.Claims.First(x => x.Type == "UserId").Value;
        }
        /// <summary>
        /// gets users email when user logs in
        /// </summary>
        /// <returns> the users email</returns>
        protected string GetUserEmail()
        {
            return User.Claims.First(x => x.Type == "Email").Value;
        }
    }
}
