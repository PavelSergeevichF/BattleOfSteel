using UnityEngine;

[CreateAssetMenu(fileName = nameof(BotModel), menuName = "SOGame/" + nameof(BotModel), order = 0)]
public class BotModel : ScriptableObject
{
    [Header("MineData")]
    public string NameBot="__";
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

    [Header("WeaponData")]
    public bool Gun = false;
    public float CaliberGun = 20;
    public int LongGun = 200;

    public bool MachineGun = false;
    public float CaliberMachineGun = 5;
    public int LongMachineGun = 100;

    [Header("AmmunitionData")]
    public int ShellNum = 10;
    public int BulletNum = 100;

    [Header("OtherData")]
    public Transform TransformTarget;
    public GameObject BotGameObject;
    public Sprite BotLabel;
}
