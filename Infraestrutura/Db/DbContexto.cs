using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configurataoAppSettings;

    public DbContexto(IConfiguration configurataoAppSettings)
    {
        _configurataoAppSettings = configurataoAppSettings;
    }

    public DbSet<Administrador> Administradores { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var stringConexao = _configurataoAppSettings.GetConnectionString("mysql")?.ToString();
        if (!string.IsNullOrEmpty(stringConexao))
        {
            optionsBuilder.UseMySql(
                stringConexao,
                ServerVersion.AutoDetect(stringConexao)
            );
        }
    }
}
