using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEconomyData", menuName = "User/SOEconomyData", order = 1)]
public class SOEconomyData : ScriptableObject
{
    public int Gold;
    public int Silver;
    public int Copper;
}
