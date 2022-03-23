using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialization : MonoBehaviour
{
    [SerializeField] int _persistentControllersScene;

    void Start()
    {
        SceneManager.LoadSceneAsync(_persistentControllersScene, LoadSceneMode.Additive).completed += InvokeLoadMainMenuEvent;
    }

    static void InvokeLoadMainMenuEvent(AsyncOperation obj)
    {
        Events.OnLoadMainMenu?.Invoke();
        SceneManager.UnloadSceneAsync(0);
    }
}