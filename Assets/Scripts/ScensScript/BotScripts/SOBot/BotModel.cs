using UnityEngine;

[CreateAssetMenu(fileName = nameof(BotModel), menuName = "SOGame/" + nameof(BotModel), order = 0)]
public class BotModel : ScriptableObject
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
    public bool Tracks = false;
    public Transform TransformTarget;
    public SOBotShellModel Ammunition;
    public SOBotGunModel GunsModel;
}
