using PlayFab;
using PlayFab.ClientModels;
using System.Linq;
using UnityEngine;

public class AuthorizationController : MonoBehaviour
{

    private string _userName;
    private string _userPassword;
    [SerializeField] private SelectAuthorizationOrRegistrationView _selectAuthorizationOrRegistrationView;

    private void Awake()
    {
        _selectAuthorizationOrRegistrationView.UserNameField.onValueChanged.AddListener(SetUserName);
        _selectAuthorizationOrRegistrationView.UserPasswordField.onValueChanged.AddListener(SetUserPassword);
        _selectAuthorizationOrRegistrationView.RegistrationOrAuthorizationButton.onClick.AddListener(OnClickButtonRegistrationOrAuthorization);
        _selectAuthorizationOrRegistrationView.Image.color = Color.gray;
    }

    private void OnClickButtonRegistrationOrAuthorization()
    {
        _selectAuthorizationOrRegistrationView.ErrorText.text = "Отправка данных, ожедайте.";
        if (_selectAuthorizationOrRegistrationView.Authorization)
        {
            SubmitAuthorization();
        }
    }

    private void SetUserName(string value)
    {
        _userName = value;
    }
    private void SetUserPassword(string value)
    {
        _userPassword = value;
    }
    private void SubmitAuthorization()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _userName,
            Password = _userPassword
        }, result =>
        {
            _selectAuthorizationOrRegistrationView.ErrorText.text = "";
            Debug.Log($"User registrated: {result.LastLoginTime}");
            _selectAuthorizationOrRegistrationView.InfoText.text = $"Enter last time {result.LastLoginTime}";
            _selectAuthorizationOrRegistrationView.Image.color = Color.green;
            _selectAuthorizationOrRegistrationView.SOUserData.UserName = _userName;
            _selectAuthorizationOrRegistrationView.SOUserData.UserPassword = _userPassword;
            _selectAuthorizationOrRegistrationView.SOUserData.Authorization = true;
            _selectAuthorizationOrRegistrationView.UpdateUserData();
            _selectAuthorizationOrRegistrationView.ClosePanel();

        }, error =>
        {
            _selectAuthorizationOrRegistrationView.ErrorText.text = "";
            _selectAuthorizationOrRegistrationView.ErrorText.text = error.ErrorDetails.FirstOrDefault().Value.FirstOrDefault() ?? "" ;
            Debug.LogError(error);
            _selectAuthorizationOrRegistrationView.Image.color = Color.red;
            _selectAuthorizationOrRegistrationView.SOUserData.Authorization = false;
        }
        );
    }
}
