using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IItemListener
{
    [SerializeField] Image ItemImageUI;
    [SerializeField] GameEvents gameEvents;
    [SerializeField] GameObject TouchIcon;
    // Start is called before the first frame update
    void Start()
    {
        gameEvents.itemListeners.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnEmit(Sprite sprite)
    {
        ItemImageUI.sprite = sprite;
        ItemImageUI.enabled = sprite != null;
        TouchIcon.SetActive(sprite != null);
    }

    void OnDestroy()
    {
        gameEvents.itemListeners.Remove(this);
    }
}
