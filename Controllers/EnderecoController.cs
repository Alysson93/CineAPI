using CineAPI.Database;
using CineAPI.DTOs;
using CineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController(CineDbContext context) : ControllerBase
{
    private readonly CineDbContext _context = context;
    
    [HttpPost]
    public IActionResult AdicionarEndereco([FromBody] EnderecoRequestDTO dto)
    {
        _context.Enderecos.Add(dto);
        _context.SaveChanges();
        return Created();
    }

    [HttpGet]
    public IActionResult ListarEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 25)
    {
        return Ok(_context.Enderecos.Skip(skip).Take(take));
    }

    [HttpGet("{id:int}")]
    public IActionResult ExibirEnderecoPorId([FromRoute] int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);
        if (endereco is null) return NotFound();
        return Ok(endereco);
    }

    [HttpPut("{id:int}")]
    public IActionResult AtualizarEndereco([FromRoute] int id, [FromBody]EnderecoRequestDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);
        if (endereco is null) return NotFound();
        endereco.SetValues(dto);
        _context.Enderecos.Update(endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletarEndereco([FromRoute] int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);
        if (endereco is null) return NotFound();
        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }

}