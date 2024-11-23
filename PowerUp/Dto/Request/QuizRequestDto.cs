namespace PowerUp.Dto.Request;

public record QuizRequestDto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public string Categoria { get; init; }
    public int NotaMinima { get; init; }
    public int ModuloEducativo { get; init; }
}