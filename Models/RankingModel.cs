using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("ranking")]  // Mapeando para a tabela 'ranking'
    public class RankingModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Define o comprimento máximo da string, ajuste conforme necessário
        public string Nome { get; set; }
    }
}
