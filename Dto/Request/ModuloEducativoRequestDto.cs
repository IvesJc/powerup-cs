namespace PowerUp.Dto.Request;

public record ModuloEducativoRequestDto
{
    public int Id { get; init; }
    public string Titulo { get; init; }
    public string Subtitulo { get; init; }
    public string Descricao { get; init; }
    public int Nivel { get; init; }
    public int ThumbLink { get; init; }
}