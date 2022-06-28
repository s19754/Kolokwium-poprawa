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
    public class MusiciansController : Controller
    {
        
        private readonly IDbService _dbService;

       
        public MusiciansController(IDbService dbService)
        {
            _dbService = dbService;
        }

        //[HttpPut]
        //[Route("{idKlienta}/orders")]
        //public async Task<IActionResult> EditDoctor([FromBody] AddZamowienie addZamowienie, [FromRoute] int idKlienta)
        //{
        //    try
        //    {
        //        if (!await _dbService.DoesKlientExist(idKlienta)) return NotFound("Klient o podanym id nie istnieje");
        //        if (addZamowienie.WyrobyCukiernicze.Count() < 1) return BadRequest("Nie podano żadnych wyrobów cukierniczych");

        //        if (!await _dbService.CheckWyroby(addZamowienie.WyrobyCukiernicze)) return NotFound("Podany wyrób nie istnieje");
        //        if (!await _dbService.AddZamowienie(idKlienta, addZamowienie)) return Conflict();
        //        return Ok("Dodano nowe zamówienie");
        //    }
        //    catch (System.Exception)
        //    {
        //        return Conflict();
        //    }
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetDoctors()
        //{
        //    var doctors = await _dbService.GetDoctors();
        //    return Ok(doctors);
        //}

        [HttpDelete]
        [Route("{idMusician}")]
        public async Task<IActionResult> DeleteMusician([FromRoute] int idMusician)
        {
            try
            {
                if (await _dbService.DoesMusicianExist(idMusician))
                {

                    if (await _dbService.DeleteMusician(idMusician)) { 
                    return Ok("Musician is removed");
                }
                else
                {
                        return BadRequest("Musician cannot be removed");
                      
                    }
                }
                else
                {
                    return NotFound("That musician doesn't exist");
                }
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        //[HttpPut]
        //[Route("{idDoctor}")]
        //public async Task<IActionResult> EditDoctor([FromBody] SomeSortOfDoctor doctor, [FromRoute] int idDoctor)
        //{
        //    try
        //    {
        //        var result = await _dbService.EditDoctor(doctor, idDoctor);
        //        return Ok(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound(e.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddDoctor([FromBody] SomeSortOfDoctor doctor)
        //{
        //    try
        //    {
        //        var result = await _dbService.AddDoctor(doctor);
        //        return Ok(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound(e.Message);
        //    }
        //}


    }
}
