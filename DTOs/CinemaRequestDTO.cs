using System.ComponentModel.DataAnnotations;
using CineAPI.Models;

namespace CineAPI.DTOs;

public record CinemaRequestDTO
(
    [Required(ErrorMessage = "Nome é um campo obrigatório")]
    [MaxLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres")]
    string Nome,
    int EnderecoId
)
{
    public static implicit operator Cinema(CinemaRequestDTO dto)
    {
        return new Cinema
        {            
            Nome = dto.Nome,
            EnderecoId = dto.EnderecoId
        };
    }

}
