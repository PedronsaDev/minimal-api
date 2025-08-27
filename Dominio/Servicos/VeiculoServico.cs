using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;
using minimal_api.Infraestrutura.Interfaces;
using MinimalApi.Infraestrutura.Db;

namespace minimal_api.Dominio.Servicos;

public class VeiculoServico : IVeiculoServico
{
    private readonly DbContexto _contexto;

    public VeiculoServico(DbContexto contexto) => _contexto = contexto;

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        IQueryable<Veiculo> query = _contexto.Veiculos.AsQueryable();

        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome.ToLower()}%"));
        }

        int itensPorPargina = 10;

        if (pagina != null)
            query = query.Skip(((int)pagina - 1)*itensPorPargina).Take(itensPorPargina);

        return query.ToList();
    }

    public Veiculo? BuscaPorId(int id) => _contexto.Veiculos.FirstOrDefault(v => v.Id == id);

    public void Incluir(Veiculo veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();
    }

    public void Apagar(Veiculo veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();
    }
}
