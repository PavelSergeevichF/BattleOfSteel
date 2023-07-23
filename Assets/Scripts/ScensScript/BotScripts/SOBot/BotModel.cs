using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(BotModel), menuName = "SOGame/" + nameof(BotModel), order = 0)]
public class BotModel : ScriptableObject
{
#if UNITY_EDITOR
    [ContextMenu("Save")]
    public void Save()
    {
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
#endif
    [Header("MineData")]
    public string NameBot="__";
    public float MassBotFinish;
    public MassBot MassBotPart = new MassBot();
    public string MassPrototype;
    public SizeBot SizeBot=new SizeBot(1,1,1,1,1,1,1);
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
    public ETypeBot TypeBot;

    [Header("ArmorData")]
    public ArmorDataModel ArmorModel= new ArmorDataModel
        (eTypeArmor.Easy, 0, "-", 
        new ArmorPart(new Dictionary<ePlanName, PlanSurface>()), 
        new ArmorPart(new Dictionary<ePlanName, PlanSurface>()));

    [Header("WeaponData")]
    public GunModel GunModel= new GunModel();

    [Header("AmmunitionData")]
    public int ShellNum = 10;
    public int BulletNum = 100;

    [Header("OtherData")]
    public Transform TransformTarget;
    public GameObject BotGameObject;
    public Sprite BotLabel;
}
