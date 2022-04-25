using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels {
	public partial class Evaluation {
		public Evaluation() {
			Evaluationevents = new HashSet<Evaluationevent>();
			Evaluationquestions = new HashSet<Evaluationquestion>();
		}

		public int EvaluationId { get; set; }
		public string EvaluationTitle { get; set; } = null!;

		public virtual ICollection<Evaluationevent> Evaluationevents { get; set; }
		public virtual ICollection<Evaluationquestion> Evaluationquestions { get; set; }
	}
}
