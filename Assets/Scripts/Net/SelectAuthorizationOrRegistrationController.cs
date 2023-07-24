
public class SelectAuthorizationOrRegistrationController : IInitialization
{
    private SelectAuthorizationOrRegistrationView _selectAuthorizationOrRegistrationView;


    public SelectAuthorizationOrRegistrationController(SelectAuthorizationOrRegistrationView selectAuthorizationOrRegistrationView)
    {
        _selectAuthorizationOrRegistrationView = selectAuthorizationOrRegistrationView;
        if (_selectAuthorizationOrRegistrationView.Authorization)
        {
            SelectOnAuth();
        }
        else 
        {
            SelectOnReg();
        }
        selectAuthorizationOrRegistrationView.ClosePanelRegistrOrAuthor += ClosePanels;
        _selectAuthorizationOrRegistrationView.SelectButton.onClick.AddListener(SelectRegOrAuth);
    }

    public void Init()
    {
    }

    private void SelectRegOrAuth()
    {
        if (_selectAuthorizationOrRegistrationView.Authorization)
        {
            _selectAuthorizationOrRegistrationView.Authorization = false;
            SelectOnReg();
        }
        else 
        {
            _selectAuthorizationOrRegistrationView.Authorization = true;
            SelectOnAuth();

        }
    }
    private void SelectOnReg()
    {
        _selectAuthorizationOrRegistrationView.CheckPasswordPanel.SetActive(true);
        _selectAuthorizationOrRegistrationView.EmailPanel.SetActive(true);
        _selectAuthorizationOrRegistrationView.TextSelectButton.text = "Авторизация";
    }
    private void SelectOnAuth()
    {
        _selectAuthorizationOrRegistrationView.CheckPasswordPanel.SetActive(false);
        _selectAuthorizationOrRegistrationView.EmailPanel.SetActive(false);
        _selectAuthorizationOrRegistrationView.TextSelectButton.text = "Регистрация";
    }
    public void ClosePanels()
    {
        if (_selectAuthorizationOrRegistrationView.SOUserData.Authorization)
        {
            _selectAuthorizationOrRegistrationView.AuthorizOrRegPanel.SetActive(false);
        }
        else 
        {
            _selectAuthorizationOrRegistrationView.ErrorText.text = "Вход или регистрация обязательны";
        }
    }
}
