using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PowerUp.Models
{
    [PrimaryKey(nameof(MissaoId), nameof(ModuloEducativoId))]
    public class MissaoModuloIdModel
    {
        [Column("MISSAO_ID")]  // Mapeando a propriedade para a coluna correspondente
        public int MissaoId { get; set; }

        [Column("MODULO_EDUCATIVO_ID")]  // Mapeando a propriedade para a coluna correspondente
        public int ModuloEducativoId { get; set; }
    }
}
