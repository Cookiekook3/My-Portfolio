using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Models;
using VideoGameApi.Services;

namespace VideoGameApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideogamesController : ControllerBase


    {
        private readonly IVideogameRepository _videogameRepository;

        public VideogamesController(IVideogameRepository videogameRepository)
        {
            _videogameRepository = videogameRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _videogameRepository.GetVideogamesAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, string genre)
        {
            var result = await _videogameRepository.GetVideogameAsync(id, genre);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Videogame videogame)
        {
            var result = await _videogameRepository.CreateVideogameAsync(videogame);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Videogame videogame)
        {
            var result = await _videogameRepository.UpdateVideogameAsync(id, videogame);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, string genre)
        {
            var result = await _videogameRepository.DeleteVideogame(id, genre);

            if (result)
                return NoContent();

            return BadRequest();
        }
    }
}
 
