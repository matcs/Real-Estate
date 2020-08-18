using Microsoft.EntityFrameworkCore.Migrations;

namespace Real_Estate.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    cod_endereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rua = table.Column<string>(type: "VARCHAR(40)", nullable: true),
                    logradouro = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    bairro = table.Column<string>(type: "VARCHAR(25)", nullable: true),
                    numero = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    municipio = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    estado = table.Column<string>(type: "CHAR(2)", nullable: true),
                    cep = table.Column<string>(type: "CHAR(9)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.cod_endereco);
                });

            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    cod_proprietario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_proprietario = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.cod_proprietario);
                });

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    cod_imovel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    largura = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    comprimento = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    metro_quadrado = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: true),
                    numero_quartos = table.Column<byte>(type: "TINYINT", nullable: false),
                    numero_banheiros = table.Column<byte>(type: "TINYINT", nullable: false),
                    _tipoImove = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    proprietariocod_proprietario = table.Column<int>(nullable: true),
                    enderecocod_endereco = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.cod_imovel);
                    table.ForeignKey(
                        name: "FK_Imoveis_Enderecos_enderecocod_endereco",
                        column: x => x.enderecocod_endereco,
                        principalTable: "Enderecos",
                        principalColumn: "cod_endereco",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imoveis_Proprietarios_proprietariocod_proprietario",
                        column: x => x.proprietariocod_proprietario,
                        principalTable: "Proprietarios",
                        principalColumn: "cod_proprietario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    cod_apartamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_bloco = table.Column<string>(type: "VARCHAR(25)", nullable: true),
                    numero_bloco = table.Column<byte>(type: "TINYINT", nullable: false),
                    Proprietariocod_proprietario = table.Column<int>(nullable: true),
                    Imovelcod_imovel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.cod_apartamento);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Imoveis_Imovelcod_imovel",
                        column: x => x.Imovelcod_imovel,
                        principalTable: "Imoveis",
                        principalColumn: "cod_imovel",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Proprietarios_Proprietariocod_proprietario",
                        column: x => x.Proprietariocod_proprietario,
                        principalTable: "Proprietarios",
                        principalColumn: "cod_proprietario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Casas",
                columns: table => new
                {
                    cod_casa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "VARCHAR(25)", nullable: true),
                    quintal = table.Column<bool>(type: "BIT", nullable: false),
                    garagem = table.Column<bool>(type: "BIT", nullable: false),
                    numero_vagas = table.Column<byte>(type: "TINYINT", nullable: false),
                    valor_p_metro2 = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    Proprietariocod_proprietario = table.Column<int>(nullable: true),
                    Imovelcod_imovel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casas", x => x.cod_casa);
                    table.ForeignKey(
                        name: "FK_Casas_Imoveis_Imovelcod_imovel",
                        column: x => x.Imovelcod_imovel,
                        principalTable: "Imoveis",
                        principalColumn: "cod_imovel",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casas_Proprietarios_Proprietariocod_proprietario",
                        column: x => x.Proprietariocod_proprietario,
                        principalTable: "Proprietarios",
                        principalColumn: "cod_proprietario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_Imovelcod_imovel",
                table: "Apartamentos",
                column: "Imovelcod_imovel");

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_Proprietariocod_proprietario",
                table: "Apartamentos",
                column: "Proprietariocod_proprietario");

            migrationBuilder.CreateIndex(
                name: "IX_Casas_Imovelcod_imovel",
                table: "Casas",
                column: "Imovelcod_imovel");

            migrationBuilder.CreateIndex(
                name: "IX_Casas_Proprietariocod_proprietario",
                table: "Casas",
                column: "Proprietariocod_proprietario");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_enderecocod_endereco",
                table: "Imoveis",
                column: "enderecocod_endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_proprietariocod_proprietario",
                table: "Imoveis",
                column: "proprietariocod_proprietario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Casas");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Proprietarios");
        }
    }
}
