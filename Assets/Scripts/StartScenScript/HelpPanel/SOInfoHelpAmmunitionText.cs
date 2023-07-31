using UnityEngine;

[CreateAssetMenu(fileName = "SOInfoHelpAmmunitionText", menuName = "InfoHelp/SOInfoHelpAmmunitionText", order = 1)]
public class SOInfoHelpAmmunitionText : ScriptableObject
{
    public SOInfoHelpText ArmorInfo;
    public SOInfoHelpText EngineInfo;
    public SOInfoHelpText GunsInfo;
    public SOInfoHelpText CantInstallTwoInfo;
    public SOInfoHelpText ImpossibleWithoutWeapons;
    public System.Collections.Generic.List<SOInfoHelpText> EquipmentInfo;
    public SOInfoHelpText AmmunitionInfo;
}
