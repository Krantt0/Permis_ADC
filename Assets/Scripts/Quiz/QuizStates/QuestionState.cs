using Core;

namespace Quiz.QuizStates
{
    public class QuestionState : QuizState
    {
        public override void Enter(Quiz quiz, Player player)
        {
            if (quiz.CurrentQuestionIndex >= quiz.Questions.Count)
                quiz.ChangeState(new ResultState());

            quiz.QuizUI.ShowQuestion(quiz.Questions[quiz.CurrentQuestionIndex]);

            Events.OnAnswer += OnAnswer;
        }

        void OnAnswer(int answerIndex)
        {
            
        }

        public override void Exit(Quiz quiz, Player player)
        {
            quiz.CurrentQuestionIndex++;

            Events.OnAnswer -= OnAnswer;
        }
    }
}