using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels {
	public partial class Openquestion {
		public Openquestion() {
			Evaluationanswers = new HashSet<Evaluationanswer>();
			Evaluationquestions = new HashSet<Evaluationquestion>();
			Openquestionanswers = new HashSet<Openquestionanswer>();
		}

		public int OpenQuestionId { get; set; }
		public string OpenQuestionContent { get; set; } = null!;

		public virtual ICollection<Evaluationanswer> Evaluationanswers { get; set; }
		public virtual ICollection<Evaluationquestion> Evaluationquestions { get; set; }
		public virtual ICollection<Openquestionanswer> Openquestionanswers { get; set; }
	}
}
