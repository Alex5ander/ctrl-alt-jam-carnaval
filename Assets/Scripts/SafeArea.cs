using UnityEngine;

public class SafeArea : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        float xMin = Screen.safeArea.xMin;
        float xMax = Screen.width - Screen.safeArea.xMax;
        float yMin = Screen.safeArea.yMin;
        float yMax = Screen.height - Screen.safeArea.yMax;
        rectTransform.offsetMin = new(xMin / 2, yMin / 2);
        rectTransform.offsetMax = new(-xMax / 2, -yMax / 2);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
