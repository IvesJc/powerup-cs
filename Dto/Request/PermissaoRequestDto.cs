namespace PowerUp.Dto.Request;

public record PermissaoRequestDto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public string Descricao { get; init; }
}