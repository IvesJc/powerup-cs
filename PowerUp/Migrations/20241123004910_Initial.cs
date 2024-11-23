using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerUp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Url = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_link", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "missao_artigo",
                columns: table => new
                {
                    MissaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ArtigoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Missao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Artigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missao_artigo", x => new { x.MissaoId, x.ArtigoId });
                });

            migrationBuilder.CreateTable(
                name: "missao_config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    Pontos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    frequencia_dias = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missao_config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "missao_modulo",
                columns: table => new
                {
                    MissaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ModuloEducativoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Missao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ModuloEducativo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missao_modulo", x => new { x.MissaoId, x.ModuloEducativoId });
                });

            migrationBuilder.CreateTable(
                name: "permissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ranking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ranking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "recompensa_tipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recompensa_tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario_permissao",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PermissaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Permissao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_permissao", x => new { x.UsuarioId, x.PermissaoId });
                });

            migrationBuilder.CreateTable(
                name: "emblema_tipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    ImageLinkId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emblema_tipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emblema_tipo_link_ImageLinkId",
                        column: x => x.ImageLinkId,
                        principalTable: "link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modulo_educativo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Subtitulo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    Nivel = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ThumbLinkId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulo_educativo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modulo_educativo_link_ThumbLinkId",
                        column: x => x.ThumbLinkId,
                        principalTable: "link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    firebase_uid = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    RankingId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_ranking_RankingId",
                        column: x => x.RankingId,
                        principalTable: "ranking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "recompensa_config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    custo_pontos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecompensaTipoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recompensa_config", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recompensa_config_recompensa_tipo_RecompensaTipoId",
                        column: x => x.RecompensaTipoId,
                        principalTable: "recompensa_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "artigo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Subtitulo = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Conteudo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ThumbLinkId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ModuloEducativoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artigo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_artigo_link_ThumbLinkId",
                        column: x => x.ThumbLinkId,
                        principalTable: "link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_artigo_modulo_educativo_ModuloEducativoId",
                        column: x => x.ModuloEducativoId,
                        principalTable: "modulo_educativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quiz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    Categoria = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    nota_minima = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ModuloEducativoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quiz_modulo_educativo_ModuloEducativoId",
                        column: x => x.ModuloEducativoId,
                        principalTable: "modulo_educativo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "missao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    recompensa_pontos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    MissaoConfigId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_missao_missao_config_MissaoConfigId",
                        column: x => x.MissaoConfigId,
                        principalTable: "missao_config",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_missao_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recompensa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    pontos_utilizados = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecompensaConfigId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recompensa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recompensa_recompensa_config_RecompensaConfigId",
                        column: x => x.RecompensaConfigId,
                        principalTable: "recompensa_config",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recompensa_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "desafio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ThumbLinkId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuizId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desafio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_desafio_link_ThumbLinkId",
                        column: x => x.ThumbLinkId,
                        principalTable: "link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_desafio_quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emblema_config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmblemaTipoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuizId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emblema_config", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emblema_config_emblema_tipo_EmblemaTipoId",
                        column: x => x.EmblemaTipoId,
                        principalTable: "emblema_tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emblema_config_quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pergunta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Conteudo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    QuizId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pergunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pergunta_quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emblema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmblemaConfigId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emblema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emblema_emblema_config_EmblemaConfigId",
                        column: x => x.EmblemaConfigId,
                        principalTable: "emblema_config",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emblema_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALTERNATIVA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    descricao = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    e_correta = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PerguntaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALTERNATIVA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ALTERNATIVA_pergunta_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "pergunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALTERNATIVA_PerguntaId",
                table: "ALTERNATIVA",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_artigo_ModuloEducativoId",
                table: "artigo",
                column: "ModuloEducativoId");

            migrationBuilder.CreateIndex(
                name: "IX_artigo_ThumbLinkId",
                table: "artigo",
                column: "ThumbLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_desafio_QuizId",
                table: "desafio",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_desafio_ThumbLinkId",
                table: "desafio",
                column: "ThumbLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_emblema_EmblemaConfigId",
                table: "emblema",
                column: "EmblemaConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_emblema_UsuarioId",
                table: "emblema",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_emblema_config_EmblemaTipoId",
                table: "emblema_config",
                column: "EmblemaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_emblema_config_QuizId",
                table: "emblema_config",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_emblema_tipo_ImageLinkId",
                table: "emblema_tipo",
                column: "ImageLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_missao_MissaoConfigId",
                table: "missao",
                column: "MissaoConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_missao_UsuarioId",
                table: "missao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_modulo_educativo_ThumbLinkId",
                table: "modulo_educativo",
                column: "ThumbLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_pergunta_QuizId",
                table: "pergunta",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_permissao_Nome",
                table: "permissao",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_quiz_ModuloEducativoId",
                table: "quiz",
                column: "ModuloEducativoId");

            migrationBuilder.CreateIndex(
                name: "IX_recompensa_RecompensaConfigId",
                table: "recompensa",
                column: "RecompensaConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_recompensa_UsuarioId",
                table: "recompensa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_recompensa_config_RecompensaTipoId",
                table: "recompensa_config",
                column: "RecompensaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_RankingId",
                table: "usuario",
                column: "RankingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALTERNATIVA");

            migrationBuilder.DropTable(
                name: "artigo");

            migrationBuilder.DropTable(
                name: "desafio");

            migrationBuilder.DropTable(
                name: "emblema");

            migrationBuilder.DropTable(
                name: "missao");

            migrationBuilder.DropTable(
                name: "missao_artigo");

            migrationBuilder.DropTable(
                name: "missao_modulo");

            migrationBuilder.DropTable(
                name: "permissao");

            migrationBuilder.DropTable(
                name: "recompensa");

            migrationBuilder.DropTable(
                name: "usuario_permissao");

            migrationBuilder.DropTable(
                name: "pergunta");

            migrationBuilder.DropTable(
                name: "emblema_config");

            migrationBuilder.DropTable(
                name: "missao_config");

            migrationBuilder.DropTable(
                name: "recompensa_config");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "emblema_tipo");

            migrationBuilder.DropTable(
                name: "quiz");

            migrationBuilder.DropTable(
                name: "recompensa_tipo");

            migrationBuilder.DropTable(
                name: "ranking");

            migrationBuilder.DropTable(
                name: "modulo_educativo");

            migrationBuilder.DropTable(
                name: "link");
        }
    }
}
