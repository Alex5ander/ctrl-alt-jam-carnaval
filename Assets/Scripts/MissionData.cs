using System;
using UnityEngine;

[CreateAssetMenu]
public class MissionData : ScriptableObject
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsVisible { get; private set; }
    public Action Listener;
    public void Set(string Title, string Description)
    {
        this.Title = Title;
        this.Description = Description;
        Listener.Invoke();
    }

    public void Open()
    {
        IsVisible = true;
        Listener.Invoke();
    }

    public void Close()
    {
        IsVisible = false;
        Listener.Invoke();
    }
}
