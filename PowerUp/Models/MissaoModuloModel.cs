using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PowerUp.Models
{
    [Table("missao_modulo")]  // Mapeando para a tabela 'missao_modulo'
    [PrimaryKey(nameof(MissaoId), nameof(ModuloEducativoId))]

    public class MissaoModuloModel
    {
        [Key]
        public int Missao { get; set; }
        
        [Key]
        public int ModuloEducativo { get; set; }
        
        public int MissaoId { get; set; }
        public int ModuloEducativoId { get; set; }
    }
}
