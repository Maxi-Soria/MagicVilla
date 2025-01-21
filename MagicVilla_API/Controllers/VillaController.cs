using AutoMapper;
using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        //Get api/villa
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillasAsync()
        {
            _logger.LogInformation("Obtener las Villas");

            IEnumerable<Villa> villasList = await _db.Villas.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<VillaDto>>(villasList));
        }

        //Get api/villa/id
        [HttpGet("id", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<VillaDto>> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("El id no puede ser " + id);
                return BadRequest();
            }

            //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VillaDto>(villa));
        }

        //Post api/villa
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<VillaDto>> CrearVilla([FromBody] VillaCreateDto createDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            if (await _db.Villas.FirstOrDefaultAsync(v => v.Nombre.ToLower() == createDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("Nombre", "El nombre de la villa ya existe");
                return BadRequest(ModelState);

            }

            if (createDto == null)
            {
                return BadRequest(createDto);
            }

            Villa modelo = _mapper.Map<Villa>(createDto);


            await _db.Villas.AddAsync(modelo);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = modelo.Id }, modelo);
        }

        //Delete api/villa/id
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        //Put api/villa/id
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.Id)
            {
                return BadRequest(updateDto);
            }


            Villa modelo = _mapper.Map<Villa>(updateDto);

            _db.Villas.Update(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        //Patch api/villa/id
        [HttpPatch("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

            VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);


            if (villa == null)
            {
                return BadRequest();
            }

            patchDto.ApplyTo(villaDto, ModelState);

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            Villa modelo = _mapper.Map<Villa>(villaDto);

            _db.Villas.Update(modelo);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
