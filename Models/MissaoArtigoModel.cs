using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("missao_artigo")]  // Mapeando para a tabela 'missao_artigo'
    public class MissaoArtigoModel
    {
        // Chave composta mapeada como um objeto
        [Key]  // EF Core usa uma chave composta através de uma classe separada
        public MissaoArtigoIdModel Id { get; set; }

        // Relacionamento com a entidade Missao
        [ForeignKey("MissaoId")]
        public MissaoModel Missao { get; set; }

        // Relacionamento com a entidade Artigo
        [ForeignKey("ArtigoId")]
        public ArtigoModel Artigo { get; set; }

        // Propriedades de Chave Estrangeira
        public int MissaoId { get; set; }
        public int ArtigoId { get; set; }
    }
}
