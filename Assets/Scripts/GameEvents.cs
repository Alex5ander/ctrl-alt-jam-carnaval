using System.Collections.Generic;
using UnityEngine;


public interface IGameOverListener
{
    public void OnEmit(bool win);
}

public interface IItemListener
{
    public void OnEmit(Sprite sprite);
}

public interface IHintListener
{
    public void OnEmit(string hint);
}

[CreateAssetMenu]

public class GameEvents : ScriptableObject
{
    public List<IGameOverListener> gameOverListeners = new();
    public List<IItemListener> itemListeners = new();
    public List<PoliceOfficer> policeOfficers = new();
    public List<IHintListener> hintListeners = new();

    public void GameOver(bool win = false)
    {
        foreach (IGameOverListener listener in gameOverListeners)
        {
            listener.OnEmit(win);
        }
    }

    public void SetItemSprite(Sprite sprite)
    {
        foreach (IItemListener listener in itemListeners)
        {
            listener.OnEmit(sprite);
        }
    }

    public void CallPolice(Vector3 position)
    {
        PoliceOfficer nearPoliceOfficer = policeOfficers[0];
        foreach (PoliceOfficer policeOfficer in policeOfficers)
        {
            float d1 = Mathf.Abs(Vector3.Distance(nearPoliceOfficer.transform.position, position));
            float d2 = Mathf.Abs(Vector3.Distance(policeOfficer.transform.position, position));
            if (d1 > d2)
            {
                nearPoliceOfficer = policeOfficer;
            }
        }
        nearPoliceOfficer.Call();
    }

    public void SetHint(string hint)
    {
        foreach (IHintListener hintListener in hintListeners)
        {
            hintListener.OnEmit(hint);
        }
    }
}
