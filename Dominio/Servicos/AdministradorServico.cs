using minimal_api.Dominio.Entidades;
using minimal_api.Infraestrutura.Interfaces;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace minimal_api.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    public AdministradorServico(DbContexto contexto) => _contexto = contexto;
    public Administrador? Login(LoginDTO login)
    {
        Administrador? adm = _contexto.Administradores.FirstOrDefault(a => a.Email == login.Email && a.Senha == login.Senha);

        return adm;
    }
    public void Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();
    }
    public List<Administrador> Todos(int? pagina = 1)
    {
        IQueryable<Administrador> query = _contexto.Administradores.AsQueryable();
        int itensPorPargina = 10;

        if (pagina != null)
            query = query.Skip(((int)pagina - 1)*itensPorPargina).Take(itensPorPargina);

        return query.ToList();
    }
    public Administrador? BuscaPorId(int id) => _contexto.Administradores.FirstOrDefault(a => a.Id == id);
}
