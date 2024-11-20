using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("link")]  // Mapeando para a tabela 'link'
    public class LinkModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(500)]  // Ajuste o tamanho conforme o comprimento desejado para o URL
        public string Url { get; set; }

        [StringLength(1000)]  // Ajuste o tamanho conforme necessário para a descrição
        public string Descricao { get; set; }  // Campo opcional para a descrição
    }
}
