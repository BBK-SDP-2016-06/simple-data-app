using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MachineSpecs.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DEVTASK");

            migrationBuilder.CreateTable(
                name: "GraphicsCard",
                schema: "DEVTASK",
                columns: table => new
                {
                    GraphicsCardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsCard", x => x.GraphicsCardID);
                });

            migrationBuilder.CreateTable(
                name: "Port",
                schema: "DEVTASK",
                columns: table => new
                {
                    PortID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.PortID);
                });

            migrationBuilder.CreateTable(
                name: "Processor",
                schema: "DEVTASK",
                columns: table => new
                {
                    ProcessorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processor", x => x.ProcessorID);
                });

            migrationBuilder.CreateTable(
                name: "Computer",
                schema: "DEVTASK",
                columns: table => new
                {
                    ComputerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GraphicsCardID = table.Column<int>(nullable: false),
                    Memory = table.Column<decimal>(nullable: false),
                    Power = table.Column<int>(nullable: false),
                    ProcessorID = table.Column<int>(nullable: false),
                    StorageCapacity = table.Column<decimal>(nullable: false),
                    StorageType = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.ComputerID);
                    table.ForeignKey(
                        name: "FK_Computer_GraphicsCard_GraphicsCardID",
                        column: x => x.GraphicsCardID,
                        principalSchema: "DEVTASK",
                        principalTable: "GraphicsCard",
                        principalColumn: "GraphicsCardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Processor_ProcessorID",
                        column: x => x.ProcessorID,
                        principalSchema: "DEVTASK",
                        principalTable: "Processor",
                        principalColumn: "ProcessorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Connection",
                schema: "DEVTASK",
                columns: table => new
                {
                    ConnectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComputerID = table.Column<int>(nullable: false),
                    PortID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.ConnectionID);
                    table.ForeignKey(
                        name: "FK_Connection_Computer_ComputerID",
                        column: x => x.ComputerID,
                        principalSchema: "DEVTASK",
                        principalTable: "Computer",
                        principalColumn: "ComputerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connection_Port_PortID",
                        column: x => x.PortID,
                        principalSchema: "DEVTASK",
                        principalTable: "Port",
                        principalColumn: "PortID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computer_GraphicsCardID",
                schema: "DEVTASK",
                table: "Computer",
                column: "GraphicsCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_ProcessorID",
                schema: "DEVTASK",
                table: "Computer",
                column: "ProcessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_ComputerID",
                schema: "DEVTASK",
                table: "Connection",
                column: "ComputerID");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_PortID",
                schema: "DEVTASK",
                table: "Connection",
                column: "PortID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connection",
                schema: "DEVTASK");

            migrationBuilder.DropTable(
                name: "Computer",
                schema: "DEVTASK");

            migrationBuilder.DropTable(
                name: "Port",
                schema: "DEVTASK");

            migrationBuilder.DropTable(
                name: "GraphicsCard",
                schema: "DEVTASK");

            migrationBuilder.DropTable(
                name: "Processor",
                schema: "DEVTASK");
        }
    }
}
