using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("recompensa")]  // Mapeando para a tabela 'recompensa'
    public class Recompensa
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [Column("pontos_utilizados")]  // Mapeia a coluna 'pontos_utilizados'
        public int PontosUtilizados { get; set; }

        // Relacionamento com Usuario (Chave estrangeira 'usuario_id')
        [Required]  // Campo obrigatório
        [ForeignKey("UsuarioId")]  // Define que a chave estrangeira é a propriedade 'UsuarioId'
        public Usuario Usuario { get; set; }

        // Propriedade de Chave Estrangeira
        public int UsuarioId { get; set; }

        // Relacionamento com RecompensaConfig (Chave estrangeira 'recompensa_config_id')
        [Required]  // Campo obrigatório
        [ForeignKey("RecompensaConfigId")]  // Define que a chave estrangeira é a propriedade 'RecompensaConfigId'
        public RecompensaConfig RecompensaConfig { get; set; }

        // Propriedade de Chave Estrangeira
        public int RecompensaConfigId { get; set; }
    }
}
