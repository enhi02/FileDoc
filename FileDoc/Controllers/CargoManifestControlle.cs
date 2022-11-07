using FileDoc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDoc.Models;
using FileDoc.Models.ViewModel;
//using FileDoc.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using FileDoc.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FileDoc.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CargoManifestControlle : ControllerBase
    {
        private readonly ICargoManifest _cargoManifest;
        private readonly DataContext _context;
        public CargoManifestControlle(DataContext context, ICargoManifest cargoManifest)
        {
            _context = context;
            _cargoManifest = cargoManifest;
        }
        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<int>> AddCargoManifest(CargoManifest cargo)
        {
            try
            {
                await _cargoManifest.AddCargoManifest(cargo);
            }
            catch (Exception ex)
            {

            }
            return Ok(new
            {
                retCode = 1,
                retText = "Thêm thành công"
            });
        }
        [HttpGet]
        [Route("ListCargoManifest")]
        public async Task<ActionResult<IEnumerable<CargoManifest>>> GetCargoManifestAllAsync()
        {
            return await _cargoManifest.GetCargoManifestAll();

        }
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> PutCargoManifest(int id, CargoManifest cargo)
        {
            if (id != cargo.FlightId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _cargoManifest.EditCargoManifest(id, cargo);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoManifestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Sửa thành công"
                 });
        }
        private bool CargoManifestExists(int id)
        {
            return _context.cargoManifests.Any(e => e.FlightId == id);

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteCargoManifest(int id)
        {
            var CargoManifest = await _context.cargoManifests.FindAsync(id);
            if (CargoManifest == null)
            {
                return NotFound();
            }

            _context.cargoManifests.Remove(CargoManifest);
            await _context.SaveChangesAsync();

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Xóa thành công"
                 });
        }
    }
}
