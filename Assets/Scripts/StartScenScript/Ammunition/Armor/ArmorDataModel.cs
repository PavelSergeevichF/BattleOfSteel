using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ArmorDataModel
{
    public string NameBotFofCheck;

    public ArmorPart ArmorTower;
    public ArmorPart ArmorBody;
    public int ArmorMass;
    public eTypeArmor ETypeArmor;

    public ArmorDataModel(eTypeArmor eTypeArmor, int mass, string nane, ArmorPart armorTower, ArmorPart armorBody)
    {
        ArmorTower = armorTower;
        ArmorBody = armorBody;
        ETypeArmor = eTypeArmor;
        ArmorMass = mass;
        NameBotFofCheck = nane;
    }
    public void SetArmorDataModel(ArmorDataModel armorDataModel)
    {
        this = armorDataModel;
    }
}
