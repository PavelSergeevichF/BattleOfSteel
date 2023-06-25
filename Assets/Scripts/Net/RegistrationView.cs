using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationView : MonoBehaviour
{
    [SerializeField] private InputField _userNameField;
    [SerializeField] private InputField _userEmailField;
    [SerializeField] private InputField _userPasswordField;
    [SerializeField] private InputField _userCheckPasswordField;
    [SerializeField] private Button _registrationButton;
    [SerializeField] private Button _authorizatioButton;
    [SerializeField] private Image _image;
    [SerializeField] private Text _errorText;
    [SerializeField] private Text _infoText;
    [SerializeField] private SOUserData _sOUserData;
    [SerializeField] private SelectAuthorizationOrRegistrationView _selectAuthorizationOrRegistrationView;

    private string _userName;
    private string _userEmail;
    private string _userPassword;
    private string _trueUserPassword;

    private void Awake()
    {
        _userNameField.onValueChanged.AddListener(SetUserName);
        _userEmailField.onValueChanged.AddListener(SetUserEmale);
        _userPasswordField.onValueChanged.AddListener(SetUserPassword);
        _registrationButton.onClick.AddListener(SubmitRegistration);
        _authorizatioButton.onClick.AddListener(SubmitAuthorization);
        _errorText.text = "";
    }
    private void SetUserName(string value)
    {
        _userName=value;
    }
    private void SetUserEmale(string value)
    {
        _userEmail = value;
    }
    private void SetUserPassword(string value)
    {
        _userPassword=value;
    }
    private void SubmitRegistration()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = _userName,
            Email = _userEmail,
            Password = _userPassword,
            RequireBothUsernameAndEmail = true
        }, result =>
        {
            _errorText.gameObject.SetActive(false);
            _selectAuthorizationOrRegistrationView.SelectAuthorizationOrRegistrationController.CloseButtonPanel.SetActive(true);
            _selectAuthorizationOrRegistrationView.SelectAuthorizationOrRegistrationController.AuthorizationButtonPanel.SetActive(false);
            _sOUserData.UserName = _userName;
            _sOUserData.UserPassword = _userPassword;
            _errorText.text = $"User registrated: {result.Username}";
            Debug.Log($"User registrated: {result.Username}");
        }, error =>
        {
            _errorText.gameObject.SetActive(true);
            _errorText.text = error.ErrorMessage;
            Debug.LogError(error);
        }
        );
    }
    private void SubmitAuthorization()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _userName,
            Password = _userPassword
        }, result =>
        {
            _errorText.gameObject.SetActive(false);
            Debug.Log($"User registrated: {result.LastLoginTime}");
            _infoText.text = $"Enter last time {result.LastLoginTime}";
            _selectAuthorizationOrRegistrationView.SelectAuthorizationOrRegistrationController.ClosePanels();
            //_image.color = Color.green;
            _sOUserData.UserName = _userName;
            _sOUserData.UserPassword = _userPassword;

        }, error =>
        {
            _errorText.gameObject.SetActive(true);
            _errorText.text = error.ErrorDetails.FirstOrDefault().Value.FirstOrDefault() ?? "";
            Debug.LogError(error);
            //_image.color = Color.red;
        }
        );
    }
}