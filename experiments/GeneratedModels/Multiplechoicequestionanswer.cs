using System;
using System.Collections.Generic;

namespace adopse_2021.experiments.GeneratedModels
{
    public partial class Multiplechoicequestionanswer
    {
        public int MultipleChoiceQuestionAnswerId { get; set; }
        public int MultipleChoiceQuestionId { get; set; }
        public bool MultipleChoiceQuestionAnswerIsCorrect { get; set; }
        public bool MultipleChoiceQuestionAnswerIsSelected { get; set; }
        public string MultipleChoiceQuestionAnswerContent { get; set; } = null!;

        public virtual Multiplechoicequestion MultipleChoiceQuestion { get; set; } = null!;
    }
}
