using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("emblema_tipo")]  // Mapeando para a tabela 'emblema_tipo'
    public class EmblemaTipoModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Ajuste conforme o comprimento desejado
        public string Nome { get; set; }

        // Relacionamento com Link (Chave estrangeira 'image_link_id')
        [ForeignKey("ImageLinkId")]
        public LinkModel ImageLink { get; set; }

        public int ImageLinkId { get; set; }  // Chave estrangeira para 'Link'
    }
}
