using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("artigo")]  // Mapeando para a tabela 'artigo'
    public class ArtigoModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(500)]  // Tamanho máximo do campo string, ajuste conforme necessário
        public string Titulo { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(500)]  // Tamanho máximo do campo string, ajuste conforme necessário
        public string Subtitulo { get; set; }

        [Required]  // Campo obrigatório
        public string Conteudo { get; set; }

        // Relacionamento com Link (Chave estrangeira 'thumb_link_id')
        [ForeignKey("ThumbLinkId")]
        public LinkModel ThumbLink { get; set; }

        public int ThumbLinkId { get; set; }  // Chave estrangeira para 'Link'

        // Relacionamento com ModuloEducativo (Chave estrangeira 'modulo_educativo_id')
        [ForeignKey("ModuloEducativoId")]
        public ModuloEducativoModel ModuloEducativo { get; set; }

        public int ModuloEducativoId { get; set; }  // Chave estrangeira para 'ModuloEducativo'
    }
}
