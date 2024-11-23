namespace PowerUp.Dto.Request;

public record MissaoRequestDto
{
    public int Id { get; init; }
    public int RecompensaPontos { get; init; }
    public string Status { get; init; }
    public int MissaoConfig { get; init; }
    public int Usuario { get; init; }
}