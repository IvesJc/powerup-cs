using System.ComponentModel.DataAnnotations.Schema;

namespace PowerUp.Models
{
    public class MissaoModuloIdModel
    {
        [Column("MISSAO_ID")]  // Mapeando a propriedade para a coluna correspondente
        public int MissaoId { get; set; }

        [Column("MODULO_EDUCATIVO_ID")]  // Mapeando a propriedade para a coluna correspondente
        public int ModuloEducativoId { get; set; }
    }
}
