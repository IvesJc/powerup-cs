using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("modulo_educativo")]  // Mapeando para a tabela 'modulo_educativo'
    public class ModuloEducativoModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Ajuste o comprimento conforme necessário
        public string Titulo { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Ajuste o comprimento conforme necessário
        public string Subtitulo { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(1000)]  // Ajuste o comprimento conforme necessário
        public string Descricao { get; set; }

        [Required]  // Campo obrigatório
        public int Nivel { get; set; }

        // Relacionamento com Link (Chave estrangeira 'thumb_link_id')
        [Required]  // Campo obrigatório
        [ForeignKey("ThumbLinkId")]  // Define que a chave estrangeira é a propriedade 'ThumbLinkId'
        public LinkModel ThumbLink { get; set; }

        // Propriedade de Chave Estrangeira
        public int ThumbLinkId { get; set; }
    }
}
