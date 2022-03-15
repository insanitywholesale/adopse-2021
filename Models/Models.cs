namespace adopse_2021.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class Evaluee : Person
    {
        public string? Notes { get; set; }
    }

    public class Evaluator : Person
    {
        public bool IsSpectator { get; set; }
    }

    public class Evaluation
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public List<EvaluationQuestion>? Questions { get; set; }
    }

    public class EvaluationEvent
    {
        public long Id { get; set; }
        //public string? Date { get; set; }
        public bool Passed { get; set; }
        public bool Completed { get; set; }
    }

    public class EvaluationQuestion
    {
        public long Id { get; set; }
        public string? Content { get; set; }
        // List of answers
    }

    public class EvaluationAnswer
    {
        public long Id { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }

    public class OpenQuestion : EvaluationQuestion
    {
    }

    public class OpenQuestionAnswer : EvaluationAnswer
    {
        public string? Content { get; set; }
    }

    public class MultipleChoiceQuestion : EvaluationQuestion
    {
        public bool HasMultipleAnswers { get; set; }
        public int CorrectAnswersCount { get; set; }
    }

    public class MultipleChoiceQuestionAnswer : EvaluationAnswer
    {
        public int EvalueeAnswer { get; set; }
    }

    public class FillTheGapQuestion : EvaluationEvent
    {
        public int BlanksCount { get; set; }
    }

    public class FillTheGapQuestionAnswer : EvaluationAnswer
    {
        public string? Content { get; set; }
        public int BlankIndex { get; set; }
    }

    public class CorrectAnswerQuestion : EvaluationQuestion
    {
    }

    public class CorrectAnswerQuestionAnswer : EvaluationAnswer
    {
    }
}

