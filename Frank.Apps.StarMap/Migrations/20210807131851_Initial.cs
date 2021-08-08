using Microsoft.EntityFrameworkCore.Migrations;

namespace Frank.Apps.StarMap.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hip = table.Column<int>(type: "INTEGER", nullable: true),
                    Hd = table.Column<int>(type: "INTEGER", nullable: true),
                    Hr = table.Column<int>(type: "INTEGER", nullable: true),
                    Gl = table.Column<string>(type: "TEXT", nullable: true),
                    Bf = table.Column<string>(type: "TEXT", nullable: true),
                    Proper = table.Column<string>(type: "TEXT", nullable: true),
                    Ra = table.Column<double>(type: "REAL", nullable: false),
                    Dec = table.Column<double>(type: "REAL", nullable: false),
                    Dist = table.Column<double>(type: "REAL", nullable: false),
                    Pmra = table.Column<double>(type: "REAL", nullable: false),
                    Pmdec = table.Column<double>(type: "REAL", nullable: false),
                    Rv = table.Column<double>(type: "REAL", nullable: false),
                    Mag = table.Column<string>(type: "TEXT", nullable: true),
                    Absmag = table.Column<double>(type: "REAL", nullable: false),
                    Spect = table.Column<string>(type: "TEXT", nullable: true),
                    Ci = table.Column<string>(type: "TEXT", nullable: true),
                    X = table.Column<double>(type: "REAL", nullable: false),
                    Y = table.Column<double>(type: "REAL", nullable: false),
                    Z = table.Column<double>(type: "REAL", nullable: false),
                    Vx = table.Column<double>(type: "REAL", nullable: false),
                    Vy = table.Column<double>(type: "REAL", nullable: false),
                    Vz = table.Column<double>(type: "REAL", nullable: false),
                    Rarad = table.Column<double>(type: "REAL", nullable: false),
                    Decrad = table.Column<double>(type: "REAL", nullable: false),
                    Pmrarad = table.Column<double>(type: "REAL", nullable: false),
                    Pmdecrad = table.Column<double>(type: "REAL", nullable: false),
                    Bayer = table.Column<string>(type: "TEXT", nullable: true),
                    Flam = table.Column<int>(type: "INTEGER", nullable: true),
                    Con = table.Column<string>(type: "TEXT", nullable: true),
                    Comp = table.Column<int>(type: "INTEGER", nullable: false),
                    CompPrimary = table.Column<int>(type: "INTEGER", nullable: false),
                    Base = table.Column<string>(type: "TEXT", nullable: true),
                    Lum = table.Column<double>(type: "REAL", nullable: false),
                    Var = table.Column<string>(type: "TEXT", nullable: true),
                    VarMin = table.Column<string>(type: "TEXT", nullable: true),
                    VarMax = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stars");
        }
    }
}
