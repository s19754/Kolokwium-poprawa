using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using efDataBase.Models;
using efDataBase.Services;
using efDataBase.Models.DTO;

namespace efDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : Controller 
    {
        
        private readonly IDbService _dbService;

       
        public AlbumsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{idAlbum}")]
        public async Task<IActionResult> GetAlbum([FromRoute] int idAlbum)
        {
            try
            {
                if (await _dbService.DoesAlbumExist(idAlbum))
                {
                    return Ok(await _dbService.GetAlbum(idAlbum));
                }
                else
                {
                    return NotFound("That album doesn't exist");
                }
            }
            catch (Exception)
            {
                return Conflict();
            }
        }



    }
}
