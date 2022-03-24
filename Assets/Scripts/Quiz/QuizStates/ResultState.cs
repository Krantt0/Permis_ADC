using Core;

namespace Quiz.QuizStates
{
    public class ResultState : QuizState
    {
        public override void Enter(Quiz quiz, Player player)
        {
            quiz.CalculateRank();
            quiz.QuizUI.ShowResult();

            Events.OnBack += OnBack;
        }

        void OnBack()
        {
            Events.OnContinue -= OnBack;
            Events.OnLoadMainMenu?.Invoke();
        }
    }
}