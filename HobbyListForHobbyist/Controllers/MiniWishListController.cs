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
   [Authorize]
    public class MiniWishListController : ControllerBase
    {
        private IMiniWishList _wishList;

        /// <summary>
        /// injects the IMiniWIshList interface into the controller
        /// </summary>
        /// <param name="wishList"> IMiniWIshList interface</param>
        public MiniWishListController(IMiniWishList wishList)
        {
            _wishList = wishList;
           
        }

        // POST: api/MiniWishList     
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Creates a miniWishList 
        /// </summary>
        /// <param name="wishListDto">dto object</param>
        /// <returns> created wishListDto object</returns>
        [HttpPost]
        public async Task<ActionResult<MiniWishListDTO>> PostAllInMiniWishList(MiniWishListDTO wishListDto)
        {
            await _wishList.Create(wishListDto, GetUserEmail());
            return CreatedAtAction("GetMiniModelInWishList", new { id = wishListDto.Id }, wishListDto);
        }

        // POST: api/MiniWishList/5/miniModel
        /// <summary>
        /// Adds a miniwishList to miniModel from wishList
        /// </summary>
        /// <param name="id">integer for id</param>
        /// <returns> task completion</returns>
        [HttpPost ("{id}/miniModel")]
        public async Task<IActionResult> PostMiniWishListToMiniModel(int id)
        {
            await _wishList.AddMiniWishListToMiniModel(GetUserEmail(), id);
            return Ok();
        }

        // GET: api/MiniWishList 
        /// <summary>
        /// Gets all mini models in the wish list
        /// </summary>
        /// <returns> all wishListdto objects </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniWishListDTO>>> GetAllInWishList()
        {
           var  wishListDto =  await _wishList.GetAllMiniModelsInWishList(GetUserEmail());
            return wishListDto;
        }

        // GET: api/MiniWishList/5
        /// <summary>
        /// Gets a single mini model in the wishList by id
        /// </summary>
        /// <param name="id"> integer for id</param>
        /// <returns> single wishListdto object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniWishListDTO>> GetMiniInWishList(int id)
        {
            var wishListDto = await _wishList.GetMiniModelInWishList(id, GetUserEmail());

            if (wishListDto == null)
            {
                return NotFound();
            }

            return wishListDto;
        }

        // PUT: api/MiniWishList /5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Updates a mini model in the wishList
        /// </summary>
        /// <param name="wishListDto"> dto object</param>
        /// <param name="id">integer for id</param>
        /// <returns> task completion and the updated wishListDto object </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniInWishList( MiniWishListDTO wishListDto, int id)
        {
            if (id != wishListDto.Id)
            {
                return BadRequest();
            }

            var updatedWishListDto = await _wishList.Update(wishListDto, id, GetUserEmail());
            return Ok(updatedWishListDto);
        }

        // DELETE: api/MiniWishList/5
        /// <summary>
        /// Deletes a mini model in a wishList by an id
        /// </summary>
        /// <param name="id"> integer for id</param>
        /// <returns> could not find deleted wishListdto object</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MiniWishListDTO>> DeleteMiniWishList(int id)
        {
            await _wishList.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// gets users id when user logs in
        /// </summary>
        /// <returns> the users id</returns>
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
