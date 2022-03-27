--CREATE SCHEMA eval;

CREATE TABLE IF NOT EXISTS Organization (
	organization_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	organization_name VARCHAR NOT NULL,
	organization_email VARCHAR NOT NULL,
	organization_phone1 VARCHAR NOT NULL,
	organization_phone2 VARCHAR NOT NULL,
	organization_description VARCHAR
);

CREATE TABLE IF NOT EXISTS Evaluee (
	evaluee_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	evaluee_name VARCHAR NOT NULL,
	evaluee_email VARCHAR,
	evaluee_phone VARCHAR
);

CREATE TABLE IF NOT EXISTS Evaluator (
	evaluator_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	evaluator_name VARCHAR NOT NULL,
	evaluator_email VARCHAR,
	evaluator_phone VARCHAR,
	evaluator_organization_id INTEGER REFERENCES Organization(organization_id)
);

CREATE TABLE IF NOT EXISTS Evaluation (
	evaluation_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	evaluation_title VARCHAR NOT NULL
);

CREATE TABLE IF NOT EXISTS EvaluationEvent (
	evaluation_event_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	evaluation_event_date TIMESTAMP DEFAULT NULL,
	evaluation_event_evaluator_id INTEGER REFERENCES Evaluator(evaluator_id),
	evaluation_event_evaluation_id INTEGER REFERENCES Evaluation(evaluation_id),
	evaluation_event_active BOOLEAN DEFAULT NULL,
	evaluation_event_passed BOOLEAN DEFAULT NULL,
	evaluation_event_completed BOOLEAN DEFAULT NULL
);

CREATE TABLE IF NOT EXISTS EvalueeAnswer (
	evaluee_answer_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	evaluation_event_id INTEGER REFERENCES EvaluationEvent(evaluation_event_id) NOT NULL,
	evaluation_answer_id INTEGER REFERENCES EvaluationAnswer(evaluation_answer_id) NOT NULL,
	evaluee_id INTEGER REFERENCES Evaluee(evaluee_id) NOT NULL
);

CREATE TABLE IF NOT EXISTS EvaluationAnswer (
	evaluation_answer_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	evaluation_question_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	open_answer_id INTEGER REFERENCES OpenQuestion(open_question_id) DEFAULT NULL,
	fill_the_gap_answer_id INTEGER REFERENCES FillTheGapQuestion(fill_the_gap_question_id) DEFAULT NULL,
	multiple_choice_answer_id INTEGER REFERENCES MultipleChoiceQuestion(multiple_choice_question_id) DEFAULT NULL,
	correct_answer_answer_id INTEGER REFERENCES CorrectAnswerQuestion(correct_answer_question_id) DEFAULT NULL
);

CREATE TABLE IF NOT EXISTS EvaluationQuestion (
	evaluation_question_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	evaluation_id INTEGER REFERENCES Evaluation(evaluation_id),
	evaluation_open_question_id INTEGER REFERENCES OpenQuestion(open_question_id) DEFAULT NULL,
	evaluation_fill_the_gap_question_id INTEGER REFERENCES FillTheGapQuestion(fill_the_gap_question_id) DEFAULT NULL,
	evaluation_multiple_choice_question_id INTEGER REFERENCES MultipleChoiceQuestion(multiple_choice_question_id) DEFAULT NULL,
	evaluation_correct_answer_question_id INTEGER REFERENCES CorrectAnswerQuestion(correct_answer_question_id) DEFAULT NULL
);

CREATE TABLE IF NOT EXISTS OpenQuestion (
	open_question_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	open_question_content VARCHAR NOT NULL
);

CREATE TABLE IF NOT EXISTS OpenQuestionAnswer (
	open_question_answer_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	open_question_id INTEGER REFERENCES OpenQuestion(open_question_id) NOT NULL,
	open_question_answer_content VARCHAR NOT NULL
);

CREATE TABLE IF NOT EXISTS MultipleChoiceQuestion (
	multiple_choice_question_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	multiple_choice_question_multiple_answers BOOLEAN NOT NULL DEFAULT FALSE,
	multiple_choice_question_correct_answers_count INTEGER NOT NULL DEFAULT 0,
	multiple_choice_question_content VARCHAR NOT NULL
);

CREATE TABLE IF NOT EXISTS MultipleChoiceQuestionAnswer (
	multiple_choice_question_answer_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	multiple_choice_question_id INTEGER REFERENCES MultipleChoiceQuestion(multiple_choice_question_id) NOT NULL,
	multiple_choice_question_answer_is_correct BOOLEAN NOT NULL,
	multiple_choice_question_answer_is_selected BOOLEAN NOT NULL,
	multiple_choice_question_answer_content VARCHAR NOT NULL
);

CREATE TABLE IF NOT EXISTS FillTheGapQuestion (
	fill_the_gap_question_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	fill_the_gap_question_content VARCHAR NOT NULL,
	fill_the_gap_question_blanks_count INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS FillTheGapQuestionAnswer (
	fill_the_gap_question_answer_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	fill_the_gap_question_id INTEGER REFERENCES FillTheGapQuestion(fill_the_gap_question_id) NOT NULL,
	fill_the_gap_question_answer_content VARCHAR NOT NULL,
	fill_the_gap_question_answer_is_correct_answer BOOLEAN NOT NULL,
	fill_the_gap_question_answer_blank_index INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS CorrectAnswerQuestion (
	correct_answer_question_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	correct_answer_question_content VARCHAR NOT NULL
);

CREATE TABLE IF NOT EXISTS CorrectAnswerQuestionAnswer (
	correct_answer_question_answer_id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	correct_answer_question_id INTEGER REFERENCES CorrectAnswerQuestion(correct_answer_question_id) NOT NULL,
	correct_answer_question_answer_is_correct_answer BOOLEAN NOT NULL
);
