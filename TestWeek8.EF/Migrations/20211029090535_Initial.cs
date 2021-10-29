using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWeek8.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ruolo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Piatti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piatti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piatti_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Menu di Capodanno" },
                    { 2, "Menu di Natale" },
                    { 3, "Menu di Pasqua" }
                });

            migrationBuilder.InsertData(
                table: "Utenti",
                columns: new[] { "Id", "Email", "Password", "Ruolo" },
                values: new object[,]
                {
                    { 1, "diego.scano@abc.it", "1234", "Ristoratore" },
                    { 2, "mario.rossi@abc.it", "5678", "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Piatti",
                columns: new[] { "Id", "MenuId", "Nome", "Prezzo", "Tipo" },
                values: new object[,]
                {
                    { 1, 1, "Tortelloni di ricotta ed erbe di campo", 9.90m, "Primo" },
                    { 21, 3, "Cavoletti di bruxelles arrosto con salsa di sesamo e limone", 7.9m, "Contorno" },
                    { 20, 3, "Anelli di calamari al forno", 13.5m, "Secondo" },
                    { 19, 3, "Costine di agnello al sugo", 13m, "Secondo" },
                    { 18, 3, "Pasta al forno con funghi, prosciutto e piselli", 10.9m, "Primo" },
                    { 17, 3, "Tagliolini al ragù di agnello", 11.9m, "Primo" },
                    { 16, 2, "Babà napoletano", 6m, "Dolce" },
                    { 15, 2, "Cassata al forno", 5.5m, "Dolce" },
                    { 14, 2, "Patate ventaglio al forno", 5m, "Contorno" },
                    { 13, 2, "Zucca al forno con arancia e pepe", 7m, "Contorno" },
                    { 22, 3, "Rotolo al cocco con crema di cioccolato", 8.5m, "Dolce" },
                    { 12, 2, "Rollatine di pollo alla Wellington", 9m, "Secondo" },
                    { 10, 2, "Crespelle al nero di seppia e salmone", 11.5m, "Primo" },
                    { 9, 2, "Anelletti al forno", 10m, "Primo" },
                    { 8, 1, "Zuppa inglese", 4m, "Dolce" },
                    { 7, 1, "Meringhe al cacao e alla nocciola", 5.9m, "Dolce" },
                    { 6, 1, "Funghi champignon al forno", 7m, "Contorno" },
                    { 5, 1, "Verza all'aceto", 6.5m, "Contorno" },
                    { 4, 1, "Spiedini di gamberi al cumino", 12m, "Secondo" },
                    { 3, 1, "Stinco di maiale al forno", 11.5m, "Secondo" },
                    { 2, 1, "Lasagne ai funghi", 11m, "Primo" },
                    { 11, 2, "Gamberoni al forno", 11.9m, "Secondo" },
                    { 23, 3, "Crostatine con chantilly al torrone", 6.9m, "Dolce" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piatti_MenuId",
                table: "Piatti",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piatti");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
