using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace adopse_2021.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "As",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_As", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationEventStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Completed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationEventStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContentFromEvaluee = table.Column<string>(type: "text", nullable: true),
                    AId = table.Column<long>(type: "bigint", nullable: true),
                    IsCorrectAnswer = table.Column<bool>(type: "boolean", nullable: false),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenAnswers_As_AId",
                        column: x => x.AId,
                        principalTable: "As",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenAnswers_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    IsGraded = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    QuestionsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Evaluations_Qs_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Qs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HasCorrectAnswer = table.Column<bool>(type: "boolean", nullable: false),
                    QId = table.Column<long>(type: "bigint", nullable: true),
                    Heading = table.Column<string>(type: "text", nullable: true),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    IsGraded = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestions_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestions_Qs_QId",
                        column: x => x.QId,
                        principalTable: "Qs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenQuestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnswerId = table.Column<long>(type: "bigint", nullable: true),
                    QId = table.Column<long>(type: "bigint", nullable: true),
                    Heading = table.Column<string>(type: "text", nullable: true),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    IsGraded = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenQuestions_OpenAnswers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "OpenAnswers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenQuestions_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenQuestions_Qs_QId",
                        column: x => x.QId,
                        principalTable: "Qs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: true),
                    EvaluationId = table.Column<long>(type: "bigint", nullable: true),
                    EvaluatorId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationEvents_EvaluationEventStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "EvaluationEventStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvaluationEvents_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvaluationEvents_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvaluationEvents_People_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    SelectedByEvaluee = table.Column<bool>(type: "boolean", nullable: false),
                    AId = table.Column<long>(type: "bigint", nullable: true),
                    MultipleChoiceQuestionId = table.Column<long>(type: "bigint", nullable: true),
                    IsCorrectAnswer = table.Column<bool>(type: "boolean", nullable: false),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceAnswers_As_AId",
                        column: x => x.AId,
                        principalTable: "As",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MultipleChoiceAnswers_MultipleChoiceQuestions_MultipleChoic~",
                        column: x => x.MultipleChoiceQuestionId,
                        principalTable: "MultipleChoiceQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MultipleChoiceAnswers_People_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EvalueeParticipations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    EvalueeId = table.Column<long>(type: "bigint", nullable: true),
                    AnswersId = table.Column<long>(type: "bigint", nullable: true),
                    EvaluationEventId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvalueeParticipations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvalueeParticipations_As_AnswersId",
                        column: x => x.AnswersId,
                        principalTable: "As",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvalueeParticipations_EvaluationEvents_EvaluationEventId",
                        column: x => x.EvaluationEventId,
                        principalTable: "EvaluationEvents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvalueeParticipations_People_EvalueeId",
                        column: x => x.EvalueeId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationEvents_CreatedById",
                table: "EvaluationEvents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationEvents_EvaluationId",
                table: "EvaluationEvents",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationEvents_EvaluatorId",
                table: "EvaluationEvents",
                column: "EvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationEvents_StatusId",
                table: "EvaluationEvents",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_CreatedById",
                table: "Evaluations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_QuestionsId",
                table: "Evaluations",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_EvalueeParticipations_AnswersId",
                table: "EvalueeParticipations",
                column: "AnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_EvalueeParticipations_EvaluationEventId",
                table: "EvalueeParticipations",
                column: "EvaluationEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EvalueeParticipations_EvalueeId",
                table: "EvalueeParticipations",
                column: "EvalueeId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceAnswers_AId",
                table: "MultipleChoiceAnswers",
                column: "AId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceAnswers_CreatedById",
                table: "MultipleChoiceAnswers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceAnswers_MultipleChoiceQuestionId",
                table: "MultipleChoiceAnswers",
                column: "MultipleChoiceQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestions_CreatedById",
                table: "MultipleChoiceQuestions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestions_QId",
                table: "MultipleChoiceQuestions",
                column: "QId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenAnswers_AId",
                table: "OpenAnswers",
                column: "AId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenAnswers_CreatedById",
                table: "OpenAnswers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OpenQuestions_AnswerId",
                table: "OpenQuestions",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenQuestions_CreatedById",
                table: "OpenQuestions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OpenQuestions_QId",
                table: "OpenQuestions",
                column: "QId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvalueeParticipations");

            migrationBuilder.DropTable(
                name: "MultipleChoiceAnswers");

            migrationBuilder.DropTable(
                name: "OpenQuestions");

            migrationBuilder.DropTable(
                name: "EvaluationEvents");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "OpenAnswers");

            migrationBuilder.DropTable(
                name: "EvaluationEventStatus");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "As");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Qs");
        }
    }
}
