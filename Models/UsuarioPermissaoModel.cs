using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PowerUp.Models
{
    [Table("usuario_permissao")]  // Mapeando para a tabela 'usuario_permissao'
    public class UsuarioPermissao
    {
        [Key]  // Define que esta é a chave primária
        public UsuarioPermissaoIdModel Id { get; set; }

        // Relacionamento com Usuario
        [ForeignKey("UsuarioId")]  // Defina a chave estrangeira associada
        public Usuario Usuario { get; set; }

        // Relacionamento com Permissao
        [ForeignKey("PermissaoId")]  // Defina a chave estrangeira associada
        public Permissao Permissao { get; set; }
    }
}
