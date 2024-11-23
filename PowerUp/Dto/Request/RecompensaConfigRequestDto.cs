namespace PowerUp.Dto.Request;

public record RecompensaConfigRequestDto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public int CustoPontos { get; set; }
    public int RecompensaTipo { get; set; }
}