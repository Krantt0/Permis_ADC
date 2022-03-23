using System.Collections.Generic;
using Core;
using Quiz.QuizStates;
using Quiz.UI;
using UnityEngine;

namespace Quiz
{
    public class Quiz : MonoBehaviour
    {
        public static int IronScore => 5;
        public static int BronzeScore => 10;
        public static int SilverScore => 15;
        public static int GoldScore => 20;
        public static int PlatinumScore => 25;
        public static int DiamondScore => 30;
        public static int MasterScore => 35;
        public static int GrandMasterScore => 37;
        public static int ChallengerScore => 39;

        QuizState _quizState;
        
        public int CurrentQuestionIndex { get; set; }
        [field : SerializeField] public List<QuestionSO> Questions { get; set; }
        public List<int> Answers { get; set; } = new List<int>();
        
        public Player Player { get; private set; }
        public QuizUI QuizUI { get; private set; }

        void Awake()
        {
            Player = FindObjectOfType<Player>();
            QuizUI = FindObjectOfType<QuizUI>();
        }

        void Start()
        {
            ChangeState(new StartState());
        }

        public void ChangeState(QuizState quizState)
        {
            _quizState?.Exit(this, Player);

            _quizState = quizState;
            
            _quizState.Enter(this, Player);
        }

        public void CalculateRank()
        {
            int score = 0;
            
            for (int i = 0; i < Questions.Count; i++)
            {
                if (i >= Answers.Count)
                    break;
                
                if (Questions[i].CorrectAnswerIndex == Answers[i])
                    score++;
            }

            if (score < IronScore)
                Player.Rank = 0;
            if (score < BronzeScore)
                Player.Rank = 1; 
            if (score < SilverScore)
                Player.Rank = 2;
            if (score < GoldScore)
                Player.Rank = 3;
            if (score < PlatinumScore)
                Player.Rank = 4; 
            if (score < DiamondScore)
                Player.Rank = 5; 
            if (score < MasterScore)
                Player.Rank = 6;
            if (score < GrandMasterScore)
                Player.Rank = 7;  
            if (score < ChallengerScore)
                Player.Rank = 8;
        }
    }
}