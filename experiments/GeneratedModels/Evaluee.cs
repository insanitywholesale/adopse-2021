using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels {
	public partial class Evaluee {
		public Evaluee() {
			Evalueeanswers = new HashSet<Evalueeanswer>();
		}

		public int EvalueeId { get; set; }
		public string EvalueeName { get; set; } = null!;
		public string? EvalueeEmail { get; set; }
		public string? EvalueePhone { get; set; }

		public virtual ICollection<Evalueeanswer> Evalueeanswers { get; set; }
	}
}
