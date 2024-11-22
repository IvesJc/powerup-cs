namespace PowerUp.Dto.Request;

public record PerguntaRequestDto
{
    public int Id { get; init; }
    public string Titulo { get; init; }
    public string Conteudo { get; init; }
    public int Quiz { get; init; }
}