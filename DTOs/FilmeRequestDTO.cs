using System.ComponentModel.DataAnnotations;
using CineAPI.Models;

namespace CineAPI.DTOs;

public record FilmeRequestDTO
(
    [Required(ErrorMessage = "Título é um campo obrigatório")]
    [MaxLength(50, ErrorMessage = "Título não pode ter mais de 50 caracteres")]
    string Titulo,

    [Required(ErrorMessage = "Gênero é um campo obrigatório")]
    [MaxLength(20, ErrorMessage = "Gênero não pode ter mais de 20 caracteres")]
    string Genero,

    [Required(ErrorMessage = "Duração é um campo obrigatório")]
    [Range(20, 240, ErrorMessage = "A duração deve ter entre 20 e 240 minutos")]
    int Duracao
)
{
    public static implicit operator Filme(FilmeRequestDTO dto)
    {
        return new Filme
        {            
            Titulo = dto.Titulo,
            Genero = dto.Genero,
            Duracao = dto.Duracao
        };
    }

}