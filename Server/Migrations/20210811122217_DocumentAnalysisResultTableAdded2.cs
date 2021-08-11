using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class DocumentAnalysisResultTableAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Document_DocumentId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_TagDetail_Tag_TagId",
                table: "TagDetail");

            migrationBuilder.CreateTable(
                name: "DocumentAnalysisResult",
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
                    table.PrimaryKey("PK_DocumentAnalysisResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentAnalysisResult_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentAnalysisResult_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAnalysisResult_DocumentId",
                table: "DocumentAnalysisResult",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAnalysisResult_TagId",
                table: "DocumentAnalysisResult",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Document_DocumentId",
                table: "Tag",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TagDetail_Tag_TagId",
                table: "TagDetail",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Document_DocumentId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_TagDetail_Tag_TagId",
                table: "TagDetail");

            migrationBuilder.DropTable(
                name: "DocumentAnalysisResult");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Document_DocumentId",
                table: "Tag",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagDetail_Tag_TagId",
                table: "TagDetail",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
