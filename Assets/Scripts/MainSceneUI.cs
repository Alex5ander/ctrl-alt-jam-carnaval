using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    static public void LoadGameScene() => SceneManager.LoadScene(1);
    static public void Exit() => Application.Quit();
}
