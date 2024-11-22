namespace PowerUp.Dto.Response;

public record UsuarioResponseDto
{
    public string FirebaseUid { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public int Ranking { get; set; }
}