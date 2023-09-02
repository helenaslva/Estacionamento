using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionamentoAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDois : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TempoCobrado",
                table: "Estacionamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TempoCobrado",
                table: "Estacionamentos",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
