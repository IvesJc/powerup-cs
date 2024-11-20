using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("missao_modulo")]  // Mapeando para a tabela 'missao_modulo'
    public class MissaoModuloModel
    {
        // Chave composta mapeada como um objeto
        [Key]  // EF Core usa uma chave composta através de uma classe separada
        public MissaoModuloIdModel Id { get; set; }

        // Relacionamento com Missao (Chave estrangeira 'MISSAO_ID')
        [ForeignKey("MissaoId")]
        public MissaoModel Missao { get; set; }

        // Relacionamento com ModuloEducativo (Chave estrangeira 'MODULO_EDUCATIVO_ID')
        [ForeignKey("ModuloEducativoId")]
        public ModuloEducativoModel ModuloEducativo { get; set; }

        // Propriedades de Chave Estrangeira
        public int MissaoId { get; set; }
        public int ModuloEducativoId { get; set; }
    }
}
