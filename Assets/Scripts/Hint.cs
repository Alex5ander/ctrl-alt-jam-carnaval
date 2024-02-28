using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour, IHintListener
{
    [SerializeField] Image HintImageUI;
    [SerializeField] TextMeshProUGUI HintTextUI;
    [SerializeField] GameEvents gameEvents;

    // Start is called before the first frame update
    void Start()
    {
        gameEvents.hintListeners.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEmit(string hint)
    {
        HintImageUI.enabled = hint.Length != 0;
        HintTextUI.SetText(hint);
    }

    void OnDestroy()
    {
        gameEvents.hintListeners.Remove(this);
    }
}
