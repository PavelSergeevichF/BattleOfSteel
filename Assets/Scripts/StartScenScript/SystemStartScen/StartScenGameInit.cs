using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

internal sealed class StartScenGameInit
{
    public StartScenGameInit(StartScenControllers controllers, StartScenGameControllerView mainController)
    {
        StartScenButtonPanelController _startScenButtonPanelController = new StartScenButtonPanelController(mainController.MainButtonPanelView);
        controllers.Add(_startScenButtonPanelController);

        SelectAuthorizationOrRegistrationController _selectAuthorizationOrRegistrationController = new SelectAuthorizationOrRegistrationController(mainController.SelectAuthorizationOrRegistrationView);
        controllers.Add(_selectAuthorizationOrRegistrationController);

        PanelAmmunitionController _panelAmmunitionController = new PanelAmmunitionController(mainController.PanelAmmunitionView);
        controllers.Add(_panelAmmunitionController);

        PanelHangarController _panelHangarController = new PanelHangarController(mainController.PanelHangarView);
        controllers.Add(_panelHangarController);

        mainController.SelectAuthorizationOrRegistrationView.AuthorizOrRegPanel.SetActive(!mainController.SOUserData.Authorization);
    }

}
