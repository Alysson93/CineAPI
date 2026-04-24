using CineAPI.Database;
using CineAPI.DTOs;
using CineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController(CineDbContext context) : ControllerBase
{
    private readonly CineDbContext _context = context;
    
    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CinemaRequestDTO dto)
    {
        _context.Cinemas.Add(dto);
        _context.SaveChanges();
        return Created();
    }

    [HttpGet]
    public IActionResult ListarCinemas([FromQuery] int skip = 0, [FromQuery] int take = 25)
    {
        return Ok(_context.Cinemas.Skip(skip).Take(take));
    }

    [HttpGet("{id:int}")]
    public IActionResult ExibirCinemaPorId([FromRoute] int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
        if (cinema is null) return NotFound();
        return Ok(cinema);
    }

    [HttpPut("{id:int}")]
    public IActionResult AtualizarCinema([FromRoute] int id, [FromBody]CinemaRequestDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
        if (cinema is null) return NotFound();
        cinema.SetValues(dto);
        _context.Cinemas.Update(cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletarCinema([FromRoute] int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
        if (cinema is null) return NotFound();
        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}