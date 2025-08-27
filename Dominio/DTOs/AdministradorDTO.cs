using minimal_api.Dominio.Enums;

namespace MinimalApi.DTOs;

public record AdministradorDTO
{
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public Perfil? Perfil { get; set; }
}
