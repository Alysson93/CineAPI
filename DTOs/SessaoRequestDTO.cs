using CineAPI.Models;

namespace CineAPI.DTOs;

public record SessaoRequestDTO
(
    int FilmeId
)
{
    public static implicit operator Sessao(SessaoRequestDTO dto)
    {
        return new Sessao
        {
            FilmeId = dto.FilmeId
        };
    }

}