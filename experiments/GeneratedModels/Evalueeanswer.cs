using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels
{
    public partial class Evalueeanswer
    {
        public int EvalueeAnswerId { get; set; }
        public int EvaluationEventId { get; set; }
        public int EvaluationAnswerId { get; set; }
        public int EvalueeId { get; set; }

        public virtual Evaluationanswer EvaluationAnswer { get; set; } = null!;
        public virtual Evaluationevent EvaluationEvent { get; set; } = null!;
        public virtual Evaluee Evaluee { get; set; } = null!;
    }
}
