using UnityEngine;

[CreateAssetMenu(fileName = nameof(SOBots), menuName = "SOGame/" + nameof(SOBots), order = 0)]
public class SOBots : ScriptableObject
{
    public GameObject[] Bots;

}
