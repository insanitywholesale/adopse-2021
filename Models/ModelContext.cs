using BeepBoopQuiz.Models;

using Microsoft.EntityFrameworkCore;

namespace BeepBoopQuiz.Models {
	public class QuizContext : DbContext {
		public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

		public DbSet<Person> People { get; set; } = null!;

		public DbSet<Evaluation> Evaluations { get; set; } = null!;

		public DbSet<EvaluationEvent> EvaluationEvents { get; set; } = null!;

		public DbSet<EvalueeParticipation>? EvalueeParticipations { get; set; } = null;

		public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; } = null!;
		public DbSet<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; } = null!;
	}
}
