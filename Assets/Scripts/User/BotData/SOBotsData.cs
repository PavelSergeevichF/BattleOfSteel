using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOBotsData", menuName = "Bot/SOBotsData", order = 1)]
public class SOBotsData : ScriptableObject
{
    public SOBot LBTBotsData; 
    public SOBot SBTBotsData; 
    public SOBot LTBotsData; 
    public SOBot TTBotsData;

    public SOBot StoreLBTBotsData;
    public SOBot StoreSBTBotsData;
    public SOBot StoreLTBotsData;
    public SOBot StoreTTBotsData;

    public BotModel ActivBot;

    public ETypeBot eTypeBot;
}