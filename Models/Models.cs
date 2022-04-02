#nullable disable
using System.ComponentModel.DataAnnotations;

namespace adopse_2021.Models {
	public class Person {
		public long Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}

	public class Evaluee : Person {
		public string Notes { get; set; }
	}

	public class Evaluator : Person {
		public string Organization { get; set; }
	}

	public class Evaluation {
		public long Id { get; set; }
		public string Title { get; set; }

		public Q Questions { get; set; }
	}

	public class EvaluationEvent {
		public long Id { get; set; }

		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		public bool Active { get; set; }
		public bool Passed { get; set; }
		public bool Completed { get; set; }

		public Evaluation Evaluation { get; set; }

		public Evaluator Evaluator { get; set; }

		public ICollection<EvalueeParticipation> EvalueeParticipations { get; set; }
	}

	public class EvalueeParticipation {
		public long Id { get; set; }

		public float Grade { get; set; }

		public Evaluee Evaluee { get; set; }

		public A Answers { get; set; }
	}

	public class EvaluationQuestion {
		public long Id { get; set; }
		public string Heading { get; set; }
		public float Grade { get; set; }
	}

	public class EvaluationAnswer {
		public long Id { get; set; }
		public bool IsCorrectAnswer { get; set; }
		public float Grade { get; set; }
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
