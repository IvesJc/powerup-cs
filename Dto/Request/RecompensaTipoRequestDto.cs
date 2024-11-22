namespace PowerUp.Dto.Request;

public record RecompensaTipoRequestDto
{
    public int Id { get; init; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
}