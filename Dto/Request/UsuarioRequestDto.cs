namespace PowerUp.Dto.Request;

public record UsuarioRequestDto
{
    public int Id { get; init; }
    public string FirebaseUid { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public int Ranking { get; set; }
}