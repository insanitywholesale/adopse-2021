using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace adopse_2021.experiments.GeneratedModels
{
    public partial class testerContext : DbContext
    {
        public testerContext()
        {
        }

        public testerContext(DbContextOptions<testerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evaluation> Evaluations { get; set; } = null!;
        public virtual DbSet<Evaluationanswer> Evaluationanswers { get; set; } = null!;
        public virtual DbSet<Evaluationevent> Evaluationevents { get; set; } = null!;
        public virtual DbSet<Evaluationquestion> Evaluationquestions { get; set; } = null!;
        public virtual DbSet<Evaluator> Evaluators { get; set; } = null!;
        public virtual DbSet<Evaluee> Evaluees { get; set; } = null!;
        public virtual DbSet<Evalueeanswer> Evalueeanswers { get; set; } = null!;
        public virtual DbSet<Multiplechoicequestion> Multiplechoicequestions { get; set; } = null!;
        public virtual DbSet<Multiplechoicequestionanswer> Multiplechoicequestionanswers { get; set; } = null!;
        public virtual DbSet<Openquestion> Openquestions { get; set; } = null!;
        public virtual DbSet<Openquestionanswer> Openquestionanswers { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=tester;User Id=tester;Password=Apasswd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.ToTable("evaluation");

                entity.Property(e => e.EvaluationId)
                    .HasColumnName("evaluation_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.EvaluationTitle)
                    .HasColumnType("character varying")
                    .HasColumnName("evaluation_title");
            });

            modelBuilder.Entity<Evaluationanswer>(entity =>
            {
                entity.ToTable("evaluationanswer");

                entity.Property(e => e.EvaluationAnswerId)
                    .HasColumnName("evaluation_answer_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.EvaluationQuestionId).HasColumnName("evaluation_question_id");

                entity.Property(e => e.MultipleChoiceAnswerId).HasColumnName("multiple_choice_answer_id");

                entity.Property(e => e.OpenAnswerId).HasColumnName("open_answer_id");

                entity.HasOne(d => d.EvaluationQuestion)
                    .WithMany(p => p.Evaluationanswers)
                    .HasForeignKey(d => d.EvaluationQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evaluationanswer_evaluation_question_id_fkey");

                entity.HasOne(d => d.MultipleChoiceAnswer)
                    .WithMany(p => p.Evaluationanswers)
                    .HasForeignKey(d => d.MultipleChoiceAnswerId)
                    .HasConstraintName("evaluationanswer_multiple_choice_answer_id_fkey");

                entity.HasOne(d => d.OpenAnswer)
                    .WithMany(p => p.Evaluationanswers)
                    .HasForeignKey(d => d.OpenAnswerId)
                    .HasConstraintName("evaluationanswer_open_answer_id_fkey");
            });

            modelBuilder.Entity<Evaluationevent>(entity =>
            {
                entity.ToTable("evaluationevent");

                entity.Property(e => e.EvaluationEventId)
                    .HasColumnName("evaluation_event_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.EvaluationEventActive).HasColumnName("evaluation_event_active");

                entity.Property(e => e.EvaluationEventCompleted).HasColumnName("evaluation_event_completed");

                entity.Property(e => e.EvaluationEventDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("evaluation_event_date");

                entity.Property(e => e.EvaluationEventEvaluationId).HasColumnName("evaluation_event_evaluation_id");

                entity.Property(e => e.EvaluationEventEvaluatorId).HasColumnName("evaluation_event_evaluator_id");

                entity.Property(e => e.EvaluationEventPassed).HasColumnName("evaluation_event_passed");

                entity.HasOne(d => d.EvaluationEventEvaluation)
                    .WithMany(p => p.Evaluationevents)
                    .HasForeignKey(d => d.EvaluationEventEvaluationId)
                    .HasConstraintName("evaluationevent_evaluation_event_evaluation_id_fkey");

                entity.HasOne(d => d.EvaluationEventEvaluator)
                    .WithMany(p => p.Evaluationevents)
                    .HasForeignKey(d => d.EvaluationEventEvaluatorId)
                    .HasConstraintName("evaluationevent_evaluation_event_evaluator_id_fkey");
            });

            modelBuilder.Entity<Evaluationquestion>(entity =>
            {
                entity.ToTable("evaluationquestion");

                entity.Property(e => e.EvaluationQuestionId)
                    .HasColumnName("evaluation_question_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.EvaluationId).HasColumnName("evaluation_id");

                entity.Property(e => e.EvaluationMultipleChoiceQuestionId).HasColumnName("evaluation_multiple_choice_question_id");

                entity.Property(e => e.EvaluationOpenQuestionId).HasColumnName("evaluation_open_question_id");

                entity.HasOne(d => d.Evaluation)
                    .WithMany(p => p.Evaluationquestions)
                    .HasForeignKey(d => d.EvaluationId)
                    .HasConstraintName("evaluationquestion_evaluation_id_fkey");

                entity.HasOne(d => d.EvaluationMultipleChoiceQuestion)
                    .WithMany(p => p.Evaluationquestions)
                    .HasForeignKey(d => d.EvaluationMultipleChoiceQuestionId)
                    .HasConstraintName("evaluationquestion_evaluation_multiple_choice_question_id_fkey");

                entity.HasOne(d => d.EvaluationOpenQuestion)
                    .WithMany(p => p.Evaluationquestions)
                    .HasForeignKey(d => d.EvaluationOpenQuestionId)
                    .HasConstraintName("evaluationquestion_evaluation_open_question_id_fkey");
            });

            modelBuilder.Entity<Evaluator>(entity =>
            {
                entity.ToTable("evaluator");

                entity.Property(e => e.EvaluatorId)
                    .HasColumnName("evaluator_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.EvaluatorEmail)
                    .HasColumnType("character varying")
                    .HasColumnName("evaluator_email");

                entity.Property(e => e.EvaluatorName)
                    .HasColumnType("character varying")
                    .HasColumnName("evaluator_name");

                entity.Property(e => e.EvaluatorOrganizationId).HasColumnName("evaluator_organization_id");

                entity.Property(e => e.EvaluatorPhone)
                    .HasColumnType("character varying")
                    .HasColumnName("evaluator_phone");

                entity.HasOne(d => d.EvaluatorOrganization)
                    .WithMany(p => p.Evaluators)
                    .HasForeignKey(d => d.EvaluatorOrganizationId)
                    .HasConstraintName("evaluator_evaluator_organization_id_fkey");
            });

            modelBuilder.Entity<Evaluee>(entity =>
            {
                entity.ToTable("evaluee");

                entity.Property(e => e.EvalueeId)
                    .HasColumnName("evaluee_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.EvalueeEmail)
                    .HasColumnType("character varying")
                    .HasColumnName("evaluee_email");

                entity.Property(e => e.EvalueeName)
                    .HasColumnType("character varying")
                    .HasColumnName("evaluee_name");

                entity.Property(e => e.EvalueePhone)
                    .HasColumnType("character varying")
                    .HasColumnName("evaluee_phone");
            });

            modelBuilder.Entity<Evalueeanswer>(entity =>
            {
                entity.ToTable("evalueeanswer");

                entity.Property(e => e.EvalueeAnswerId)
                    .HasColumnName("evaluee_answer_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.EvaluationAnswerId).HasColumnName("evaluation_answer_id");

                entity.Property(e => e.EvaluationEventId).HasColumnName("evaluation_event_id");

                entity.Property(e => e.EvalueeId).HasColumnName("evaluee_id");

                entity.HasOne(d => d.EvaluationAnswer)
                    .WithMany(p => p.Evalueeanswers)
                    .HasForeignKey(d => d.EvaluationAnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evalueeanswer_evaluation_answer_id_fkey");

                entity.HasOne(d => d.EvaluationEvent)
                    .WithMany(p => p.Evalueeanswers)
                    .HasForeignKey(d => d.EvaluationEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evalueeanswer_evaluation_event_id_fkey");

                entity.HasOne(d => d.Evaluee)
                    .WithMany(p => p.Evalueeanswers)
                    .HasForeignKey(d => d.EvalueeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evalueeanswer_evaluee_id_fkey");
            });

            modelBuilder.Entity<Multiplechoicequestion>(entity =>
            {
                entity.ToTable("multiplechoicequestion");

                entity.Property(e => e.MultipleChoiceQuestionId)
                    .HasColumnName("multiple_choice_question_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.MultipleChoiceQuestionContent)
                    .HasColumnType("character varying")
                    .HasColumnName("multiple_choice_question_content");

                entity.Property(e => e.MultipleChoiceQuestionCorrectAnswersCount).HasColumnName("multiple_choice_question_correct_answers_count");

                entity.Property(e => e.MultipleChoiceQuestionMultipleAnswers).HasColumnName("multiple_choice_question_multiple_answers");
            });

            modelBuilder.Entity<Multiplechoicequestionanswer>(entity =>
            {
                entity.ToTable("multiplechoicequestionanswer");

                entity.Property(e => e.MultipleChoiceQuestionAnswerId)
                    .HasColumnName("multiple_choice_question_answer_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.MultipleChoiceQuestionAnswerContent)
                    .HasColumnType("character varying")
                    .HasColumnName("multiple_choice_question_answer_content");

                entity.Property(e => e.MultipleChoiceQuestionAnswerIsCorrect).HasColumnName("multiple_choice_question_answer_is_correct");

                entity.Property(e => e.MultipleChoiceQuestionAnswerIsSelected).HasColumnName("multiple_choice_question_answer_is_selected");

                entity.Property(e => e.MultipleChoiceQuestionId).HasColumnName("multiple_choice_question_id");

                entity.HasOne(d => d.MultipleChoiceQuestion)
                    .WithMany(p => p.Multiplechoicequestionanswers)
                    .HasForeignKey(d => d.MultipleChoiceQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("multiplechoicequestionanswer_multiple_choice_question_id_fkey");
            });

            modelBuilder.Entity<Openquestion>(entity =>
            {
                entity.ToTable("openquestion");

                entity.Property(e => e.OpenQuestionId)
                    .HasColumnName("open_question_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.OpenQuestionContent)
                    .HasColumnType("character varying")
                    .HasColumnName("open_question_content");
            });

            modelBuilder.Entity<Openquestionanswer>(entity =>
            {
                entity.ToTable("openquestionanswer");

                entity.Property(e => e.OpenQuestionAnswerId)
                    .HasColumnName("open_question_answer_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.OpenQuestionAnswerContent)
                    .HasColumnType("character varying")
                    .HasColumnName("open_question_answer_content");

                entity.Property(e => e.OpenQuestionId).HasColumnName("open_question_id");

                entity.HasOne(d => d.OpenQuestion)
                    .WithMany(p => p.Openquestionanswers)
                    .HasForeignKey(d => d.OpenQuestionId)
                    .HasConstraintName("openquestionanswer_open_question_id_fkey");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("organization");

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("organization_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.OrganizationDescription)
                    .HasColumnType("character varying")
                    .HasColumnName("organization_description");

                entity.Property(e => e.OrganizationEmail)
                    .HasColumnType("character varying")
                    .HasColumnName("organization_email");

                entity.Property(e => e.OrganizationName)
                    .HasColumnType("character varying")
                    .HasColumnName("organization_name");

                entity.Property(e => e.OrganizationPhone1)
                    .HasColumnType("character varying")
                    .HasColumnName("organization_phone1");

                entity.Property(e => e.OrganizationPhone2)
                    .HasColumnType("character varying")
                    .HasColumnName("organization_phone2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
