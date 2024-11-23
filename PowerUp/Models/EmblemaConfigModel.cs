using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("emblema_config")]  // Mapeando para a tabela 'emblema_config'
    public class EmblemaConfigModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Ajuste conforme o comprimento desejado
        public string Nome { get; set; }

        [Required]  // Campo obrigatório
        public string Descricao { get; set; }

        // Relacionamento com EmblemaTipo (Chave estrangeira 'emblema_tipo_id')
        [ForeignKey("EmblemaTipoId")]
        public EmblemaTipoModel EmblemaTipo { get; set; }

        public int EmblemaTipoId { get; set; }  // Chave estrangeira para 'EmblemaTipo'

        // Relacionamento com Quiz (Chave estrangeira 'quiz_id')
        [ForeignKey("QuizId")]
        public QuizModel Quiz { get; set; }

        public int QuizId { get; set; }  // Chave estrangeira para 'Quiz'
    }
}
