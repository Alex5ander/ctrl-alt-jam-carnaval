
using UnityEngine;
using UnityEngine.UI;

public class DPad : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image ImageUI;
    [SerializeField] GameEvents gameEvents;
    readonly Vector2[] directions = {
        Vector2.zero,
        Vector2.up,
        Vector2.right,
        Vector2.down,
        Vector2.left
    };
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(MainSceneUI.isMobile);
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.position = new Vector2(Screen.safeArea.min.x + rectTransform.sizeDelta.x / 2, Screen.safeArea.min.y + rectTransform.sizeDelta.y / 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTouchStart(int id)
    {
        ImageUI.sprite = sprites[id];
        gameEvents.OnTouchChange(directions[id]);
    }

    public void OnTouchEnd()
    {
        ImageUI.sprite = sprites[0];
        gameEvents.OnTouchChange(directions[0]);
    }
}
