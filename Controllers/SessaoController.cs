using CineAPI.Database;
using CineAPI.DTOs;
using CineAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController(CineDbContext context) : ControllerBase
{
    private readonly CineDbContext _context = context;
    
    [HttpPost]
    public IActionResult AdicionarSessao([FromBody] SessaoRequestDTO dto)
    {
        _context.Sessoes.Add(dto);
        _context.SaveChanges();
        return Created();
    }

    [HttpGet]
    public IActionResult ListarSessoes([FromQuery] int skip = 0, [FromQuery] int take = 25)
    {
        return Ok(
            _context.Sessoes
            .AsNoTracking()
            .Skip(skip).Take(take)
        );
    }

    [HttpGet("{id:int}")]
    public IActionResult ExibirSessaoPorId([FromRoute] int id)
    {
        var sessao = _context.Sessoes
            .FirstOrDefault(x => x.Id == id);
        if (sessao is null) return NotFound();
        return Ok(new SessaoResponseDTO(sessao.Id));
    }

    // [HttpPut("{id:int}")]
    // public IActionResult AtualizarSessao([FromRoute] int id, [FromBody]SessaoRequestDTO dto)
    // {
    //     if (!ModelState.IsValid) return BadRequest(ModelState);
    //     var Sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);
    //     if (Sessao is null) return NotFound();
    //     Sessao.SetValues(dto);
    //     _context.Sessoes.Update(Sessao);
    //     _context.SaveChanges();
    //     return NoContent();
    // }

    [HttpDelete("{id:int}")]
    public IActionResult DeletarSessao([FromRoute] int id)
    {
        var sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);
        if (sessao is null) return NotFound();
        _context.Sessoes.Remove(sessao);
        _context.SaveChanges();
        return NoContent();
    }

}