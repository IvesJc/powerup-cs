using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("recompensa_config")]  // Mapeando para a tabela 'recompensa_config'
    public class RecompensaConfig
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Define o comprimento máximo da string, ajuste conforme necessário
        public string Nome { get; set; }

        [Required]  // Campo obrigatório
        [Column("custo_pontos")]  // Mapeia a coluna 'custo_pontos'
        public int CustoPontos { get; set; }

        // Relacionamento com RecompensaTipo (Chave estrangeira 'recompensa_tipo_id')
        [Required]  // Campo obrigatório
        [ForeignKey("RecompensaTipoId")]  // Define que a chave estrangeira é a propriedade 'RecompensaTipoId'
        public RecompensaTipo RecompensaTipo { get; set; }

        // Propriedade de Chave Estrangeira
        public int RecompensaTipoId { get; set; }
    }
}
