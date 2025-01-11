using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour, ISceneController
{
    public void LoadScene(string sceneName)
    {
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == sceneName)
            {
                SceneManager.sceneLoaded -= (scene, mode) => EventManager.OnSceneLoaded(sceneName);
                EventManager.OnSceneLoaded(sceneName);
            }
        };

        SceneManager.LoadScene(sceneName);
    }
}
