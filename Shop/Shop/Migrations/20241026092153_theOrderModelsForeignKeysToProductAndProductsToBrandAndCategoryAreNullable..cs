using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class theOrderModelsForeignKeysToProductAndProductsToBrandAndCategoryAreNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "character varying(26)",
                maxLength: 26,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Orders",
                type: "character varying(26)",
                maxLength: 26,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Orders",
                type: "character varying(26)",
                maxLength: 26,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhone",
                table: "Orders",
                type: "character varying(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "character varying(62)",
                maxLength: 62,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(26)",
                maxLength: 26,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "character varying(26)",
                maxLength: 26,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(26)",
                oldMaxLength: 26);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(26)",
                oldMaxLength: 26);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(26)",
                oldMaxLength: 26);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhone",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(24)",
                oldMaxLength: 24);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(62)",
                oldMaxLength: 62);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(26)",
                oldMaxLength: 26);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(26)",
                oldMaxLength: 26);
        }
    }
}
