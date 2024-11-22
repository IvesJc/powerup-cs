namespace PowerUp.Dto.Response;

public record AlternativaResponseDto
{
    public string Descricao { get; init; }
    public bool ECorreta { get; init; }
    public int Pergunta { get; init; }
}