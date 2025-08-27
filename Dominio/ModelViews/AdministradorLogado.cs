namespace minimal_api.Dominio.ModelViews;

public record AdministradorLogado
{
    public string Email { get; set; } = null!;
    public string Perfil { get; set; } = null!;
    public string Token { get; set; } = null!;

}
