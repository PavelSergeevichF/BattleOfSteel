using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPart 
{
    public PlanSurface[] PlanSurfaces = new PlanSurface[6]; 
}

public struct PlanSurface
{
    public ePlanName PlanName;
    public int MM;
    public CurrencyModel Cost;
}

public enum ePlanName
{
    Top,
    Bottom,
    Front,
    Back,
    Flank
}
