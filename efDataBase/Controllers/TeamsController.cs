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
    public class TeamsController : Controller 
    {
        
        private readonly IDbService _dbService;

       
        public TeamsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{idTeam}")]
        public async Task<IActionResult> GetAlbum([FromRoute] int idTeam)
        {
            try
            {
                if (await _dbService.DoesTeamExist(idTeam))
                {
                    return Ok(await _dbService.GetTeam(idTeam));
                }
                else
                {
                    return NotFound("That team doesn't exist");
                }
            }
            catch (Exception)
            {
                return Conflict();
            }
        }



    }
}
