using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("quiz")]  // Mapeando para a tabela 'quiz'
    public class QuizModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Define o comprimento máximo da string, ajuste conforme necessário
        public string Nome { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(1000)]  // Define o comprimento máximo da string, ajuste conforme necessário
        public string Descricao { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(100)]  // Define o comprimento máximo da string, ajuste conforme necessário
        public string Categoria { get; set; }

        [Required]  // Campo obrigatório
        [Column("nota_minima")]  // Mapeia a coluna 'nota_minima' no banco de dados
        public int NotaMinima { get; set; }

        // Relacionamento com ModuloEducativo (Chave estrangeira 'modulo_educativo_id')
        [Required]  // Campo obrigatório
        [ForeignKey("ModuloEducativoId")]  // Define que a chave estrangeira é a propriedade 'ModuloEducativoId'
        public ModuloEducativoModel ModuloEducativo { get; set; }

        // Propriedade de Chave Estrangeira
        public int ModuloEducativoId { get; set; }
    }
}
