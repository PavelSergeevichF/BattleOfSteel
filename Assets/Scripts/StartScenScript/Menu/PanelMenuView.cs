using UnityEngine.UI;
using UnityEngine;

public class PanelMenuView : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _account;
    [SerializeField] private Button _shop;
    [SerializeField] private Button _legion;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _events;
    [SerializeField] private Button _back;
    [SerializeField] private Button _exit;

    [Header("Panels")]
    [SerializeField] private GameObject _accountPanel;
    [SerializeField] private GameObject _storePanel;
    [SerializeField] private GameObject _legionPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _eventPanel;
    [SerializeField] private GameObject _exitPanel;

    public Button Account => _account;
    public Button Shop => _shop;
    public Button Legion => _legion;
    public Button Settings => _settings;
    public Button Events => _events;
    public Button Back => _back;
    public Button Exit => _exit;

    public GameObject AccountPanel => _accountPanel;
    public GameObject StorePanel => _storePanel;
    public GameObject LegionPanel => _legionPanel;
    public GameObject SettingsPanel => _settingsPanel;
    public GameObject EventPanel => _eventPanel;
    public GameObject ExitPanel => _exitPanel;
}
