using PlayFab;
using PlayFab.ClientModels;
using System.Linq;
using UnityEngine;

public class RegistrationController : MonoBehaviour
{
    private string _userName;
    private string _userEmail;
    private string _userPassword;
    private string _userCheckPassword;
    [SerializeField] private SelectAuthorizationOrRegistrationView _selectAuthorizationOrRegistrationView;

    private void Awake()
    {
        _selectAuthorizationOrRegistrationView.UserNameField.onValueChanged.AddListener(SetUserName);
        _selectAuthorizationOrRegistrationView.UserPasswordField.onValueChanged.AddListener(SetUserPassword);
        _selectAuthorizationOrRegistrationView.UserCheckPasswordField.onValueChanged.AddListener(SetCheckPassword);
        _selectAuthorizationOrRegistrationView.UserEmailField.onValueChanged.AddListener(SetUserEmale);
        _selectAuthorizationOrRegistrationView.RegistrationOrAuthorizationButton.onClick.AddListener(OnClickButtonRegistrationOrAuthorization);
        _selectAuthorizationOrRegistrationView.ErrorText.text = "";
        _selectAuthorizationOrRegistrationView.InfoText.text = "";
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
    private void SetCheckPassword(string value)
    {
        _userCheckPassword = value;
    }
    private void OnClickButtonRegistrationOrAuthorization()
    {
        _selectAuthorizationOrRegistrationView.ErrorText.text = "Отправка данных, ожедайте.";
        if (!_selectAuthorizationOrRegistrationView.Authorization  && CheckPassvord() && CheckEmail())
        {
            SubmitRegistration();
        }
    }
    private void SubmitRegistration()
    {
        _selectAuthorizationOrRegistrationView.ErrorText.text = "";
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = _userName,
            Email = _userEmail,
            Password = _userPassword,
            RequireBothUsernameAndEmail = true
        }, result =>
        {
            _selectAuthorizationOrRegistrationView.ErrorText.text = "";
            _selectAuthorizationOrRegistrationView.SOUserData.UserName = _userName;
            _selectAuthorizationOrRegistrationView.SOUserData.UserPassword = _userPassword;
            _selectAuthorizationOrRegistrationView.ErrorText.text = $"User registrated: {result.Username}";
            _selectAuthorizationOrRegistrationView.SOUserData.Authorization = true;
            Debug.Log($"User registrated: {result.Username}");
            _selectAuthorizationOrRegistrationView.UpdateUserData();
            _selectAuthorizationOrRegistrationView.ClosePanel();
        }, error =>
        {
            _selectAuthorizationOrRegistrationView.ErrorText.text = error.ErrorMessage;
            _selectAuthorizationOrRegistrationView.SOUserData.Authorization = false;
            Debug.LogError(error);
        }
        );
    }
    private bool CheckEmail()
    {
        bool checkOnA = false;
        bool checkOnPoint = false;
        foreach(var ch in _userEmail)
        { 
            if(ch=='@') checkOnA=true;
            if (ch == '.') checkOnPoint = true;
        }
        if (!checkOnA||!checkOnPoint)
        {
            _selectAuthorizationOrRegistrationView.ErrorText.text = "Incorrect Email (Ошибка в адресе)";
        }
        return checkOnA && checkOnPoint;
    }

    private bool CheckPassvord()
    {
        bool check = false;
        if (_userPassword == _userCheckPassword)
        {
            check = true;
        }
        else
        {
            _selectAuthorizationOrRegistrationView.ErrorText.text = "Incorrect check passvord (пароли не совпадают)";
        }
        return check;
    }
}