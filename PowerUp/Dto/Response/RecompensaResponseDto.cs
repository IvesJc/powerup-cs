namespace PowerUp.Dto.Response;

public record RecompensaResponseDto
{
    public int PontosUtilizados { get; set; }
    public int Usuario { get; set; }
    public int RecompensaConfig { get; set; }
}