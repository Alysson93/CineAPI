using CineAPI.Database;
using CineAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController(CineDbContext context) : ControllerBase
{
    private readonly CineDbContext _context = context;
    
    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] FilmeRequestDTO dto)
    {
        _context.Filmes.Add(dto);
        _context.SaveChanges();
        return Created();
    }

    [HttpGet]
    public IActionResult ListarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 25)
    {
        return Ok(_context.Filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id:int}")]
    public IActionResult ExibirFilmePorId([FromRoute] int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme is null) return NotFound();
        return Ok(filme);
    }

    [HttpPut("{id:int}")]
    public IActionResult AtualizarFilme([FromRoute] int id, [FromBody]FilmeRequestDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme is null) return NotFound();
        filme.SetValues(dto);
        _context.Filmes.Update(filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletarFilme([FromRoute] int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme is null) return NotFound();
        _context.Filmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}