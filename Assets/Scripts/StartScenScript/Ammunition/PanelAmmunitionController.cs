using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAmmunitionController : IExecute
{
    private PanelAmmunitionView _panelAmmunitionView;

    private GameObject _armorPanel;
    private GameObject _enginePanel;
    private GameObject _gunsPanel;
    private GameObject _equipmentPanel;
    private GameObject _ammunitionPanel;
    private GameObject _infoBotPanel;
    private GameObject _panelMenuAmmunition;

    private SOBotsData _botsData;

    private PanelArmorController _panelArmorController;
    private PanelEngineController _panelEngineController;
    private PanelGunsController _panelGunsController;
    //private PanelArmorController _panelArmorController;
    //private PanelArmorController _panelArmorController;
    //private PanelArmorController _panelArmorController;

    public PanelAmmunitionController(PanelAmmunitionView panelAmmunitionView, SOUserData sOUserData)
    {
        _panelAmmunitionView = panelAmmunitionView;
        _armorPanel          = panelAmmunitionView.ArmorPanel;
        _enginePanel         = panelAmmunitionView.EnginePanel;
        _gunsPanel           = panelAmmunitionView.GunsPanel;
        _equipmentPanel      = panelAmmunitionView.EquipmentPanel;
        _ammunitionPanel     = panelAmmunitionView.AmmunitionPanel;
        _infoBotPanel        = panelAmmunitionView.InfoBotPanel;
        _panelMenuAmmunition = panelAmmunitionView.PanelMenuAmmunition;

        _botsData = sOUserData.BotsData;

        _panelArmorController = new PanelArmorController(_armorPanel.GetComponent<PanelArmorView>(), _armorPanel, _botsData);

        panelAmmunitionView.Armor     .onClick.AddListener(ArmorPanelActive);
        panelAmmunitionView.Engine    .onClick.AddListener(EnginePanelActive);
        panelAmmunitionView.Guns      .onClick.AddListener(GunsPanelActive);
        panelAmmunitionView.Equipment .onClick.AddListener(EquipmentPanelActive);
        panelAmmunitionView.Ammunition.onClick.AddListener(AmmunitionPanelActive);
        panelAmmunitionView.InfoBot   .onClick.AddListener(InfoBotPanelActive);
        panelAmmunitionView.Back      .onClick.AddListener(ComeBeack);
        panelAmmunitionView.Aply      .onClick.AddListener(IApply);

        ArmorPanelActive();

    }

    public void Execute()
    {
        _panelArmorController.Execute();
    }

    private void ComeBeack() {   _panelMenuAmmunition.SetActive(false); }

    private void ArmorPanelActive() 
    { ClearPanel(); _armorPanel.SetActive(true);  _panelArmorController.SetMaxArmor(); }

    private void EnginePanelActive() {  ClearPanel();  _enginePanel.SetActive(true); }

    private void GunsPanelActive() { ClearPanel();  _gunsPanel.SetActive(true); }

    private void EquipmentPanelActive() { ClearPanel(); _equipmentPanel.SetActive(true); }

    private void AmmunitionPanelActive() { ClearPanel(); _ammunitionPanel.SetActive(true); }

    private void InfoBotPanelActive() {  ClearPanel(); _infoBotPanel.SetActive(true); }

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
