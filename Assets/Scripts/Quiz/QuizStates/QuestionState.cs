using System.Linq;
using Core;

namespace Quiz.QuizStates
{
    public class QuestionState : QuizState
    {
        Quiz _quiz;
        
        public override void Enter(Quiz quiz, Player player)
        {
            _quiz = quiz;

            if (quiz.CurrentQuestionIndex >= quiz.Questions.Count)
            {
                quiz.ChangeState(new ResultState());
                return;
            }

            quiz.QuizUI.ShowQuestion(quiz.Questions[quiz.CurrentQuestionIndex]);

            Events.OnAnswer += OnAnswer;
        }

        void OnAnswer(int answerIndex)
        {
            _quiz.Answers.Add(answerIndex);
            _quiz.ChangeState(new AnswerState());
        }

        public override void Exit(Quiz quiz, Player player)
        {
            Events.OnAnswer -= OnAnswer;
        }
    }
}