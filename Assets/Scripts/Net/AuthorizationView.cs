using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationView : MonoBehaviour
{
    [SerializeField] private InputField _userNameField;
    [SerializeField] private InputField _userPasswordField;
    [SerializeField] private Button _authorizatioButton;
    [SerializeField] private Image _image;
    [SerializeField] private Text _errorText;
    [SerializeField] private Text _infoText;
    [SerializeField] private SelectAuthorizationOrRegistrationView _selectAuthorizationOrRegistrationView;

    private string _userName;
    private string _userPassword;

    private void Awake()
    {
        _userNameField.onValueChanged.AddListener(SetUserName);
        _userPasswordField.onValueChanged.AddListener(SetUserPassword);
        _authorizatioButton.onClick.AddListener(Submit);
        _image.color = Color.gray;
    }
    private void SetUserName(string value)
    {
        _userName = value;
    }
    private void SetUserPassword(string value)
    {
        _userPassword = value;
    }
    private void Submit()
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
            _image.color = Color.green;
        }, error =>
        {
            _errorText.gameObject.SetActive(true);
            _errorText.text = error.ErrorDetails.FirstOrDefault().Value.FirstOrDefault() ?? "" ;
            Debug.LogError(error);
            _image.color = Color.red;
        }
        );
    }
}
