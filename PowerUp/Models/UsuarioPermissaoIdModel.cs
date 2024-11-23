using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PowerUp.Models
{
    [Table("usuario_permissao")]  // Define a tabela associada
    [PrimaryKey(nameof(UsuarioId), nameof(PermissaoId))]
    public class UsuarioPermissaoIdModel
    {
        [Column("USUARIO_ID")]  // Mapeia a coluna 'USUARIO_ID' da chave composta
        public int UsuarioId { get; set; }

        [Column("PERMISSAO_ID")]  // Mapeia a coluna 'PERMISSAO_ID' da chave composta
        public int PermissaoId { get; set; }
    }
}
