using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("permissao")]  // Mapeando para a tabela 'permissao'
    public class Permissao
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(50)]  // Define o comprimento máximo da string
        [Index(IsUnique =true)]  // Define a propriedade 'nome' como única
        public string Nome { get; set; }

        // Descrição da permissão (campo opcional)
        public string Descricao { get; set; }
    }
}
