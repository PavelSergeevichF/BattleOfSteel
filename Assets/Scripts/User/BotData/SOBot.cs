using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SOBot), menuName = "Bot/SOBot", order = 1)]
public class SOBot : ScriptableObject
{
    public List<BotModel> BotsData;
    public int BotActive=0;
}