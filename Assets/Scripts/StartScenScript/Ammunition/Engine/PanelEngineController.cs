using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class PanelEngineController
{
    private ActivePanelAmmunition _activePanelAmmunition;
    private int _tempSliderVolue = 0;
    private float _glowTime;
    private Text _enginePowerText;
    private CurrencyModel _finishCost = new CurrencyModel();
    private PanelEngineView _panelEngineView;
    private SOBotsData _botsData;
    private SOEconomyData _economy;
    private CurrencyUserController _currencyUserController;
    private EconomyController _economyController;
    private MassController _massController;


    public PanelEngineController(PanelAmmunitionController panelAmmunitionController)
    {
        _panelEngineView = panelAmmunitionController.EnginePanel.GetComponent<PanelEngineView>();
        _botsData = panelAmmunitionController.BotsData;
        _economy = panelAmmunitionController.Economy;
        _currencyUserController = panelAmmunitionController.CurrencyUserController;
        _economyController = panelAmmunitionController.EconomyController;
        _massController = panelAmmunitionController.MassController;
        _activePanelAmmunition = panelAmmunitionController.ActivePanelAmmunition;
        _enginePowerText = _panelEngineView.EnginePowerText;
        _glowTime = panelAmmunitionController.GlowTime;

        panelAmmunitionController.PanelAmmunitionView.Aply.onClick.AddListener(BayEngine);
        SetSlider();
    }

    public void Execute()
    {
        if (_tempSliderVolue != (int)_panelEngineView.EnginePowerSlider.value)
        {
            _tempSliderVolue = (int)_panelEngineView.EnginePowerSlider.value;
            _enginePowerText.text = _tempSliderVolue.ToString();
            SetCost();
            SetMassEngine();
            ShowCost();
        }
    }

    public void SetMinMaxSlider()
    {
        switch (_botsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: _panelEngineView.EnginePowerSlider.minValue = 60;  _panelEngineView.EnginePowerSlider.maxValue = 180; break;
            case ETypeBot.SBT: _panelEngineView.EnginePowerSlider.minValue = 80; _panelEngineView.EnginePowerSlider.maxValue = 300; break;
            case ETypeBot.LT:  _panelEngineView.EnginePowerSlider.minValue = 150; _panelEngineView.EnginePowerSlider.maxValue = 600; break;
            case ETypeBot.TT:  _panelEngineView.EnginePowerSlider.minValue = 400; _panelEngineView.EnginePowerSlider.maxValue = 1500; break;
        }
    }

    private static void SetMassEngine()
    {
        //_massController.SetMass();
    }

    private void ShowCost()
    {
        string GoldBuy;
        string SilverBuy;
        string CopperBuy;

        string GoldRepair;
        string SilverRepair;
        string CopperRepair;
        _economyController.ShowPrice
            (
            out GoldBuy, out SilverBuy, out CopperBuy,
            out GoldRepair, out SilverRepair, out CopperRepair,
            _finishCost, _economy.Repair
            );

        _panelEngineView.PraceView.GoldBuy.text = GoldBuy;
        _panelEngineView.PraceView.SilverBuy.text = SilverBuy;
        _panelEngineView.PraceView.CopperBuy.text = CopperBuy;

        _panelEngineView.PraceView.GoldRepair.text = GoldRepair;
        _panelEngineView.PraceView.SilverRepair.text = SilverRepair;
        _panelEngineView.PraceView.CopperRepair.text = CopperRepair;
        //CheckIsCanBay();
    }
    public void SetSlider()
    {
        _panelEngineView.EnginePowerSlider.value = _botsData.ActivBot.PowerEngine;
    }
    private void BayEngine()
    {
        if (CheckIsCanBay() && _activePanelAmmunition == ActivePanelAmmunition.Engine)
        {
            _currencyUserController.Bay(_finishCost.Gold, _finishCost.Silver, _finishCost.Copper);
            SetBotEngine();
            ShowCost();
            SetMassEngine();
        }
    }
    private void SetBotEngine()
    {
        _botsData.ActivBot.PowerEngine = _tempSliderVolue;
    }
    private bool CheckIsCanBay() => _economyController.CheckIsCanBay(_finishCost, _glowTime);
    private void SetCost()
    {
        float coefficient = 1f;
        float tempSliderMax = _panelEngineView.EnginePowerSlider.maxValue;
        float _power = _panelEngineView.EnginePowerSlider.value;
        float level80 = tempSliderMax * 0.8f;
        float level40 = tempSliderMax * 0.4f;
        CurrencyModel cost = new CurrencyModel();

        switch (_botsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: coefficient += 0f; break;
            case ETypeBot.SBT: coefficient += 0.5f; break;
            case ETypeBot.LT: coefficient += 1f; break;
            case ETypeBot.TT: coefficient += 1.5f; break;
        }

        cost.Copper = (int)(_power * coefficient);
        if (_power > level40)
        {
            cost.Silver = (int)((_power - level40) * coefficient);
        }
        if (_power > level80)
        {
            cost.Gold = (int)((_power - level80) * coefficient);
        }
        _finishCost.SetCurrencyModel(cost.Gold, cost.Silver, cost.Copper);
    }
    public void ChenchBot()
    {
        SetSlider();
        SetMinMaxSlider();
    }
}
