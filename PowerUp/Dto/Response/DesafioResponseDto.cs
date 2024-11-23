namespace PowerUp.Dto.Response;

public record DesafioResponseDto
{
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public int ThumbLink { get; init; }
    public int Quiz { get; init; }
}