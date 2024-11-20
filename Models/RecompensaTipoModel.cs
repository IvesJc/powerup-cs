using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("recompensa_tipo")]  // Mapeando para a tabela 'recompensa_tipo'
    public class RecompensaTipo
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Define o comprimento máximo da string, ajuste conforme necessário
        public string Nome { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(500)]  // Define o comprimento máximo da string para a descrição, ajuste conforme necessário
        public string Descricao { get; set; }
    }
}
