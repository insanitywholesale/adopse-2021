using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels {
	public partial class Evaluationquestion {
		public Evaluationquestion() {
			Evaluationanswers = new HashSet<Evaluationanswer>();
		}

		public int EvaluationQuestionId { get; set; }
		public int? EvaluationId { get; set; }
		public int? EvaluationOpenQuestionId { get; set; }
		public int? EvaluationMultipleChoiceQuestionId { get; set; }

		public virtual Evaluation? Evaluation { get; set; }
		public virtual Multiplechoicequestion? EvaluationMultipleChoiceQuestion { get; set; }
		public virtual Openquestion? EvaluationOpenQuestion { get; set; }
		public virtual ICollection<Evaluationanswer> Evaluationanswers { get; set; }
	}
}
