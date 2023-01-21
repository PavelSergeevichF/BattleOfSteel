using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAuthorizationOrRegistrationController
{
    private GameObject _registrationPanel;
    private GameObject _authorizationPanel;
    private GameObject _closeButtonPanel;
    private GameObject _authorizationButtonPanel;
    private Button _registrationButton;
    private Button _authorizationButton;
    private Button _closeButton;

    public GameObject CloseButtonPanel => _closeButtonPanel;
    public GameObject AuthorizationButtonPanel => _authorizationButtonPanel;

    public SelectAuthorizationOrRegistrationController
        (GameObject registrationPanel, GameObject authorizationPanel, Button registrationButton, Button authorizationButton, Button closeButton, GameObject closeButtonPanel, GameObject authorizationButtonPanel)
    {
        _registrationPanel = registrationPanel;
        _authorizationPanel = authorizationPanel;
        _registrationButton = registrationButton;
        _authorizationButton = authorizationButton;
        _closeButton = closeButton;
        _closeButtonPanel = closeButtonPanel;
        _authorizationButtonPanel = authorizationButtonPanel;
        _registrationButton.onClick.AddListener(SelectOnReg);
        _authorizationButton.onClick.AddListener(SelectOnAuth);
        _closeButton.onClick.AddListener(ClosePanels);
        _authorizationButtonPanel.SetActive(true);
    }
    private void SelectOnReg()
    {
        _registrationPanel.SetActive(true);
        _authorizationPanel.SetActive(false);
        _closeButtonPanel.SetActive(false);
        _authorizationButtonPanel.SetActive(true);
    }
    private void SelectOnAuth()
    {
        _registrationPanel.SetActive(false);
        _authorizationPanel.SetActive(true);
        _authorizationButtonPanel.SetActive(true);
    }
    public void ClosePanels()
    {
        _registrationPanel.SetActive(false);
        _authorizationPanel.SetActive(false);
    }

}
