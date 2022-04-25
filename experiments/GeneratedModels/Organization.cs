using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels {
	public partial class Organization {
		public Organization() {
			Evaluators = new HashSet<Evaluator>();
		}

		public int OrganizationId { get; set; }
		public string OrganizationName { get; set; } = null!;
		public string OrganizationEmail { get; set; } = null!;
		public string OrganizationPhone1 { get; set; } = null!;
		public string OrganizationPhone2 { get; set; } = null!;
		public string? OrganizationDescription { get; set; }

		public virtual ICollection<Evaluator> Evaluators { get; set; }
	}
}
