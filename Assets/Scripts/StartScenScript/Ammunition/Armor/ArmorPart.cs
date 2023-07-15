using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPart 
{
    public PlanSurface[] PlanSurfaces = new PlanSurface[6]; 
}

public struct PlanSurface
{
    public PlanName PlanName;
    public int MM;
}

public enum PlanName
{
    Top,
    Bottom,
    Front,
    Back,
    Left,
    Right
}
