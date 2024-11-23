using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("ALTERNATIVA")]  // Mapeando para a tabela 'alternativa'
    public class AlternativaModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Define que o valor é gerado automaticamente
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(500)]  // Tamanho máximo do campo string, ajuste conforme necessário
        [Column("descricao")]
        public string? Descricao { get; set; }

        [Required]  // Campo obrigatório
        [Column("e_correta")]  // Mapeando a coluna com nome diferente
        public bool ECorreta { get; set; }

        // Relacionamento com Pergunta
        [ForeignKey("PerguntaId")]
        public PerguntaModel? Pergunta { get; set; }

        public int PerguntaId { get; set; }  // Chave estrangeira para a tabela 'pergunta'
    }
}
