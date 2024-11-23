namespace PowerUp.Dto.Response;

public record QuizResponseDto
{
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public string Categoria { get; init; }
    public int NotaMinima { get; init; }
    public int ModuloEducativo { get; init; }
}