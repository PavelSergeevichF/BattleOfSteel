using UnityEngine;

[CreateAssetMenu(fileName = nameof(SOBotPosition), menuName = "SOGame/" + nameof(SOBotPosition), order = 0)]
public class SOBotPosition : ScriptableObject
{
    public Vector3 BotPosition;
}
