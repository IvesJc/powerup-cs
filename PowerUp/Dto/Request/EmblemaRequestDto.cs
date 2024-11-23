namespace PowerUp.Dto.Request;

public record EmblemaRequestDto
{
    public int Id { get; init; }
    public int Usuario { get; init; }
    public int EmblemaConfig { get; init; }
}