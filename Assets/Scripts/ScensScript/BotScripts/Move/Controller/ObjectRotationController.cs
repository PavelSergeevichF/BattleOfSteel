using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationController
{
    private SOCameraConnect _sOCameraConnect;
    private BotModel _sOBotModel;
    private GameObject _targetGameObject;

    public ObjectRotationController(SOCameraConnect sOCameraConnect, BotModel sOBotModel, GameObject targetGameObject)
    {
        _sOCameraConnect = sOCameraConnect;
        _sOBotModel = sOBotModel;
        _targetGameObject = targetGameObject;
    }

    public void Update()
    {
        GetRotate();
    }
    private void GetRotate()
    { 
        //настроить ореинтирование вращения по цели
    }
}
