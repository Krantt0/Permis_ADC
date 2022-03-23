using Core;
using TMPro;
using UnityEngine;

namespace MainMenu.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _rankText;
        
        Player _player;
        
        void Awake()
        {
            _player = FindObjectOfType<Player>();
        }

        void Start()
        {
            _rankText.text = _player.Rank.ToString();
        }

        public void OnStart()
        {
            Events.OnLoadQuiz?.Invoke();
        }
    }
}