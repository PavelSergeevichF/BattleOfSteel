using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotationController
{
    private SOBotModel _sOBotModel;

    public GunRotationController(SOBotModel sOBotModel)
    {
        _sOBotModel = sOBotModel;
    }
    public void Update()
    {
        SetRotate();
    }
    private void SetRotate()
    { 
        //настроить вращение со временем по модели объекта
    }
}
