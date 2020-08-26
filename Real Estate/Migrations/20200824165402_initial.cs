using Microsoft.EntityFrameworkCore.Migrations;

namespace Real_Estate.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    cod_apartamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_bloco = table.Column<string>(type: "VARCHAR(25)", nullable: true),
                    numero_bloco = table.Column<byte>(type: "TINYINT", nullable: false),
                    ImovelRefId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.cod_apartamento);
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
                    ImovelRefId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casas", x => x.cod_casa);
                });

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
                    senha = table.Column<string>(nullable: true),
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
                    metro_quadrado = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: true),
                    numero_quartos = table.Column<byte>(type: "TINYINT", nullable: false),
                    numero_banheiros = table.Column<byte>(type: "TINYINT", nullable: false),
                    _tipoImovel = table.Column<int>(type: "INT", nullable: false),
                    ProprietarioRefId = table.Column<int>(nullable: false),
                    EnderecoRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.cod_imovel);
                    table.ForeignKey(
                        name: "FK_Imoveis_Enderecos_EnderecoRefId",
                        column: x => x.EnderecoRefId,
                        principalTable: "Enderecos",
                        principalColumn: "cod_endereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imoveis_Proprietarios_ProprietarioRefId",
                        column: x => x.ProprietarioRefId,
                        principalTable: "Proprietarios",
                        principalColumn: "cod_proprietario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Apartamentos",
                columns: new[] { "cod_apartamento", "ImovelRefId", "nome_bloco", "numero_bloco" },
                values: new object[] { 1, 3, "Andorinha", (byte)9 });

            migrationBuilder.InsertData(
                table: "Casas",
                columns: new[] { "cod_casa", "ImovelRefId", "garagem", "numero_vagas", "quintal", "tipo", "valor_p_metro2" },
                values: new object[,]
                {
                    { 1, 1, true, (byte)1, true, "HomeTown", 25m },
                    { 2, 2, true, (byte)1, false, "Duplex", 30m }
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
                table: "Proprietarios",
                columns: new[] { "cod_proprietario", "email", "nome_proprietario", "senha", "telefone" },
                values: new object[,]
                {
                    { 1, "matmau11@hotmail.com", "Matheus Costa dos Santos", "matmau11", "954946842" },
                    { 2, "maumau11@hotmail.com", "Mauricio Potter dos Santos", "maumau11", "986174471" },
                    { 3, "dorivalodbrok@hotmail.com", "Dorival Lodbrok", "doridori11", "979564471" }
                });

            migrationBuilder.InsertData(
                table: "Imoveis",
                columns: new[] { "cod_imovel", "EnderecoRefId", "ProprietarioRefId", "_tipoImovel", "descricao", "metro_quadrado", "numero_banheiros", "numero_quartos" },
                values: new object[] { 1, 1, 1, 0, "Lugar agradavel com vista para calçada!", 625m, (byte)1, (byte)4 });

            migrationBuilder.InsertData(
                table: "Imoveis",
                columns: new[] { "cod_imovel", "EnderecoRefId", "ProprietarioRefId", "_tipoImovel", "descricao", "metro_quadrado", "numero_banheiros", "numero_quartos" },
                values: new object[] { 2, 2, 2, 0, "Lindo, apenas.", 2550m, (byte)2, (byte)5 });

            migrationBuilder.InsertData(
                table: "Imoveis",
                columns: new[] { "cod_imovel", "EnderecoRefId", "ProprietarioRefId", "_tipoImovel", "descricao", "metro_quadrado", "numero_banheiros", "numero_quartos" },
                values: new object[] { 3, 3, 3, 1, "Apartamento com uma varanda linda para o mar!", 400m, (byte)1, (byte)2 });

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_EnderecoRefId",
                table: "Imoveis",
                column: "EnderecoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_ProprietarioRefId",
                table: "Imoveis",
                column: "ProprietarioRefId");
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
