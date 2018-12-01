using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarDealersWeb.Data.Migrations
{
    public partial class CorrectingTravellDistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TravelDistance",
                table: "Cars",
                newName: "TravellDistance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TravellDistance",
                table: "Cars",
                newName: "TravelDistance");
        }
    }
}
