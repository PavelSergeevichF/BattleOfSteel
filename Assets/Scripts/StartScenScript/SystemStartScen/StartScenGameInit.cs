using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

internal sealed class StartScenGameInit
{
    public StartScenGameInit(StartScenControllers controllers, StartScenGameControllerView mainController)
    {

        InitSingleton(controllers);

        StartScenButtonPanelController _startScenButtonPanelController = new StartScenButtonPanelController(mainController.MainButtonPanelView);
        controllers.Add(_startScenButtonPanelController);

        PanelAmmunitionController _panelAmmunitionController = new PanelAmmunitionController(mainController.PanelAmmunitionView);
        controllers.Add(_panelAmmunitionController);

        PanelHangarController _panelHangarController = new PanelHangarController(mainController.PanelHangarView);
        controllers.Add(_panelHangarController);

    }

    private void InitSingleton(StartScenControllers controllers)
    {
    }
}
