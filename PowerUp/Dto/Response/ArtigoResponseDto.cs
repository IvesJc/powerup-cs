namespace PowerUp.Dto.Response;

public record ArtigoResponseDto
{
    public string Titulo { get; init; }
    public string Subtitulo { get; init; }
    public string Conteudo { get; init; }
    public int ThumbLink { get; init; }
    public int ModuloEducativo { get; init; }
}