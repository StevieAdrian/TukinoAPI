using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TukinoAPI.Model;

namespace TukinoAPI.Controllers
{
  
  [ApiController]
  [Route("api/[Controller]")]

  public class AnimeController : ControllerBase 
  {
    private readonly AppDbContext _context;
    public AnimeController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimeById (int id)
    {
      var anime = await _context.Animes.FindAsync(id);
      if (anime == null){
        return NotFound();
      }

      return Ok(anime);
    }


    [HttpPost]
    public async Task<ActionResult> CreateAnime([FromBody] Anime newAnime)
    {
      if (newAnime == null){
        return BadRequest();
      }

      _context.Animes.Add(newAnime);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetAnimeById), new { id = newAnime.Id }, newAnime);
    }
  }
}