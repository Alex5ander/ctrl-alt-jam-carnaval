using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    public Vector3 position;
    public bool hidden;
    public Mission mission;
    public List<Mission> missionsCompleted = new();

    public void Reset()
    {
        hidden = false;
        mission = null;
        missionsCompleted = new();
    }
}
