namespace PowerUp.Dto.Response;

public record ModuloEducativoResponseDto
{
    public string Titulo { get; init; }
    public string Subtitulo { get; init; }
    public string Descricao { get; init; }
    public int Nivel { get; init; }
    public int ThumbLink { get; init; }
}