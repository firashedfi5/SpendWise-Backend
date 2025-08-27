using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpendWise_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Transactions");
        }
    }
}
