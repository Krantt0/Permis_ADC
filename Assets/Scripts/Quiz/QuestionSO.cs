using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    [CreateAssetMenu(menuName = "Scriptable Objects/QuestionSO")]
    public class QuestionSO : ScriptableObject
    {
        [field: SerializeField]
        public Sprite Image { get; set; }

        [field: SerializeField]
        public string Question { get; set; }

        [field: SerializeField]
        public List<string> Answers { get; set; }

        [field: SerializeField]
        public int CorrectAnswerIndex { get; set; }

        [field: SerializeField]
        public string Explanation { get; set; }
    }
}