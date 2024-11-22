namespace PowerUp.Dto.Response;

public record EmblemaConfigResponseDto
{
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public int EmblemaTipo { get; init; }
    public int Quiz { get; init; }
}