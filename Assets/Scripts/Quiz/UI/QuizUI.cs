using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz.UI
{
    public class QuizUI : MonoBehaviour
    {
        [SerializeField] List<GameObject> _panels;

        [Header("Question Panel")]
        [SerializeField] TextMeshProUGUI _qQuestionText;
        [SerializeField] TextMeshProUGUI _qProgressText;
        [SerializeField] Image _qImage;
        [SerializeField] List<TextMeshProUGUI> _qAnswers;
        
        [Header("Answer Panel")]
        [SerializeField] TextMeshProUGUI _aQuestionText;
        [SerializeField] TextMeshProUGUI _aProgressText;
        [SerializeField] Image _aImage;
        [SerializeField] TextMeshProUGUI _aAnswerResultText;
        [SerializeField] TextMeshProUGUI _aAnswerText;
        [SerializeField] TextMeshProUGUI _aExplanationText;
        
        [Header("Result Panel")]
        [SerializeField] TextMeshProUGUI _rResultText;
        [SerializeField] TextMeshProUGUI _rRankText;
        [SerializeField] Image _rRankImage;
        [SerializeField] TextMeshProUGUI _rRankExplanationText;

        Player _player;
        Quiz _quiz;
        
        public void Initalize(Player player, Quiz quiz)
        {
            _player = player;
            _quiz = quiz;
        }

        public void ShowQuestion(QuestionSO question)
        {
            EnablePanel(0);

            _qQuestionText.text = question.Question;
            _qProgressText.text = $"{_quiz.CurrentQuestionIndex + 1} / {_quiz.Questions.Count}";
            _qImage.sprite = question.Image;

            for (int i = 0; i < question.Answers.Count; i++)
            {
                _qAnswers[i].text = question.Answers[i];
                
                if (!_qAnswers[i].transform.parent.gameObject.activeSelf)
                    _qAnswers[i].transform.parent.gameObject.SetActive(true);
            }
        }
        
        public void ShowAnswer(QuestionSO question)
        {
            EnablePanel(1);
            
            _aQuestionText.text = question.Question;
            _aProgressText.text = $"{_quiz.CurrentQuestionIndex + 1} / {_quiz.Questions.Count}";
            _aImage.sprite = question.Image;
            _aAnswerResultText.text = 
                _quiz.Answers[_quiz.CurrentQuestionIndex] == question.CorrectAnswerIndex
                ? "Bonne réponse"
                : "Mauvaise réponse"
            ;
            _aAnswerText.text = question.Answers[question.CorrectAnswerIndex];
            _aExplanationText.text = question.Explanation;
        }
        
        public void ShowResult()
        {
            EnablePanel(2);
            
            _rResultText.text = $"{_player.Score} bonnes réponses sur {_quiz.Questions.Count}";
            _rRankText.text = _player.Rank.ToString();
            //_rRankImage.sprite = ;
            //_rRankExplanationText.text = ;
        }

        void EnablePanel(int index)
        {
            _panels.ForEach(panel => panel.SetActive(false));
            _panels[index].SetActive(true);
        }

        public void OnAnswer(int answerIndex)
        {
            Events.OnAnswer?.Invoke(answerIndex);
        }
        
        public void OnContinue()
        {
            Events.OnContinue?.Invoke();
        }
        
        public void OnBack()
        {
            Events.OnBack?.Invoke();
        }
    }
}