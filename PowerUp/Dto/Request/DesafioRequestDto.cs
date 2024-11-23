namespace PowerUp.Dto.Request;

public record DesafioRequestDto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public int ThumbLink { get; init; }
    public int Quiz { get; init; }
}