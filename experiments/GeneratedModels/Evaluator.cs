using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels
{
    public partial class Evaluator
    {
        public Evaluator()
        {
            Evaluationevents = new HashSet<Evaluationevent>();
        }

        public int EvaluatorId { get; set; }
        public string EvaluatorName { get; set; } = null!;
        public string? EvaluatorEmail { get; set; }
        public string? EvaluatorPhone { get; set; }
        public int? EvaluatorOrganizationId { get; set; }

        public virtual Organization? EvaluatorOrganization { get; set; }
        public virtual ICollection<Evaluationevent> Evaluationevents { get; set; }
    }
}
