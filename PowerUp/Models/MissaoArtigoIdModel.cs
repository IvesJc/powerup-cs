using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PowerUp.Models
{
    [Table("missao_artigo")]
    [PrimaryKey(nameof(MissaoId), nameof(ArtigoId))]
    public class MissaoArtigoIdModel
    {
        [Column("MISSAO_ID")]
        public int MissaoId { get; set; }

        [Column("ARTIGO_ID")]
        public int ArtigoId { get; set; }
    }
}
