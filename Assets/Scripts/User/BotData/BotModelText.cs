using System.Collections.Generic;
using UnityEngine;

public class BotModelText 
{
    public bool IsActive;

    [Header("BotText")]
    public ETypeBot eTypeBot;
    public float Mass;
    public float Power;
    public float Speed;

    [Header("MachinGunText")]
    public bool IsSetMachinGun;
    public float CaliberMachinGun;
    public float LongMachinGun;
    public int TempMachinGun;

    [Header("BulletsText")]
    public Dictionary<EBulletType,int> Bullets;
    public int[] OrderBullets = new int[7];

    [Header("GunText")]
    public bool IsSetGun;
    public float CaliberGun;
    public float LongGun;
    public int TempGun;

    [Header("ShellText")]
    public Dictionary<EShellType, int> Shells;
    public int[] OrderShells = new int[7];

    [Header("ArmorTowerText")] //EPlan
    public Dictionary<EPlan, int> ArmTowerPanel;
    public Dictionary<EPlan, int> ArmBodyPanel;
}
