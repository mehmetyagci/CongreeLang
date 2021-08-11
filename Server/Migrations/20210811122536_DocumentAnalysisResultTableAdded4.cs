using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class DocumentAnalysisResultTableAdded4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentAnalysisResult");

            migrationBuilder.CreateTable(
                name: "AnalysisResult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisResult_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalysisResult_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisResult_DocumentId",
                table: "AnalysisResult",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisResult_TagId",
                table: "AnalysisResult",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisResult");

            migrationBuilder.CreateTable(
                name: "DocumentAnalysisResult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAnalysisResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentAnalysisResult_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentAnalysisResult_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAnalysisResult_DocumentId",
                table: "DocumentAnalysisResult",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAnalysisResult_TagId",
                table: "DocumentAnalysisResult",
                column: "TagId");
        }
    }
}
