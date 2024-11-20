using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("missao")]  // Mapeando para a tabela 'missao'
    public class MissaoModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [Column("recompensa_pontos")]  // Mapeando para a coluna 'recompensa_pontos'
        public int RecompensaPontos { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(50)]  // Ajuste o comprimento conforme necessário
        public string Status { get; set; }

        // Relacionamento com MissaoConfig (Chave estrangeira 'missao_config_id')
        [ForeignKey("MissaoConfigId")]
        public MissaoConfigModel MissaoConfig { get; set; }

        public int MissaoConfigId { get; set; }  // Chave estrangeira para 'MissaoConfig'

        // Relacionamento com Usuario (Chave estrangeira 'usuario_id')
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }  // Chave estrangeira para 'Usuario'
    }
}
