namespace PowerUp.Dto.Request;

public record AlternativaRequestDto
{
    public int Id { get; init; }
    public string Descricao { get; init; }
    public bool ECorreta { get; init; }
    public int Pergunta { get; init; }
}