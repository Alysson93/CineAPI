using System.ComponentModel.DataAnnotations;
using CineAPI.DTOs;

namespace CineAPI.Models;

public class Endereco
{
    
    [Key] [Required]
    public int Id { get; set; }

    [Required]
    public string Logradouro { get; set; } = string.Empty;

    public string? Numero { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public void SetValues(EnderecoRequestDTO dto)
    {
        Logradouro = dto.Logradouro;
        Numero = dto.Numero;
    }

    public static implicit operator EnderecoResponseDTO(Endereco endereco)
    {
        return new EnderecoResponseDTO(endereco.Id, endereco.Logradouro, endereco.Numero);
    }

}