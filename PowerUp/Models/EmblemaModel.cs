using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("emblema")]  // Mapeando para a tabela 'emblema'
    public class EmblemaModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        // Relacionamento com Usuario (Chave estrangeira 'usuario_id')
        [ForeignKey("UsuarioId")]
        public UsuarioModel Usuario { get; set; }

        public int UsuarioId { get; set; }  // Chave estrangeira para 'Usuario'

        // Relacionamento com EmblemaConfig (Chave estrangeira 'emblema_config_id')
        [ForeignKey("EmblemaConfigId")]
        public EmblemaConfigModel EmblemaConfig { get; set; }

        public int EmblemaConfigId { get; set; }  // Chave estrangeira para 'EmblemaConfig'
    }
}
