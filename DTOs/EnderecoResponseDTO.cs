using CineAPI.Models;

namespace CineAPI.DTOs;

public record EnderecoResponseDTO
(
    int Id,
    string Logradouro,
    string? Numero = null
);
