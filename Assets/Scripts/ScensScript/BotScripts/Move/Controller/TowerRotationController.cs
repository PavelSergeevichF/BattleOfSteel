using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotationController
{
    private BotModel _sOBotModel;

    public TowerRotationController(BotModel sOBotModel)
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
