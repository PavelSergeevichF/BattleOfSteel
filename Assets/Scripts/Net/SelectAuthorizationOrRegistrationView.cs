using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAuthorizationOrRegistrationView : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _authorizOrRegPanel;
    [SerializeField] private GameObject _checkPasswordPanel;
    [SerializeField] private GameObject _emailPanel;

    [Header("Buttons")]
    [SerializeField] private Button _registrationOrAuthorizationButton;
    [SerializeField] private Button _selectButton;

    [Header("InputFields")]
    [SerializeField] private InputField _userNameField;
    [SerializeField] private InputField _userEmailField;
    [SerializeField] private InputField _userPasswordField;
    [SerializeField] private InputField _userCheckPasswordField;

    [Header("Texts")]
    [SerializeField] private Text _errorText;
    [SerializeField] private Text _infoText;
    [SerializeField] private Text _textSelectButton;

    [Header("Image")]
    [SerializeField] private Image _image;

    [Header("ScriptableObject")]
    [SerializeField] private SOUserData _sOUserData; 

    public GameObject AuthorizOrRegPanel => _authorizOrRegPanel;
    public GameObject CheckPasswordPanel => _checkPasswordPanel;
    public GameObject EmailPanel => _emailPanel;

    public Button RegistrationOrAuthorizationButton => _registrationOrAuthorizationButton;
    public Button SelectButton => _selectButton;

    public InputField UserNameField => _userNameField;
    public InputField UserEmailField => _userEmailField;
    public InputField UserPasswordField => _userPasswordField;
    public InputField UserCheckPasswordField => _userCheckPasswordField;

    public Text ErrorText => _errorText;
    public Text InfoText => _infoText;
    public Text TextSelectButton => _textSelectButton;

    public Image Image => _image;

    public SOUserData SOUserData => _sOUserData;

    public delegate void InvokeUpdate();

    public event InvokeUpdate InvokeUpdateUserData;

    public delegate void ClosePanelRegOrAuthor();

    public event ClosePanelRegOrAuthor ClosePanelRegistrOrAuthor;

    public bool Authorization = true;

    public void UpdateUserData()
    {
        InvokeUpdateUserData.Invoke();
    }
    public void ClosePanel()
    {
        ClosePanelRegistrOrAuthor.Invoke();
    }
}
