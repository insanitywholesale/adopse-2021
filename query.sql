-- name: GetAllOpenQuestions :many
SELECT * FROM OpenQuestion;

-- name: GetOpenQuestionByID :one
SELECT * FROM OpenQuestion WHERE open_question_id = $1;

-- name: CreateOpenQuestion :exec
INSERT INTO OpenQuestion (
	open_question_content
) VALUES ($1);

-- name: CreateOpenQuestionGetID :one
INSERT INTO OpenQuestion (
	open_question_content
) VALUES ($1) RETURNING open_question_id;



-- name: GetAllOpenQuestionAnswers :many
SELECT * FROM OpenQuestionAnswer;

-- name: GetOpenQuestionAnswerByID :one
SELECT * FROM OpenQuestionAnswer WHERE open_question_answer_id = $1;

-- name: GetOpenQuestionAnswerByQuestionID :one
SELECT * FROM OpenQuestionAnswer WHERE open_question_id = $1;

-- name: CreateOpenQuestionAnswer :exec
INSERT INTO OpenQuestionAnswer (
	open_question_answer_content
) VALUES ($1);

-- name: CreateOpenQuestionAnswerWithQuestion :exec
INSERT INTO OpenQuestionAnswer (
	open_question_answer_content,
	open_question_id
) VALUES ($1, $2);

--NOTE: we already know the ID so why return it?
-- name: CreateOpenQuestionAnswerWithQuestionGetID :one
INSERT INTO OpenQuestionAnswer (
	open_question_answer_content,
	open_question_id
) VALUES ($1, $2) RETURNING open_question_id;

-- name: CreateOpenQuestionAnswerGetID :one
INSERT INTO OpenQuestionAnswer (
	open_question_answer_content
) VALUES ($1) RETURNING open_question_answer_id;



-- name: GetAllMultipleChoiceQuestions :many
SELECT * FROM MultipleChoiceQuestion;

-- name: GetMultipleChoiceQuestionByID :one
SELECT * FROM MultipleChoiceQuestion WHERE multiple_choice_question_id = $1;

-- name: CreateMultipleChoiceQuestion :exec
INSERT INTO MultipleChoiceQuestion (
	multiple_choice_question_multiple_answers,
	multiple_choice_question_correct_answers_count
) VALUES ($1, $2);

-- name: CreateEmptyMultipleChoiceQuestionGetID :one
INSERT INTO MultipleChoiceQuestion (
	multiple_choice_question_content
) VALUES ($1) RETURNING multiple_choice_question_id;

-- name: CreateMultipleChoiceQuestionGetID :one
INSERT INTO MultipleChoiceQuestion (
	multiple_choice_question_multiple_answers,
	multiple_choice_question_correct_answers_count
) VALUES ($1, $2) RETURNING multiple_choice_question_id;



-- name: GetAllMultipleChoiceQuestionAnswers :many
SELECT * FROM MultipleChoiceQuestionAnswer;

-- name: GetMultipleChoiceQuestionAnswerByID :one
SELECT * FROM MultipleChoiceQuestionAnswer WHERE multiple_choice_question_answer_id = $1;

-- name: GetMultipleChoiceQuestionAnswersByQuestionID :many
SELECT * FROM MultipleChoiceQuestionAnswer WHERE multiple_choice_question_id = $1;

-- name: CreateMultipleChoiceQuestionAnswer :exec
INSERT INTO MultipleChoiceQuestionAnswer (
	multiple_choice_question_id,
	multiple_choice_question_answer_content,
	multiple_choice_question_answer_is_correct,
	multiple_choice_question_answer_is_selected
) VALUES ($1, $2, $3, $4);

-- name: CreateMultipleChoiceQuestionAnswerGetID :one
INSERT INTO MultipleChoiceQuestionAnswer (
	multiple_choice_question_id,
	multiple_choice_question_answer_content,
	multiple_choice_question_answer_is_correct,
	multiple_choice_question_answer_is_selected
) VALUES ($1, $2, $3, $4) RETURNING multiple_choice_question_answer_id;
