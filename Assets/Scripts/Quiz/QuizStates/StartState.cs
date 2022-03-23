using Core;

namespace Quiz.QuizStates
{
    public class StartState : QuizState
    {
        public override void Enter(Quiz quiz, Player player)
        {
            quiz.QuizUI.Initalize(quiz.Player, quiz);
            quiz.CurrentQuestionIndex = 0;
            quiz.ChangeState(new QuestionState());
        }
    }
}