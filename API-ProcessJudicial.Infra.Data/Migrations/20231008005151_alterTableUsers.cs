using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ProcessJudicial.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alterTableUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Oab",
                table: "users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Oab",
                table: "users");
        }
    }
}
