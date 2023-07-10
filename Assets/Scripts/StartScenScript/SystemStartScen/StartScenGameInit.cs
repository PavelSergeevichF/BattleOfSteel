using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

internal sealed class StartScenGameInit
{
    public StartScenGameInit(StartScenControllers controllers, StartScenGameControllerView mainController)
    {
        LicenseController _licenseController = new LicenseController(mainController.LicenseView);
        controllers.Add(_licenseController);

        StartScenButtonPanelController _startScenButtonPanelController = new StartScenButtonPanelController(mainController.MainButtonPanelView);
        controllers.Add(_startScenButtonPanelController);

        SelectAuthorizationOrRegistrationController _selectAuthorizationOrRegistrationController = new SelectAuthorizationOrRegistrationController(mainController.SelectAuthorizationOrRegistrationView);
        controllers.Add(_selectAuthorizationOrRegistrationController);

        PanelAmmunitionController _panelAmmunitionController = new PanelAmmunitionController(mainController.PanelAmmunitionView, mainController.SOUserData);
        controllers.Add(_panelAmmunitionController);

        PanelHangarController _panelHangarController = new PanelHangarController(mainController.PanelHangarView, mainController.SOUserData);
        controllers.Add(_panelHangarController);

        PanelMenuController _panelMenuController = new PanelMenuController(mainController.PanelMenuView);
        controllers.Add(_panelMenuController);

        MenuAccountController _menuAccountController = new MenuAccountController(mainController.MenuAccountView, mainController.SOUserData, mainController.SelectAuthorizationOrRegistrationView, _licenseController);
        controllers.Add(_panelMenuController);

        mainController.SelectAuthorizationOrRegistrationView.AuthorizOrRegPanel.SetActive(!mainController.SOUserData.Authorization);

        CurrencyUserController _currencyUserController = new CurrencyUserController(mainController.CurrencyUserView, mainController.SOUserData);
        controllers.Add(_currencyUserController);

        EconomyController _economyController = new EconomyController(mainController.EconomyView, _currencyUserController, mainController.SOUserData, mainController.MainButtonPanelView);
        controllers.Add(_economyController);
    }

}
