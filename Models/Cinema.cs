using System.ComponentModel.DataAnnotations;
using CineAPI.DTOs;

namespace CineAPI.Models;

public class Cinema
{
    
    [Key] [Required]
    public int Id { get; set; }

    [Required] [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    public int EnderecoId { get; set; }
    public virtual Endereco? Endereco { get; set; }

    public void SetValues(CinemaRequestDTO dto)
    {
        Nome = dto.Nome;
    }

}