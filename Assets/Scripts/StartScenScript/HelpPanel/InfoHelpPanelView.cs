using UnityEngine.UI;
using UnityEngine;

public class InfoHelpPanelView : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _closePanel;

    [Header("Panels")]
    [SerializeField] private GameObject _infoHelpPane;

    [Header("Text")]
    public Text HeadText;
    public Text BodyText;

    [SerializeField] private SOInfoHelpTexts _sOInfoHelpTexts;


    public Button ClosePanel => _closePanel;

    public GameObject InfoHelpPane => _infoHelpPane;
    public SOInfoHelpTexts SOInfoHelpTexts => _sOInfoHelpTexts;

}
