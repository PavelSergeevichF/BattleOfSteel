using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class RotationPositionOnGroundController 
{
    private BotView _botView;
    private BotMoveController _botMoveController;
    private float _distF, _distB, _distL, _distR;
    private const float _inaccuracy = 0.02f;
    private const float _kooficentRotate = 0.03f;

    public RotationPositionOnGroundController(BotView botView, BotMoveController botMoveController)
    {
        _botView = botView;
        _botMoveController = botMoveController;
    }
    public void Update()
    {
        SetRotate();
    }
    
    private void SetRotate()
    {
        GetDistanes();
        Vector3 rotate = new Vector3(SetDirRotate(_distF, _distB), 0, SetDirRotate(_distL, _distR));
        _botMoveController.SetDirRotate(rotate);
    }
    private void GetDistanes()
    {
        float distLF = GetDistance(_botView.StartPointLF, _botView.TargetPointLF, Color.green),
              distRF = GetDistance(_botView.StartPointRF, _botView.TargetPointRF, Color.yellow),
              distLB = GetDistance(_botView.StartPointLB, _botView.TargetPointLB, Color.white), 
              distRB = GetDistance(_botView.StartPointRB, _botView.TargetPointRB, Color.cyan);

        _distF = AverageValue(distLF, distRF);
        _distB = AverageValue(distLB, distRB);
        _distL = AverageValue(distLF, distLB);
        _distR = AverageValue(distRF, distRB);

    }
    private float GetDistance(Transform transformStart, Transform transformTarget, Color color)
    {
        RaycastHit[] hits;
        float dist = 0;
        Vector3 direction = transformTarget.position - transformStart.position;
        hits = Physics.RaycastAll(transformStart.position, direction);
        Debug.DrawRay(transformStart.position, direction, color);
        foreach(var hit in hits)
        {
            if (hit.collider.gameObject.layer == 6)
                dist = hit.distance;
        }
        return dist;
    }
    private float SetDirRotate(float diatA, float distB)
    {
        if (diatA > distB + _inaccuracy) return _kooficentRotate*(diatA- distB);
        else
            if(diatA < distB - _inaccuracy) return -_kooficentRotate*(distB- diatA);
        else return 0;
    }
    private float AverageValue(float diatA, float distB)
    {
        return (diatA + distB)/2;
    }
}
