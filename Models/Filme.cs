using System.ComponentModel.DataAnnotations;
using CineAPI.DTOs;

namespace CineAPI.Models;

public class Filme
{
    [Key] [Required]
    public int Id { get; set; }

    [Required] [MaxLength(50)]
    public string Titulo { get; set; } = string.Empty;
    
    [Required] [MaxLength(20)]
    public string Genero { get; set; } = string.Empty;
    
    [Required] [Range(20, 240)]
    public int Duracao { get; set; }

    public void SetValues(FilmeRequestDTO dto)
    {
        Titulo = dto.Titulo;
        Genero = dto.Genero;
        Duracao = dto.Duracao;
    }

}