#nullable disable
using System.ComponentModel.DataAnnotations;

namespace adopse_2021.Models {
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

		public Q Questions { get; set; }
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

	public class EvaluationEventStatus {
		// Id is needed otherwise there is an error about entity not having a primary key
		public long Id { get; set; }

		public bool Active { get; set; } = false;
		public bool Completed { get; set; } = false;
	}

	public class EvalueeParticipation {
		public long Id { get; set; }
		public float Grade { get; set; }

		public Person Evaluee { get; set; }

		public A Answers { get; set; }
	}

	public class EvaluationQuestion {
		public long Id { get; set; }
		public string Heading { get; set; }
		public float Grade { get; set; }
		public bool IsGraded { get; set; }

		public Person CreatedBy { get; set; }
	}

	public class EvaluationAnswer {
		public long Id { get; set; }
		public bool IsCorrectAnswer { get; set; }
		public float Grade { get; set; }

		public Person CreatedBy { get; set; }
	}

	public class OpenQuestion : EvaluationQuestion {
		public OpenAnswer Answer { get; set; }
	}

	public class OpenAnswer : EvaluationAnswer {
		public string ContentFromEvaluee { get; set; }
	}

	public class MultipleChoiceQuestion : EvaluationQuestion {
		public bool HasCorrectAnswer { get; set; }
		public ICollection<MultipleChoiceAnswer> Answers { get; set; }
	}

	public class MultipleChoiceAnswer : EvaluationAnswer {
		public string Content { get; set; }
		public bool SelectedByEvaluee { get; set; }
	}

	public class Q {
		public long Id { get; set; }

		public ICollection<OpenQuestion> OpenQuestions { get; set; }
		public ICollection<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
	}

	public class A {
		public long Id { get; set; }

		public ICollection<OpenAnswer> OpenAnswers { get; set; }
		public ICollection<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; }
	}

	//TODO: add later
	//public class FillTheGapQuestion : EvaluationEvent
	//{
	//    public string Type => "FillTheGap";
	//    public int BlanksCount { get; set; }
	//}
	//
	//public class FillTheGapAnswer : EvaluationAnswer
	//{
	//    public string Type => "FillTheGap";
	//    public string? Content { get; set; }
	//    public int BlankIndex { get; set; }
	//}
	//
	//public class CorrectAnswerQuestion : EvaluationQuestion
	//{
	//    public string Type => "CorrectAnswer";
	//}
	//
	//public class CorrectAnswerAnswer : EvaluationAnswer
	//{
	//    public string Type => "CorrectAnswer";
	//}
}
