namespace PowerUp.Dto.Response;

public record PerguntaResponseDto
{
    public string Titulo { get; init; }
    public string Conteudo { get; init; }
    public int Quiz { get; init; }
}