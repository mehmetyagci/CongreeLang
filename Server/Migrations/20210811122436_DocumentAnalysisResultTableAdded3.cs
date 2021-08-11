using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class DocumentAnalysisResultTableAdded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentAnalysisResult_Document_DocumentId",
                table: "DocumentAnalysisResult");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentAnalysisResult_Tag_TagId",
                table: "DocumentAnalysisResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Document_DocumentId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_TagDetail_Tag_TagId",
                table: "TagDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentAnalysisResult_Document_DocumentId",
                table: "DocumentAnalysisResult",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentAnalysisResult_Tag_TagId",
                table: "DocumentAnalysisResult",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentAnalysisResult_Document_DocumentId",
                table: "DocumentAnalysisResult");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentAnalysisResult_Tag_TagId",
                table: "DocumentAnalysisResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Document_DocumentId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_TagDetail_Tag_TagId",
                table: "TagDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentAnalysisResult_Document_DocumentId",
                table: "DocumentAnalysisResult",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentAnalysisResult_Tag_TagId",
                table: "DocumentAnalysisResult",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
