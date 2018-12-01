using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarDealersWeb.Data.Migrations
{
    public partial class corrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartCar_Parts_CarId",
                table: "PartCar");

            migrationBuilder.DropForeignKey(
                name: "FK_PartCar_Cars_PartId",
                table: "PartCar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartCar",
                table: "PartCar");

            migrationBuilder.DropIndex(
                name: "IX_PartCar_CarId",
                table: "PartCar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartCar",
                table: "PartCar",
                columns: new[] { "CarId", "PartId" });

            migrationBuilder.CreateIndex(
                name: "IX_PartCar_PartId",
                table: "PartCar",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartCar_Cars_CarId",
                table: "PartCar",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartCar_Parts_PartId",
                table: "PartCar",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartCar_Cars_CarId",
                table: "PartCar");

            migrationBuilder.DropForeignKey(
                name: "FK_PartCar_Parts_PartId",
                table: "PartCar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartCar",
                table: "PartCar");

            migrationBuilder.DropIndex(
                name: "IX_PartCar_PartId",
                table: "PartCar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartCar",
                table: "PartCar",
                columns: new[] { "PartId", "CarId" });

            migrationBuilder.CreateIndex(
                name: "IX_PartCar_CarId",
                table: "PartCar",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartCar_Parts_CarId",
                table: "PartCar",
                column: "CarId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartCar_Cars_PartId",
                table: "PartCar",
                column: "PartId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
