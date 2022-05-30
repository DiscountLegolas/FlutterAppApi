using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "İls",
                columns: table => new
                {
                    İlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İls", x => x.İlId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "İlçes",
                columns: table => new
                {
                    İlçeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İlçes", x => x.İlçeId);
                    table.ForeignKey(
                        name: "FK_İlçes_İls_İlId",
                        column: x => x.İlId,
                        principalTable: "İls",
                        principalColumn: "İlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMessages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User1Id = table.Column<int>(type: "int", nullable: false),
                    User2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_UserMessages_Users_User1Id",
                        column: x => x.User1Id,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_UserMessages_Users_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    TherapistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aproved = table.Column<bool>(type: "bit", nullable: false),
                    İlçeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.TherapistId);
                    table.ForeignKey(
                        name: "FK_Therapists_İlçes_İlçeId",
                        column: x => x.İlçeId,
                        principalTable: "İlçes",
                        principalColumn: "İlçeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TherapistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TherapistMessages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TherapistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapistMessages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_TherapistMessages_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TherapistMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_İlçes_İlId",
                table: "İlçes",
                column: "İlId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TherapistId",
                table: "Posts",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistMessages_TherapistId",
                table: "TherapistMessages",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistMessages_UserId",
                table: "TherapistMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_İlçeId",
                table: "Therapists",
                column: "İlçeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_User1Id",
                table: "UserMessages",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_User2Id",
                table: "UserMessages",
                column: "User2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "TherapistMessages");

            migrationBuilder.DropTable(
                name: "UserMessages");

            migrationBuilder.DropTable(
                name: "Therapists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "İlçes");

            migrationBuilder.DropTable(
                name: "İls");
        }
    }
}
