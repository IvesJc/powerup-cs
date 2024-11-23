using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PowerUp.Models
{
    [Table("usuario_permissao")]  // Mapeando para a tabela 'usuario_permissao'
    [PrimaryKey(nameof(UsuarioId), nameof(PermissaoId))]

    public class UsuarioPermissaoModel
    {
        [Key]
        public int Usuario { get; set; }

        [Key]
        public int Permissao { get; set; }
        
        
        public int UsuarioId { get; set; }

        public int PermissaoId { get; set; }
    }
}
