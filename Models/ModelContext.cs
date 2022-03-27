using Microsoft.EntityFrameworkCore;

namespace adopse_2021.Models
{
	public class EvaluationContext : DbContext
	{
		public EvaluationContext(DbContextOptions<EvaluationContext> options) : base(options)
		{
		}

		public DbSet<Person> People { get; set; } = null!;
		public DbSet<Evaluee> Evaluees { get; set; } = null!;
		public DbSet<Evaluator> Evaluators { get; set; } = null!;

		public DbSet<Evaluation> Evaluations { get; set; } = null!;

		public DbSet<EvaluationEvent> EvaluationEvents { get; set; } = null!;

		public DbSet<EvaluationQuestion> Questions { get; set; } = null!;
		public DbSet<EvaluationAnswer> Answers { get; set; } = null!;
		public DbSet<OpenQuestion> OpenQuestions { get; set; } = null!;
		public DbSet<OpenAnswer> OpenAnswers { get; set; } = null!;
		public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; } = null!;
		public DbSet<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; } = null!;
		public DbSet<Q> Qs { get; set; } = null!;

		public DbSet<Organization> Organization { get; set; } = null!;
	}
}