namespace PowerUp.Dto.Response;

public record RecompensaConfigResponseDto
{
    public string Nome { get; init; }
    public int CustoPontos { get; set; }
    public int RecompensaTipo { get; set; }
}