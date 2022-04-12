using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels
{
    public partial class Evaluationevent
    {
        public Evaluationevent()
        {
            Evalueeanswers = new HashSet<Evalueeanswer>();
        }

        public int EvaluationEventId { get; set; }
        public DateTime? EvaluationEventDate { get; set; }
        public int? EvaluationEventEvaluatorId { get; set; }
        public int? EvaluationEventEvaluationId { get; set; }
        public bool? EvaluationEventActive { get; set; }
        public bool? EvaluationEventPassed { get; set; }
        public bool? EvaluationEventCompleted { get; set; }

        public virtual Evaluation? EvaluationEventEvaluation { get; set; }
        public virtual Evaluator? EvaluationEventEvaluator { get; set; }
        public virtual ICollection<Evalueeanswer> Evalueeanswers { get; set; }
    }
}
