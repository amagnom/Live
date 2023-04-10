using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SponteLive.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Lives");

            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Lives",
                newName: "DataHoraInicio");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Lives",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "DuracaoMinutos",
                table: "Lives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstrutorId",
                table: "Lives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Lives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorInscricao",
                table: "Lives",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instrutores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Instrutores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Instrutores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Inscritos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Inscritos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Inscritos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimento",
                table: "Inscricoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "StatusPagamento",
                table: "Inscricoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Inscricoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Lives_InstrutorId",
                table: "Lives",
                column: "InstrutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lives_Instrutores_InstrutorId",
                table: "Lives",
                column: "InstrutorId",
                principalTable: "Instrutores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lives_Instrutores_InstrutorId",
                table: "Lives");

            migrationBuilder.DropIndex(
                name: "IX_Lives_InstrutorId",
                table: "Lives");

            migrationBuilder.DropColumn(
                name: "DuracaoMinutos",
                table: "Lives");

            migrationBuilder.DropColumn(
                name: "InstrutorId",
                table: "Lives");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Lives");

            migrationBuilder.DropColumn(
                name: "ValorInscricao",
                table: "Lives");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Instrutores");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Inscritos");

            migrationBuilder.DropColumn(
                name: "DataVencimento",
                table: "Inscricoes");

            migrationBuilder.DropColumn(
                name: "StatusPagamento",
                table: "Inscricoes");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Inscricoes");

            migrationBuilder.RenameColumn(
                name: "DataHoraInicio",
                table: "Lives",
                newName: "DataHora");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Lives",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Lives",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instrutores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Instrutores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Inscritos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Inscritos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
