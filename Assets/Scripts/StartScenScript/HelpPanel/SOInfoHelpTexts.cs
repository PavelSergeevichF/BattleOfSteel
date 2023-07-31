using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOInfoHelpTexts", menuName = "InfoHelp/SOInfoHelpTexts", order = 1)]
public class SOInfoHelpTexts : ScriptableObject
{
    [Header("MenuHelp")]
    public List<string> MenuHelp = new List<string>();

    [Header("AmmunitionHelp")]
    public SOInfoHelpAmmunitionText AmmunitionHelp;

    [Header("HangarHelp")]
    public List<string> HangarHelp = new List<string>();

    [Header("DevelopmentHelp")]
    public List<string> DevelopmentHelp = new List<string>();
}
