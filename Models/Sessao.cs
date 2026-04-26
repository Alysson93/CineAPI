using System.ComponentModel.DataAnnotations;
using CineAPI.DTOs;

namespace CineAPI.Models;

public class Sessao
{
    
    [Key] [Required]
    public int Id { get; set; }

    public int FilmeId { get; set; }
    public virtual Filme? Filme { get; set; }

    public void SetValues(SessaoRequestDTO dto)
    {
        FilmeId = dto.FilmeId;
    }

}