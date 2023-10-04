using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ProcessJudicial.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class INICIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    IdUsers = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAdvogado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.IdUsers);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "judicialprocesses",
                columns: table => new
                {
                    IdJudicialProcess = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsers = table.Column<long>(type: "bigint", nullable: false),
                    ProcessNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Part = table.Column<long>(type: "bigint", nullable: false),
                    Responsible = table.Column<long>(type: "bigint", nullable: false),
                    Documents = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Theme = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValueCause = table.Column<double>(type: "double", nullable: false),
                    userIdUsers = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_judicialprocesses", x => x.IdJudicialProcess);
                    table.ForeignKey(
                        name: "FK_judicialprocesses_users_userIdUsers",
                        column: x => x.userIdUsers,
                        principalTable: "users",
                        principalColumn: "IdUsers",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    IdDocument = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsers = table.Column<long>(type: "bigint", nullable: false),
                    IdJudicialProcess = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Extension = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userIdUsers = table.Column<long>(type: "bigint", nullable: false),
                    JudicialProcessIdJudicialProcess = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.IdDocument);
                    table.ForeignKey(
                        name: "FK_documents_judicialprocesses_JudicialProcessIdJudicialProcess",
                        column: x => x.JudicialProcessIdJudicialProcess,
                        principalTable: "judicialprocesses",
                        principalColumn: "IdJudicialProcess",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documents_users_userIdUsers",
                        column: x => x.userIdUsers,
                        principalTable: "users",
                        principalColumn: "IdUsers",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_documents_JudicialProcessIdJudicialProcess",
                table: "documents",
                column: "JudicialProcessIdJudicialProcess");

            migrationBuilder.CreateIndex(
                name: "IX_documents_userIdUsers",
                table: "documents",
                column: "userIdUsers");

            migrationBuilder.CreateIndex(
                name: "IX_judicialprocesses_userIdUsers",
                table: "judicialprocesses",
                column: "userIdUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "judicialprocesses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
