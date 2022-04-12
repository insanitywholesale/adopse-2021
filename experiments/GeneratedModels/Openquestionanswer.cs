using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels
{
    public partial class Openquestionanswer
    {
        public int OpenQuestionAnswerId { get; set; }
        public int? OpenQuestionId { get; set; }
        public string OpenQuestionAnswerContent { get; set; } = null!;

        public virtual Openquestion? OpenQuestion { get; set; }
    }
}
