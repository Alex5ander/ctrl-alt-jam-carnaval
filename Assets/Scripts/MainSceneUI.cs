using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
#if !UNITY_EDITOR && UNITY_WEBGL
    [DllImport("__Internal")]
    static extern bool IsMobile();
#endif
    public static bool isMobile;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
#if !UNITY_EDITOR && UNITY_WEBGL
        isMobile = IsMobile();
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }
    static public void LoadGameScene() => SceneManager.LoadScene(1);
    static public void Exit() => Application.Quit();
}
