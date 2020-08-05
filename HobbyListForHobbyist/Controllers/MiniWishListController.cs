using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HobbyListForHobbyist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [AllowAnonymous]
    public class MiniWishListController : ControllerBase
    {
        private IMiniWishList _wishList;
      

        public MiniWishListController(IMiniWishList wishList)
        {
            _wishList = wishList;
           
        }

        // POST: api/MiniWishList     
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MiniWishListDTO>> PostAllInMiniWishList(MiniWishListDTO wishListDto)
        {

            await _wishList.Create(wishListDto, GetUserId());
            return CreatedAtAction("GetMiniModelInWishList", new { id = wishListDto.Id }, wishListDto);
        }

        // POST: api/MiniWishList/5/miniModel
        [HttpPost ("{id}/miniModel")]
        public async Task<IActionResult> PostMiniWishListToMiniModel(int id)
        {
            await _wishList.AddMiniWishListToMiniModel(GetUserId(), id);
            return Ok();
        }
        // GET: api/MiniWishList 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniWishListDTO>>> GetAllInWishList()
        {
           var  wishListDto =  await _wishList.GetAllMiniModelsInWishList(GetUserId());
            return wishListDto;
        }

        // GET: api/MiniWishList /5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniWishListDTO>> GetMiniInWishList(int id)
        {
            var wishListDto = await _wishList.GetMiniModelInWishList(id, GetUserId());

            if (wishListDto == null)
            {
                return NotFound();
            }

            return wishListDto;
        }

        // PUT: api/MiniWishList /5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniInWishList(int id, MiniWishListDTO wishListDto)
        {
            if (id != wishListDto.Id)
            {
                return BadRequest();
            }

            var updatedWishListDto = await _wishList.Update(wishListDto, id);



            return Ok(updatedWishListDto);
        }

        // DELETE: api/MiniWishList/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MiniWishListDTO>> DeleteMiniWishList(int id)
        {
            await _wishList.Delete(id);
            return NoContent();
        }

        protected string GetUserId()
        {
            return User.Claims.First(x => x.Type == "UserId").Value;
        }

    }
}
