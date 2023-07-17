using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ArmorPart 
{
    public Dictionary<ePlanName, PlanSurface> PlanSurfaces;
    [SerializeField] PlanSurface[] _planSurfaceShow;
    public ArmorPart(Dictionary<ePlanName, PlanSurface> planSurface)
    {
        PlanSurfaces = planSurface;
        _planSurfaceShow = new PlanSurface[5];
    }
    public void SetListForShowe()
    {
        if (PlanSurfaces.Count <= _planSurfaceShow.Length)
        {
            for (int i = 0; i < PlanSurfaces.Count; i++)
            {
                ePlanName planName= ePlanName.Top;
                switch (i)
                { 
                    case 0: planName = ePlanName.Top; break;
                    case 1: planName = ePlanName.Bottom; break;
                    case 2: planName = ePlanName.Front; break;
                    case 3: planName = ePlanName.Back; break;
                    case 4: planName = ePlanName.Flank; break;
                }
                int mm = PlanSurfaces[planName].MM;
                int G = PlanSurfaces[planName].Cost.Gold;
                int S = PlanSurfaces[planName].Cost.Silver;
                int C = PlanSurfaces[planName].Cost.Copper;
                CurrencyModel cost = new CurrencyModel();
                cost.SetCurrencyModel(G,S,C);
                _planSurfaceShow[i].PlanName = planName;
                _planSurfaceShow[i].MM = mm;
                _planSurfaceShow[i].Cost = cost;
            }
        }

    }
}

[Serializable]
public struct PlanSurface
{
    public ePlanName PlanName;
    public int MM;
    public CurrencyModel Cost;
    public PlanSurface(ePlanName planName, int mm, CurrencyModel cost)
    {
        PlanName = planName;
        MM = mm;
        Cost = cost;
    }
    public void SetMM(int mm)
    {
        int Mm = mm;
        MM = Mm;
    }
    public void SetCost(CurrencyModel cost)
    {
        int Gold = cost.Gold;
        int Silver = cost.Silver;
        int Copper = cost.Copper;
        Cost.Gold = Gold;
        Cost.Silver = Silver;
        Cost.Copper = Copper;
    }
}

public enum ePlanName
{
    Top,
    Bottom,
    Front,
    Back,
    Flank
}
