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

        [SerializeField] TextMeshProUGUI _questionText;
        [SerializeField] TextMeshProUGUI _progressText;
        [SerializeField] Image _image;
        [SerializeField] List<TextMeshProUGUI> _answers;

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

            _questionText.text = question.Question;
            _progressText.text = $"{1} / {40}";
            _image.sprite = question.Image;

            for (int i = 0; i < question.Answers.Count; i++)
            {
                _answers[i].text = question.Answers[i];
                
                if (!_answers[i].transform.parent.gameObject.activeSelf)
                    _answers[i].transform.parent.gameObject.SetActive(true);
            }
        }
        
        public void ShowAnswer(QuestionSO question)
        {
            EnablePanel(1);
        }
        
        public void ShowResult()
        {
            EnablePanel(2);
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
    }
}