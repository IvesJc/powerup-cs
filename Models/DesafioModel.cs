using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("desafio")]  // Mapeando para a tabela 'desafio'
    public class DesafioModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(500)]  // Tamanho máximo do campo string, ajuste conforme necessário
        public string Nome { get; set; }

        [Required]  // Campo obrigatório
        public string Descricao { get; set; }

        // Relacionamento com Link (Chave estrangeira 'thumb_link_id')
        [ForeignKey("ThumbLinkId")]
        public LinkModel ThumbLink { get; set; }

        public int ThumbLinkId { get; set; }  // Chave estrangeira para 'Link'

        // Relacionamento com Quiz (Chave estrangeira 'quiz_id')
        [ForeignKey("QuizId")]
        public QuizModel Quiz { get; set; }

        public int QuizId { get; set; }  // Chave estrangeira para 'Quiz'
    }
}
