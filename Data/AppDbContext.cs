using Microsoft.EntityFrameworkCore;
using PowerUp.Models;

namespace PowerUp.Data
{
    public class AppDbContext : DbContext
    {   
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<AlternativaModel> AlternativaModels { get; set; }
        public DbSet<ArtigoModel> ArtigoModels { get; set; }
        public DbSet<DesafioModel> DesafioModels { get; set; }
        public DbSet<EmblemaConfigModel> EmblemaConfigModels { get; set; }
        public DbSet<EmblemaModel> EmblemaModels { get; set; }
        public DbSet<EmblemaTipoModel> EmblemaModelTipos { get; set; }
        public DbSet<LinkModel> LinkModels { get; set; }
        public DbSet<MissaoArtigoModel> MissaoArtigoModels { get; set; }
        public DbSet<MissaoConfigModel> MissaoConfigModels { get; set; }
        public DbSet<MissaoModel> MissaoModels { get; set; }
        public DbSet<MissaoModuloModel> MissaoModuloModels { get; set; }
        public DbSet<ModuloEducativoModel> ModuloEducativoModels { get; set; }
        public DbSet<PerguntaModel> PerguntaModels { get; set; }
        public DbSet<PermissaoModel> PermissaoModels { get; set; }
        public DbSet<QuizModel> QuizModels { get; set; }
        public DbSet<RankingModel> RankingModels { get; set; }
        public DbSet<RecompensaConfigModel> RecompensaConfigModels { get; set; }
        public DbSet<RecompensaModel> RecompensaModels { get; set; }
        public DbSet<RecompensaTipoModel> RecompensaModelTipos { get; set; }
        public DbSet<UsuarioModel> UsuarioModels { get; set; }
        public DbSet<UsuarioPermissaoModel> UsuarioPermissaoModels { get; set; }
    }
}
