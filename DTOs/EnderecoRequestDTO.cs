using System.ComponentModel.DataAnnotations;
using CineAPI.Models;

namespace CineAPI.DTOs;

public record EnderecoRequestDTO
(
    [Required(ErrorMessage = "Logradouro é um campo obrigatório")]
    string Logradouro,
    string? Numero = null
)
{
    public static implicit operator Endereco(EnderecoRequestDTO dto)
    {
        return new Endereco
        {            
           Logradouro = dto.Logradouro,
           Numero = dto.Numero
        };
    }

}