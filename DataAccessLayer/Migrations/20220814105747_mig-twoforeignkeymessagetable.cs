using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migtwoforeignkeymessagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message2s",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<int>(type: "int", nullable: true),
                    Receiver = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message2s", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_Receiver",
                        column: x => x.Receiver,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_Sender",
                        column: x => x.Sender,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_Receiver",
                table: "Message2s",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_Sender",
                table: "Message2s",
                column: "Sender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message2s");
        }
    }
}
