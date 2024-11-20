using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("missao_artigo")]
    public class MissaoArtigoIdModel
    {
        [Key]
        [Column("MISSAO_ID")]
        public int MissaoId { get; set; }

        [Key]
        [Column("ARTIGO_ID")]
        public int ArtigoId { get; set; }
    }
}
