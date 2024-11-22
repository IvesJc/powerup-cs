namespace PowerUp.Dto.Response;

public record MissaoConfigResponseDto
{
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public int Pontos { get; init; }
    public int FrequenciaDias { get; init; }
}