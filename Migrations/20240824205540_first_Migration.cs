using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2Work_API.Migrations
{
    /// <inheritdoc />
    public partial class first_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Empresa",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NM_Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ST_Record = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Empresa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_User",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NM_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TP_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ST_Record = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_User_x_Empresa",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_TB_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_TB_Empresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_User_x_Empresa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_User_x_Empresa_TB_Empresa_ID_TB_Empresa",
                        column: x => x.ID_TB_Empresa,
                        principalTable: "TB_Empresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_User_x_Empresa_TB_User_ID_TB_User",
                        column: x => x.ID_TB_User,
                        principalTable: "TB_User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_User_x_Empresa_ID_TB_Empresa",
                table: "TB_User_x_Empresa",
                column: "ID_TB_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_TB_User_x_Empresa_ID_TB_User",
                table: "TB_User_x_Empresa",
                column: "ID_TB_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_User_x_Empresa");

            migrationBuilder.DropTable(
                name: "TB_Empresa");

            migrationBuilder.DropTable(
                name: "TB_User");
        }
    }
}
