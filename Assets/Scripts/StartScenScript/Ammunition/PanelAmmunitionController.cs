using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAmmunitionController : IExecute
{
    public float GlowTime;
    private ActivePanelAmmunition _activePanelAmmunition;

    private PanelAmmunitionView _panelAmmunitionView;

    private GameObject _armorPanel;
    private GameObject _enginePanel;
    private GameObject _gunsPanel;
    private GameObject _equipmentPanel;
    private GameObject _ammunitionPanel;
    private GameObject _infoBotPanel;
    private GameObject _panelMenuAmmunition;

    private SOBotsData _botsData;
    private SOEconomyData _economy;

    private PanelArmorController _panelArmorController;
    private PanelEngineController _panelEngineController;
    private PanelGunsController _panelGunsController;
    private StartScenButtonPanelController _startScenButtonPanelController;
    private CurrencyUserController _currencyUserController;
    private EconomyController _economyController;
    private MassController _massController;
    private InfoHelpPanelController _infoHelpPanelController;

    private List<IAmmunitionController> _iAmmunitionController;

    //private PanelArmorController _panelArmorController;
    private PanelInformController _panelInformController;


    public CurrencyUserController CurrencyUserController => _currencyUserController;
    public EconomyController EconomyController => _economyController;
    public MassController MassController => _massController;
    public PanelAmmunitionView PanelAmmunitionView => _panelAmmunitionView;

    public GameObject ArmorPanel => _armorPanel;
    public GameObject EnginePanel => _enginePanel;
    public GameObject GunsPanel => _gunsPanel;
    public GameObject EquipmentPanel => _equipmentPanel;
    public GameObject AmmunitionPanel => _ammunitionPanel;
    public GameObject InfoBotPanel => _infoBotPanel;
    public InfoHelpPanelController InfoHelpPanelController => _infoHelpPanelController;

    public SOBotsData BotsData => _botsData;
    public SOEconomyData Economy => _economy;

    public ActivePanelAmmunition ActivePanelAmmunition =>_activePanelAmmunition;

    public PanelAmmunitionController(PanelAmmunitionView panelAmmunitionView, SOUserData sOUserData, 
        StartScenButtonPanelController startScenButtonPanelController, CurrencyUserController currencyUserController,
        EconomyController economyController, MassController massController, InfoHelpPanelController infoHelpPanelController)
    {
        _iAmmunitionController = new List<IAmmunitionController>();
        _panelAmmunitionView = panelAmmunitionView;
        _armorPanel          = panelAmmunitionView.ArmorPanel;
        _enginePanel         = panelAmmunitionView.EnginePanel;
        _gunsPanel           = panelAmmunitionView.GunsPanel;
        _equipmentPanel      = panelAmmunitionView.EquipmentPanel;
        _ammunitionPanel     = panelAmmunitionView.AmmunitionPanel;
        _infoBotPanel        = panelAmmunitionView.InfoBotPanel;
        _panelMenuAmmunition = panelAmmunitionView.PanelMenuAmmunition;

        GlowTime = panelAmmunitionView.GlowTime;

        _startScenButtonPanelController = startScenButtonPanelController;
        _currencyUserController = currencyUserController;

        _botsData = sOUserData.BotsData;
        _economy = sOUserData.Economy;
        _economyController = economyController;
        _massController = massController;
        _infoHelpPanelController = infoHelpPanelController;

        _panelArmorController = new PanelArmorController(this);
        _panelEngineController = new PanelEngineController(this);
        _panelGunsController = new PanelGunsController(this);
        _panelInformController = new PanelInformController(_botsData, _panelAmmunitionView.InfoBotPanel.GetComponent<PanelInformView>());
        _iAmmunitionController.Add(_panelArmorController);
        _iAmmunitionController.Add(_panelEngineController);
        _iAmmunitionController.Add(_panelGunsController);

        panelAmmunitionView.Armor     .onClick.AddListener(ArmorPanelActive);
        panelAmmunitionView.Engine    .onClick.AddListener(EnginePanelActive);
        panelAmmunitionView.Guns      .onClick.AddListener(GunsPanelActive);
        panelAmmunitionView.Equipment .onClick.AddListener(EquipmentPanelActive);
        panelAmmunitionView.Ammunition.onClick.AddListener(AmmunitionPanelActive);
        panelAmmunitionView.InfoBot   .onClick.AddListener(InfoBotPanelActive);
        panelAmmunitionView.Back      .onClick.AddListener(ComeBeack);
        panelAmmunitionView.Aply      .onClick.AddListener(IApply);

        startScenButtonPanelController.ClickOnParametrButton += OpenPanel;
        ArmorPanelActive();
        _massController.SetMass();
    }

    public void Execute()
    {
        _panelArmorController.Execute();
        _panelEngineController.Execute();
        _panelGunsController.Execute();
    }
    public void OpenPanel()
    {
        _panelArmorController.SetMaxArmor();
        _panelEngineController.ChenchBot();
        _panelGunsController.ChenchBot();
    }
    private void ComeBeack() =>_panelMenuAmmunition.SetActive(false);

    private void ArmorPanelActive() 
    {
        ClearPanel();
        _panelArmorController.SetMaxArmor();
        _armorPanel.SetActive(true);
        _iAmmunitionController?.ForEach(x => x.SetTypePanel(ActivePanelAmmunition.Armor));
    }

    private void EnginePanelActive() 
    { 
        ClearPanel(); 
        _enginePanel.SetActive(true);
        _iAmmunitionController?.ForEach(x => x.SetTypePanel(ActivePanelAmmunition.Engine));
        _panelEngineController.ChenchBot();
    }

    private void GunsPanelActive() 
    { 
        ClearPanel();
        _iAmmunitionController?.ForEach(x => x.SetTypePanel(ActivePanelAmmunition.Gans));
        _gunsPanel.SetActive(true);

    }

    private void EquipmentPanelActive() 
    { 
        ClearPanel(); 
        _equipmentPanel.SetActive(true);
    }

    private void AmmunitionPanelActive() 
    { 
        ClearPanel(); 
        _ammunitionPanel.SetActive(true);
    }

    private void InfoBotPanelActive() 
    {  
        ClearPanel();
        _panelInformController.UpdateInform();
        _infoBotPanel.SetActive(true);
    }

    private void IApply()
    {
    }
    private void ClearPanel()
    {
        _armorPanel     .SetActive(false);
        _enginePanel    .SetActive(false);
        _gunsPanel      .SetActive(false);
        _equipmentPanel .SetActive(false);
        _ammunitionPanel.SetActive(false);
        _infoBotPanel   .SetActive(false);
    }
}

public enum ActivePanelAmmunition
{ 
    Armor,
    Engine,
    Gans,
    Equipment,
    Ammunition,
    Inform
}
