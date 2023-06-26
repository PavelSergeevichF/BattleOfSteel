using UnityEngine;
using UnityEngine.UI;

public class MenuAccountView : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _exitAccount;
    [SerializeField] private Button _showInfo;
    [SerializeField] private Button _closeInfo;
    [SerializeField] private Button _back;

    [Header("Texts")]
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _victoriesPercentagesText;
    [SerializeField] private Text _battlesText;
    [SerializeField] private Text _skillPercentagesText;
    [SerializeField] private Text _awardsText;

    [Header("Panels")]
    [SerializeField] private GameObject _panelInfo;
    [SerializeField] private GameObject _panelAccount;

    [Header("Image")]
    [SerializeField] private Image _image;

    public Button ExitAccount =>_exitAccount;
    public Button ShowInfo => _showInfo;
    public Button CloseInfo => _closeInfo;
    public Button Back => _back;

    public Text NameText => _nameText;
    public Text VictoriesPercentagesText => _victoriesPercentagesText;
    public Text BattlesText => _battlesText;
    public Text SkillPercentagesText => _skillPercentagesText;
    public Text AwardsText => _awardsText;

    public GameObject PanelInfo => _panelInfo;
    public GameObject PanelAccount => _panelAccount;

    public Image Image => _image;
}
