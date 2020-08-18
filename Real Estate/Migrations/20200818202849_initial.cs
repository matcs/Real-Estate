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
                    logradouro = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    rua = table.Column<string>(type: "VARCHAR(40)", nullable: true),
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
                    _tipoImovel = table.Column<int>(type: "INT", nullable: false),
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
                    valor_p_metro2 = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    proprietariocod_proprietario = table.Column<int>(nullable: true),
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
                        name: "FK_Casas_Proprietarios_proprietariocod_proprietario",
                        column: x => x.proprietariocod_proprietario,
                        principalTable: "Proprietarios",
                        principalColumn: "cod_proprietario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Apartamentos",
                columns: new[] { "cod_apartamento", "Imovelcod_imovel", "Proprietariocod_proprietario", "nome_bloco", "numero_bloco" },
                values: new object[] { 1, null, null, "Andorinha", (byte)57 });

            migrationBuilder.InsertData(
                table: "Casas",
                columns: new[] { "cod_casa", "Imovelcod_imovel", "garagem", "numero_vagas", "proprietariocod_proprietario", "quintal", "tipo", "valor_p_metro2" },
                values: new object[,]
                {
                    { 1, null, true, (byte)1, null, true, "HomeTown", 25m },
                    { 2, null, true, (byte)1, null, false, "Duplex", 30m }
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "cod_endereco", "bairro", "cep", "estado", "logradouro", "municipio", "numero", "rua" },
                values: new object[,]
                {
                    { 1, "Vila Yara", "06026-050", "SP", "Rua", "Osasco", "463", "Silverio Sasso" },
                    { 2, "Vila dos Remédios", "02675-031", "SP", "Avenida", "São Paulo", "4561a", "dos Remedios" },
                    { 3, "Palm Desert", "92211", "CA", "Rua", "California", "75245", "Vista Corona" }
                });

            migrationBuilder.InsertData(
                table: "Imoveis",
                columns: new[] { "cod_imovel", "_tipoImovel", "comprimento", "descricao", "enderecocod_endereco", "largura", "metro_quadrado", "numero_banheiros", "numero_quartos", "proprietariocod_proprietario" },
                values: new object[,]
                {
                    { 1, 0, 25m, "Lugar agradavel com vista para calçada!", null, 25m, 625m, (byte)1, (byte)4, null },
                    { 2, 0, 51m, "Lindo, apenas.", null, 50m, 2550m, (byte)2, (byte)5, null },
                    { 3, 1, 20m, "Apartamento com uma varanda linda para o mar!", null, 20m, 400m, (byte)1, (byte)2, null }
                });

            migrationBuilder.InsertData(
                table: "Proprietarios",
                columns: new[] { "cod_proprietario", "email", "nome_proprietario", "telefone" },
                values: new object[,]
                {
                    { 1, "matmau11@hotmail.com", "Matheus Costa dos Santos", "954946842" },
                    { 2, "maumau11@hotmail.com", "Mauricio Potter dos Santos", "986174471" },
                    { 3, "dorivalodbrok@hotmail.com", "Dorival Lodbrok", "979564471" }
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
                name: "IX_Casas_proprietariocod_proprietario",
                table: "Casas",
                column: "proprietariocod_proprietario");

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
