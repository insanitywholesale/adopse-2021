using System;

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
        public Organization? Organization { get; set; }
    }

    public class Evaluation
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public virtual ICollection<Evaluator>? Evaluators { get; set; }
        public virtual ICollection<EvaluationQuestion>? Questions { get; set; }
    }

    public class EvaluationEvent
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public bool Passed { get; set; }
        public bool Completed { get; set; }
        public Evaluation? Evaluation { get; set; }
    }

    // For the inheritance stuff below I got help from here:
    // https://stackoverflow.com/questions/66772647/how-to-deserialize-a-json-array-containing-objects-having-different-shape-in-c
    public class EvaluationQuestion
    {
        string? Type { get; }
        public long Id { get; set; }
        public string? Heading { get; set; }
    }

    public class EvaluationAnswer
    {
        string? Type { get; }
        public long Id { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }

    public class OpenQuestion : EvaluationQuestion
    {
        public string Type => "Open";
        public OpenAnswer? Answer { get; set; }
    }

    public class OpenAnswer : EvaluationAnswer
    {
        public string Type => "Open";
        public string? ContentFromEvaluee { get; set; }
    }

    public class MultipleChoiceQuestion : EvaluationQuestion
    {
        public string Type => "MultipleChoice";
        public ICollection<MultipleChoiceAnswer>? Answers { get; set; }
    }

    public class MultipleChoiceAnswer : EvaluationAnswer
    {
        public string Type => "MultipleChoice";
        public bool SelectedByEvaluee { get; set; }
    }

    //TODO: add later
    //public class FillTheGapQuestion : EvaluationEvent
    //{
    //    public string Type => "FillTheGap";
    //    public int BlanksCount { get; set; }
    //}
    //
    //public class FillTheGapAnswer : EvaluationAnswer
    //{
    //    public string Type => "FillTheGap";
    //    public string? Content { get; set; }
    //    public int BlankIndex { get; set; }
    //}
    //
    //public class CorrectAnswerQuestion : EvaluationQuestion
    //{
    //    public string Type => "CorrectAnswer";
    //}
    //
    //public class CorrectAnswerAnswer : EvaluationAnswer
    //{
    //    public string Type => "CorrectAnswer";
    //}

    public class Organization
    {
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}

