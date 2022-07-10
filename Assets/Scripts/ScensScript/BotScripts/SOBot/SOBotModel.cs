using UnityEngine;

[CreateAssetMenu(fileName = nameof(SOBotModel), menuName = "SOGame/" + nameof(SOBotModel), order = 0)]
public class SOBotModel : ScriptableObject
{
    public float MassBot;
    public int PowerEngine;
    public int IDBot;
    public float MaxSpeedBot;
    public float SpeedBot;
    public float Boost=0.1f;
    public float SpeedRotatTow = 2f;
    public float SpeedRotatGun = 0.1f;
    public int Distance = 500;
    public int HP = 100;
    public int MaxHP = 100;
}
