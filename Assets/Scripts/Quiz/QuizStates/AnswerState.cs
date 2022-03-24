using Core;

namespace Quiz.QuizStates
{
    public class AnswerState : QuizState
    {
        Quiz _quiz;
        
        public override void Enter(Quiz quiz, Player player)
        {
            _quiz = quiz;

            quiz.QuizUI.ShowAnswer(quiz.Questions[quiz.CurrentQuestionIndex]);

            Events.OnContinue += OnContinue;
        }

        void OnContinue()
        {
            _quiz.ChangeState(new QuestionState());
        }

        public override void Exit(Quiz quiz, Player player)
        {
            quiz.CurrentQuestionIndex++;

            Events.OnContinue -= OnContinue;
        }
    }
}