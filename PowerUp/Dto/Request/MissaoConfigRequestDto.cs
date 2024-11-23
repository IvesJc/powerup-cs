namespace PowerUp.Dto.Request;

public record MissaoConfigRequestDto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public int Pontos { get; init; }
    public int FrequenciaDias { get; init; }
}