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

namespace HobbyListForHobbyist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintsController : ControllerBase
    {
        private readonly IPaint _paint;

        public PaintsController(IPaint paint)
        {
           
            _paint = paint;
        }

        // GET: api/Paints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaintDTO>>> GetPaints()
        {
            return await _paint.GetPaints();
        }

        // GET: api/Paints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaintDTO>> GetPaint(int id)
        {
            var paintdto = await _paint.GetPaint(id);

            if (paintdto == null)
            {
                return NotFound();
            }

            return paintdto;
        }

        // PUT: api/Paints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaint(int id, PaintDTO paintdto)
        {
            if (id != paintdto.Id)
            {
                return BadRequest();
            }

            var updatedPaintdto = await _paint.Update(paintdto);

          

            return Ok(updatedPaintdto);
        }

        // POST: api/Paints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paint>> PostPaint(PaintDTO paintdto)
        {

            await _paint.Create(paintdto);
            return CreatedAtAction("GetPaint", new { id = paintdto.Id }, paintdto);
        }

        // DELETE: api/Paints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaintDTO>> DeletePaint(int id)
        {
            await _paint.Delete(id);
                return NoContent();
        }

       
    }
}
