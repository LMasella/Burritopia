using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Burritopia.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Burritos_BurritoId",
                table: "Topping");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Ingredients_AddOnId",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.RenameIndex(
                name: "IX_Topping_BurritoId",
                table: "Toppings",
                newName: "IX_Toppings_BurritoId");

            migrationBuilder.RenameIndex(
                name: "IX_Topping_AddOnId",
                table: "Toppings",
                newName: "IX_Toppings_AddOnId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "ToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Burritos_BurritoId",
                table: "Toppings",
                column: "BurritoId",
                principalTable: "Burritos",
                principalColumn: "BurritoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Ingredients_AddOnId",
                table: "Toppings",
                column: "AddOnId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Burritos_BurritoId",
                table: "Toppings");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Ingredients_AddOnId",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_BurritoId",
                table: "Topping",
                newName: "IX_Topping_BurritoId");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_AddOnId",
                table: "Topping",
                newName: "IX_Topping_AddOnId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "ToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_Burritos_BurritoId",
                table: "Topping",
                column: "BurritoId",
                principalTable: "Burritos",
                principalColumn: "BurritoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_Ingredients_AddOnId",
                table: "Topping",
                column: "AddOnId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
