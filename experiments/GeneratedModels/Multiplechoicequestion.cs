using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels {
	public partial class Multiplechoicequestion {
		public Multiplechoicequestion() {
			Evaluationanswers = new HashSet<Evaluationanswer>();
			Evaluationquestions = new HashSet<Evaluationquestion>();
			Multiplechoicequestionanswers = new HashSet<Multiplechoicequestionanswer>();
		}

		public int MultipleChoiceQuestionId { get; set; }
		public bool MultipleChoiceQuestionMultipleAnswers { get; set; }
		public int MultipleChoiceQuestionCorrectAnswersCount { get; set; }
		public string MultipleChoiceQuestionContent { get; set; } = null!;

		public virtual ICollection<Evaluationanswer> Evaluationanswers { get; set; }
		public virtual ICollection<Evaluationquestion> Evaluationquestions { get; set; }
		public virtual ICollection<Multiplechoicequestionanswer> Multiplechoicequestionanswers { get; set; }
	}
}
