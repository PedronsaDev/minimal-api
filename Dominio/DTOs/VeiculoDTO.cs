namespace MinimalApi.DTOs;

public record VeiculoDTO
{
    public string Nome { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public int Ano { get; set; } = 0!;
}
