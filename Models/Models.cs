#nullable disable
using System.ComponentModel.DataAnnotations;

namespace BeepBoopQuiz.Models {
	public class Person {
		public long Id { get; set; }
		public string Name { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }
	}

	public class Evaluation {
		public long Id { get; set; }
		public string Title { get; set; }
		public float Grade { get; set; }
		public bool IsGraded { get; set; }

		public Person CreatedBy { get; set; }

		// Questions { get; set; }
	}

	public class EvaluationEvent {
		public long Id { get; set; }

		[DataType(DataType.Date)]
		public System.DateTime Date { get; set; }

		public EvaluationEventStatus Status { get; set; }

		public Evaluation Evaluation { get; set; }

		public Person Evaluator { get; set; }

		public Person CreatedBy { get; set; }

		public ICollection<EvalueeParticipation> EvalueeParticipations { get; set; }
	}

	public enum EvaluationEventStatus {
		None,
		Active,
		Completed
	}

	public class EvalueeParticipation {
		public long Id { get; set; }
		public float Grade { get; set; }

		public Person Evaluee { get; set; }
	}

	public class EvaluationQuestion {
		public long Id { get; set; }
		public string Heading { get; set; }
		public float Grade { get; set; }
		public bool IsGraded { get; set; }
	}

	public class EvaluationAnswer {
		public long Id { get; set; }
		public bool IsCorrectAnswer { get; set; }
		public float Grade { get; set; }

		public Person CreatedBy { get; set; }
	}

	public class MultipleChoiceQuestion : EvaluationQuestion {
		public bool HasCorrectAnswer { get; set; }
		public ICollection<MultipleChoiceAnswer> Answers { get; set; }
	}

	public class MultipleChoiceAnswer : EvaluationAnswer {
		public string Content { get; set; }
		public bool SelectedByEvaluee { get; set; }
	}
}
