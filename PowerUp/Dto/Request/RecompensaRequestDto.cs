namespace PowerUp.Dto.Request;

public record RecompensaRequestDto
{
    public int Id { get; init; }
    public int PontosUtilizados { get; set; }
    public int Usuario { get; set; }
    public int RecompensaConfig { get; set; }
}