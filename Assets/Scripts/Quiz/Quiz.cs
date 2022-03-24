using System.Collections.Generic;
using Core;
using Quiz.QuizStates;
using Quiz.UI;
using UnityEngine;

namespace Quiz
{
    public class Quiz : MonoBehaviour
    {
        public const int BRONZE_SCORE = 10;
        public const int SILVER_SCORE = 15;
        public const int GOLD_SCORE = 20;
        public const int PLATINUM_SCORE = 25;
        public const int DIAMOND_SCORE = 30;
        public const int MASTER_SCORE = 35;
        public const int GRAND_MASTER_SCORE = 37;
        public const int CHALLENGER_SCORE = 39;

        [SerializeField] List<QuestionSO> _questions;
        
        QuizState _quizState;

        public int CurrentQuestionIndex { get; set; }

        public List<QuestionSO> Questions => _questions;
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

            if (Answers.Count != Questions.Count)
                return;
            
            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].CorrectAnswerIndex == Answers[i])
                    score++;
            }

            Player.Score = score;
            
            if (score >= BRONZE_SCORE)
                Player.Rank = 1; 
            if (score >= SILVER_SCORE)
                Player.Rank = 2;
            if (score >= GOLD_SCORE)
                Player.Rank = 3;
            if (score >= PLATINUM_SCORE)
                Player.Rank = 4; 
            if (score >= DIAMOND_SCORE)
                Player.Rank = 5; 
            if (score >= MASTER_SCORE)
                Player.Rank = 6;
            if (score >= GRAND_MASTER_SCORE)
                Player.Rank = 7;  
            if (score >= CHALLENGER_SCORE)
                Player.Rank = 8;
        }
    }
}