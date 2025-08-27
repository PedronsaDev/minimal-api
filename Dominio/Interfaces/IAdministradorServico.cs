using minimal_api.Dominio.Entidades;
using MinimalApi.DTOs;

namespace minimal_api.Infraestrutura.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO login);
    void Incluir(Administrador administrador);
    List<Administrador> Todos(int? pagina);
    Administrador? BuscaPorId(int id);
}
