using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("pergunta")]  // Mapeando para a tabela 'pergunta'
    public class PerguntaModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Ajuste o comprimento conforme necessário
        public string Titulo { get; set; }

        [Required]  // Campo obrigatório
        public string Conteudo { get; set; }

        // Relacionamento com Quiz (Chave estrangeira 'quiz_id')
        [Required]  // Campo obrigatório
        [ForeignKey("QuizId")]  // Define que a chave estrangeira é a propriedade 'QuizId'
        public QuizModel Quiz { get; set; }

        // Propriedade de Chave Estrangeira
        public int QuizId { get; set; }
    }
}
