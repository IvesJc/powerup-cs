using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("missao_config")]  // Mapeando para a tabela 'missao_config'
    public class MissaoConfigModel
    {
        [Key]  // Define que esta é a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Valor gerado automaticamente (auto-incremento)
        public int Id { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(255)]  // Ajuste o comprimento conforme necessário
        public string Nome { get; set; }

        [Required]  // Campo obrigatório
        [StringLength(1000)]  // Ajuste o comprimento conforme necessário
        public string Descricao { get; set; }

        [Required]  // Campo obrigatório
        public int Pontos { get; set; }

        [Required]  // Campo obrigatório
        [Column("frequencia_dias")]  // Mapeando para a coluna 'frequencia_dias'
        public int FrequenciaDias { get; set; }
    }
}
