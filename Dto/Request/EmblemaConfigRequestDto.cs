namespace PowerUp.Dto.Request;

public record EmblemaConfigRequestDto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public int EmblemaTipo { get; init; }
    public int Quiz { get; init; }
}