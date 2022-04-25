using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels {
	public partial class Evaluationanswer {
		public Evaluationanswer() {
			Evalueeanswers = new HashSet<Evalueeanswer>();
		}

		public int EvaluationAnswerId { get; set; }
		public int EvaluationQuestionId { get; set; }
		public int? OpenAnswerId { get; set; }
		public int? MultipleChoiceAnswerId { get; set; }

		public virtual Evaluationquestion EvaluationQuestion { get; set; } = null!;
		public virtual Multiplechoicequestion? MultipleChoiceAnswer { get; set; }
		public virtual Openquestion? OpenAnswer { get; set; }
		public virtual ICollection<Evalueeanswer> Evalueeanswers { get; set; }
	}
}
