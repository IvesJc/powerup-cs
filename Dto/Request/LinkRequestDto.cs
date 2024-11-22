namespace PowerUp.Dto.Request;

public record LinkRequestDto
{
    public int Id { get; init; }
    public string Url { get; init; }
    public string Descricao { get; init; }
}