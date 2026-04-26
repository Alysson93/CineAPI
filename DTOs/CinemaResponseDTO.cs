namespace CineAPI.DTOs;

public record CinemaResponseDTO
(
    int Id,
    string Nome,
    EnderecoResponseDTO? Endereco
);
