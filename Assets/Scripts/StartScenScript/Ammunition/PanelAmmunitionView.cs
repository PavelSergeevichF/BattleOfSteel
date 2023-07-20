using UnityEngine.UI;
using UnityEngine;

public class PanelAmmunitionView : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _armor;
    [SerializeField] private Button _engine;
    [SerializeField] private Button _guns;
    [SerializeField] private Button _equipment;
    [SerializeField] private Button _ammunition;
    [SerializeField] private Button _infoBot;
    [SerializeField] private Button _back;
    [SerializeField] private Button _aply;

    [Header("Panels")]
    [SerializeField] private GameObject _armorPanel;
    [SerializeField] private GameObject _enginePanel;
    [SerializeField] private GameObject _gunsPanel;
    [SerializeField] private GameObject _equipmentPanel;
    [SerializeField] private GameObject _ammunitionPanel;
    [SerializeField] private GameObject _infoBotPanel;
    [SerializeField] private GameObject _panelMenuAmmunition;

    [Header("Text")]
    public float GlowTime = 2f;

    [Header("SO")]
    [SerializeField] private SOBotsData _sOBotsData;

    public Button Armor => _armor;
    public Button Engine => _engine;
    public Button Guns => _guns;
    public Button Equipment => _equipment;
    public Button Ammunition => _ammunition;
    public Button InfoBot => _infoBot;
    public Button Back => _back;
    public Button Aply => _aply;

    public GameObject ArmorPanel       => _armorPanel;
    public GameObject EnginePanel     => _enginePanel;
    public GameObject GunsPanel       => _gunsPanel;
    public GameObject EquipmentPanel  => _equipmentPanel;
    public GameObject AmmunitionPanel => _ammunitionPanel;
    public GameObject InfoBotPanel    => _infoBotPanel;
    public GameObject PanelMenuAmmunition => _panelMenuAmmunition;

    public SOBotsData SOBotsData => _sOBotsData;
}
