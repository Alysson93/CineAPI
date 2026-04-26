using CineAPI.Database;
using CineAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        return Ok(
            _context.Cinemas
            .AsNoTracking()
            .Include(x => x.Endereco)
            .Skip(skip).Take(take)
            .Select(x => new CinemaResponseDTO(x.Id, x.Nome, x.Endereco))
        );
    }

    [HttpGet("{id:int}")]
    public IActionResult ExibirCinemaPorId([FromRoute] int id)
    {
        var cinema = _context.Cinemas
            .Include(x => x.Endereco)
            .FirstOrDefault(x => x.Id == id);
        if (cinema is null) return NotFound();
        return Ok(new CinemaResponseDTO(cinema.Id, cinema.Nome, cinema.Endereco));
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