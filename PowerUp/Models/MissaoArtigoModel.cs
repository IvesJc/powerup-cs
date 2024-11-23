using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("missao_artigo")]  // Mapeando para a tabela 'missao_artigo'
    public class MissaoArtigoModel
    {
        // Relacionamento com a entidade Missao
        [Key]
        public int Missao { get; set; }

        // Relacionamento com a entidade Artigo
        [Key]
        public int Artigo { get; set; }

        // Propriedades de Chave Estrangeira
        public int MissaoId { get; set; }
        public int ArtigoId { get; set; }
    }
}
