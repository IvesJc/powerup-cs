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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MissaoArtigoModel>()
                .HasKey(op => new { op.MissaoId, op.ArtigoId }); // Chave composta

            modelBuilder.Entity<MissaoModuloModel>().HasKey(ab => new { ab.MissaoId, ab.ModuloEducativoId });
            modelBuilder.Entity<UsuarioPermissaoModel>().HasKey(up => new { up.UsuarioId, up.PermissaoId });
            
            //   // Tabelas de relacionamento many-to-many
            // modelBuilder.Entity<MissaoArtigoModel>()
            //     .HasKey(ma => new { ma.MissaoId, ma.ArtigoId });
            //
            // modelBuilder.Entity<MissaoArtigoModel>()
            //     .HasOne(ma => ma.Missao)
            //     .WithMany(m => m.)
            //     .HasForeignKey(ma => ma.MissaoId);
            //
            // modelBuilder.Entity<MissaoArtigoModel>()
            //     .HasOne(ma => ma.Artigo)
            //     .WithMany(a => a.MissaoArtigos)
            //     .HasForeignKey(ma => ma.ArtigoId);
            //
            // modelBuilder.Entity<MissaoModuloModel>()
            //     .HasKey(mm => new { mm.MissaoId, mm.ModuloEducativoId });
            //
            // modelBuilder.Entity<MissaoModuloModel>()
            //     .HasOne(mm => mm.Missao)
            //     .WithMany(m => m.MissaoArtigoModels)
            //     .HasForeignKey(mm => mm.MissaoId);
            //
            // modelBuilder.Entity<MissaoModuloModel>()
            //     .HasOne(mm => mm.ModuloEducativo)
            //     .WithMany(me => me.MissaoModulos)
            //     .HasForeignKey(mm => mm.ModuloEducativoId);
            //
            // modelBuilder.Entity<UsuarioPermissaoModel>()
            //     .HasKey(up => new { up.UsuarioId, up.PermissaoId });
            //
            // modelBuilder.Entity<UsuarioPermissaoModel>()
            //     .HasOne(up => up.Usuario)
            //     .WithMany(u => u.UsuarioPermissoes)
            //     .HasForeignKey(up => up.UsuarioId);
            //
            // modelBuilder.Entity<UsuarioPermissaoModel>()
            //     .HasOne(up => up.Permissao)
            //     .WithMany(p => p.UsuarioPermissoes)
            //     .HasForeignKey(up => up.PermissaoId);
            //
            // // Configuração de entidades com chaves estrangeiras
            // modelBuilder.Entity<ModuloEducativoModel>()
            //     .HasOne(me => me.ThumbLink)
            //     .WithMany()
            //     .HasForeignKey(me => me.ThumbLinkId)
            //     .OnDelete(DeleteBehavior.Restrict);
            //
            // modelBuilder.Entity<UsuarioModel>()
            //     .HasOne(u => u.Ranking)
            //     .WithMany()
            //     .HasForeignKey(u => u.RankingId);
            //
            // modelBuilder.Entity<EmblemaTipoModel>()
            //     .HasOne(et => et.ImageLink)
            //     .WithMany()
            //     .HasForeignKey(et => et.ImageLinkId)
            //     .OnDelete(DeleteBehavior.Restrict);
            //
            // modelBuilder.Entity<QuizModel>()
            //     .HasOne(q => q.ModuloEducativo)
            //     .WithMany(me => me.Quizzes)
            //     .HasForeignKey(q => q.ModuloEducativoId);
            //
            // modelBuilder.Entity<EmblemaConfigModel>()
            //     .HasOne(ec => ec.EmblemaTipo)
            //     .WithMany()
            //     .HasForeignKey(ec => ec.EmblemaTipoId);
            //
            // modelBuilder.Entity<EmblemaConfigModel>()
            //     .HasOne(ec => ec.Quiz)
            //     .WithMany()
            //     .HasForeignKey(ec => ec.QuizId);
            //
            // modelBuilder.Entity<MissaoModel>()
            //     .HasOne(m => m.MissaoConfig)
            //     .WithMany()
            //     .HasForeignKey(m => m.MissaoConfigId);
            //
            // modelBuilder.Entity<MissaoModel>()
            //     .HasOne(m => m.Usuario)
            //     .WithMany(u => u.Missoes)
            //     .HasForeignKey(m => m.UsuarioId);
            //
            // modelBuilder.Entity<EmblemaModel>()
            //     .HasOne(e => e.Usuario)
            //     .WithMany(u => u.Emblemas)
            //     .HasForeignKey(e => e.UsuarioId);
            //
            // modelBuilder.Entity<EmblemaModel>()
            //     .HasOne(e => e.EmblemaConfig)
            //     .WithMany(ec => ec.Emblemas)
            //     .HasForeignKey(e => e.EmblemaConfigId);
            //
            // modelBuilder.Entity<PerguntaModel>()
            //     .HasOne(p => p.Quiz)
            //     .WithMany(q => q.Perguntas)
            //     .HasForeignKey(p => p.QuizId);
            //
            // modelBuilder.Entity<ArtigoModel>()
            //     .HasOne(a => a.ThumbLink)
            //     .WithMany()
            //     .HasForeignKey(a => a.ThumbLinkId)
            //     .OnDelete(DeleteBehavior.Restrict);
            //
            // modelBuilder.Entity<ArtigoModel>()
            //     .HasOne(a => a.ModuloEducativo)
            //     .WithMany(me => me.Artigos)
            //     .HasForeignKey(a => a.ModuloEducativoId);
            //
            // modelBuilder.Entity<AlternativaModel>()
            //     .HasOne(al => al.Pergunta)
            //     .WithMany(p => p.Alternativas)
            //     .HasForeignKey(al => al.PerguntaId);
            //
            // modelBuilder.Entity<DesafioModel>()
            //     .HasOne(d => d.ThumbLink)
            //     .WithMany()
            //     .HasForeignKey(d => d.ThumbLinkId)
            //     .OnDelete(DeleteBehavior.Restrict);
            //
            // modelBuilder.Entity<DesafioModel>()
            //     .HasOne(d => d.Quiz)
            //     .WithMany(q => q.Desafios)
            //     .HasForeignKey(d => d.QuizId);
            //
            // modelBuilder.Entity<RecompensaConfigModel>()
            //     .HasOne(rc => rc.RecompensaTipo)
            //     .WithMany()
            //     .HasForeignKey(rc => rc.RecompensaTipoId);
            //
            // modelBuilder.Entity<RecompensaModel>()
            //     .HasOne(r => r.Usuario)
            //     .WithMany(u => u.Recompensas)
            //     .HasForeignKey(r => r.UsuarioId);
            //
            // modelBuilder.Entity<RecompensaModel>()
            //     .HasOne(r => r.RecompensaConfig)
            //     .WithMany(rc => rc.Recompensas)
            //     .HasForeignKey(r => r.RecompensaConfigId);
        }
    }
}
