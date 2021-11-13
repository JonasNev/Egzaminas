using Microsoft.AspNetCore.Mvc;
using PostalService.Models;
using PostalService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : Controller
    {
        private readonly ParcelService _parcelService;

        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcel>>> GetParcels()
        {
            return await _parcelService.GetAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Parcel>> GetParcel(int id)
        {
            var parcel = await _parcelService.GetByIdAsync(id);

            if (parcel == null)
            {
                return NotFound();
            }

            return parcel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcel(Parcel parcel)
        {
            await _parcelService.UpdateAsync(parcel);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Parcel>> AddParcel(Parcel parcel)
        {
            await _parcelService.AddAsync(parcel);

            return CreatedAtAction("GetParcel", new { id = parcel.Id }, parcel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParcel(int id)
        {
            await _parcelService.DeleteAsync(id);

            return NoContent();
        }
    }
}
