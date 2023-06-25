using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotationController
{
    private BotModel _sOBotModel;

    public GunRotationController(BotModel sOBotModel)
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
