using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("usuario")]  // Mapeando para a tabela 'usuario'
    public class UsuarioModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Define o comprimento máximo da string
        [Column("firebase_uid")]  // Mapeia a coluna 'firebase_uid'
        public string FirebaseUid { get; set; }

        [Required]  // Campo obrigatório
        [EmailAddress]  // Valida se o formato do e-mail é válido
        [StringLength(255)]  // Define o comprimento máximo da string
        public string Email { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Define o comprimento máximo da string
        public string Nome { get; set; }

        // Relacionamento com Ranking (Chave estrangeira 'ranking_id')
        public int? RankingId { get; set; }  // Usamos int? para permitir valor nulo (caso o Ranking não seja obrigatório)

        // Propriedade de navegação para Ranking
        public RankingModel Ranking { get; set; }
    }
}
