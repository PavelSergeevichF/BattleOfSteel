using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEconomyData", menuName = "User/SOEconomyData", order = 1)]
public class SOEconomyData : ScriptableObject
{
    public CurrencyModel CurrencyModel = new CurrencyModel();
    public float Repair = 0.05f;
}
