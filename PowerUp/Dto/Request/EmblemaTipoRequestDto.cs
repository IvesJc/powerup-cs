namespace PowerUp.Dto.Request;

public record EmblemaTipoRequestDto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public int ImageLink { get; init; }
}