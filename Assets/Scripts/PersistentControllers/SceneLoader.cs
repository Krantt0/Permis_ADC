using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PersistentControllers
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] int _mainMenuScene;
        [SerializeField] int _quizzScene;

        bool _isLoading;

        void OnEnable()
        {
            Events.OnLoadMainMenu += LoadMainMenu;
            Events.OnLoadQuiz += LoadQuizz;
        }

        void OnDisable()
        {
            Events.OnLoadMainMenu -= LoadMainMenu;
            Events.OnLoadQuiz -= LoadQuizz;
        }

        void LoadMainMenu()
        {
            if (_isLoading)
                return;
            
            UnloadPreviousScenes();
            LoadNewScene(_mainMenuScene);
        }

        void LoadQuizz()
        {
            if (_isLoading)
                return;

            UnloadPreviousScenes();
            LoadNewScene(_quizzScene);
        }

        void UnloadPreviousScenes()
        {
            // Unload all scenes except the PersistentControllers scene
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                
                if (scene.buildIndex != 1)
                    SceneManager.UnloadSceneAsync(scene);
            }
        }

        void LoadNewScene(int sceneIndex)
        {
            _isLoading = true;
            
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

            asyncOperation.completed += op =>
            {
                _isLoading = false;
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
            };
        }
    }
}