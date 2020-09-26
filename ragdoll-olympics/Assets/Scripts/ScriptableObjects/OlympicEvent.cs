using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "event", menuName = "ScriptableObjects/Olympic Event", order = 1)]
public class OlympicEvent : ScriptableObject
{
    public string eventName; // Human friendly name
    public GameObject playerPrefab; // Player prefab spawned at starting location
    public string eventUiScene;
    public List<string> eventMaps; // Names of scenes containing maps
}
