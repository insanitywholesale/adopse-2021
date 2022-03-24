#nullable disable
using System.ComponentModel.DataAnnotations;

namespace adopse_2021.TrialModels
{
	public class Organization
	{
		public long Id { get; set; }
		public string Name { get; set; }
	}
	public class Person
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}

	public class Evaluee : Person
	{
	}

	public class Evaluator : Person
	{
		public long OrganizationId { get; set; }
        public virtual Organization Organization { get ; set; }
	}

	public class Evaluation
	{
		public long Id { get; set; }
		public string Title { get; set; }
    }

	public class EvaluationEvent
	{
		public long Id { get; set; }

		[DataType(DataType.Date)]
		public DateTime EventDate { get; set; }

		public bool Active { get; set; }
		public bool Passed { get; set; }
		public bool Completed { get; set; }

		public Evaluation Evaluation { get; set; }
		public Evaluator Evaluator { get; set; }

		public ICollection<EvalueeParticipation> EvalueeParticipations { get; set; }
	}

    public class EvalueeParticipation {
		public long Id { get; set; }

        public long EvalueeId { get; set; }
        public Evaluee Evaluee { get; set; }

        public long EvaluationEventId { get; set; }
        public EvaluationEvent EvaluationEvent { get; set; }
    }

    public class EvalueeAnswer {
		public long Id { get; set; }

        public long EvaluationQuestionId { get; set; }
        public EvaluationQuestion EvaluationQuestion { get; set; }

        public long EvaluationEventId { get; set; }
        public EvaluationEvent EvaluationEvent { get; set; }
    }

	public class EvaluationQuestion
	{
		public long Id { get; set; }
		public string Heading { get; set; }

        public List<EvaluationAnswer> EvaluationAnswers { get; set; }
	}

	public class EvaluationAnswer
	{
		public long Id { get; set; }
		public bool IsCorrectAnswer { get; set; }
        public string Content { get; set; }

        public long EvaluationQuestionId { get; set; }
        public EvaluationQuestion EvaluationQuestion { get; set; }
	}
}