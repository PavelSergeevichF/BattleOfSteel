using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAuthorizationOrRegistrationView : MonoBehaviour
{
    [SerializeField] private GameObject _registrationPanel;
    [SerializeField] private GameObject _authorizationPanel;
    [SerializeField] private GameObject _closeButtonPanel;
    [SerializeField] private GameObject _authorizationButtonPanel;
    [SerializeField] private Button _registrationButton;
    [SerializeField] private Button _authorizationButton;
    [SerializeField] private Button _closeButton;

    private SelectAuthorizationOrRegistrationController _selectAuthorizationOrRegistrationController;

    public SelectAuthorizationOrRegistrationController SelectAuthorizationOrRegistrationController => _selectAuthorizationOrRegistrationController;

    void Start()
    {
        _selectAuthorizationOrRegistrationController = new SelectAuthorizationOrRegistrationController
            (_registrationPanel, _authorizationPanel, _registrationButton, _authorizationButton, _closeButton, _closeButtonPanel, _authorizationButtonPanel);
    }

}
