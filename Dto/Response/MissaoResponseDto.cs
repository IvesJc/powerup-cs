namespace PowerUp.Dto.Response;

public record MissaoResponseDto
{
    public int RecompensaPontos { get; init; }
    public string Status { get; init; }
    public int MissaoConfig { get; init; }
    public int Usuario { get; init; }
}