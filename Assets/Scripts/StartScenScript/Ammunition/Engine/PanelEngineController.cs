using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using static UnityEditor.ShaderData;

public class PanelEngineController : AmmunitionControllers
{
    private bool _firstStart = true;
    private int _tempSliderVolue = 0;
    private float _glowTime;
    private float _tempMass;
    private Text _enginePowerText;
    private CurrencyModel _finishCost = new CurrencyModel();
    private PanelEngineView _panelEngineView;
    private SOBotsData _botsData;
    private SOEconomyData _economy;
    private CurrencyUserController _currencyUserController;
    private EconomyController _economyController;
    private MassController _massController;
    PanelAmmunitionController _panelAmmunitionController;

    public PanelEngineController(PanelAmmunitionController panelAmmunitionController)
    {
        _panelEngineView = panelAmmunitionController.EnginePanel.GetComponent<PanelEngineView>();
        _botsData = panelAmmunitionController.BotsData;
        _economy = panelAmmunitionController.Economy;
        _currencyUserController = panelAmmunitionController.CurrencyUserController;
        _economyController = panelAmmunitionController.EconomyController;
        _massController = panelAmmunitionController.MassController;
        _enginePowerText = _panelEngineView.EnginePowerText;
        _glowTime = panelAmmunitionController.GlowTime;
        ActivePanelAmmunition = panelAmmunitionController.ActivePanelAmmunition;
        _panelAmmunitionController = panelAmmunitionController;

        panelAmmunitionController.PanelAmmunitionView.Aply.onClick.AddListener(BayEngine);
        SetSlider();
    }

    public void Execute()
    {
        if (ActivePanelAmmunition == ActivePanelAmmunition.Engine)
        {
            if (_firstStart)
            {
                _firstStart = false;
                CheckOnNull();
            }
            if (_tempSliderVolue != (int)_panelEngineView.EnginePowerSlider.value)
            {
                _tempSliderVolue = (int)_panelEngineView.EnginePowerSlider.value;
                _enginePowerText.text = _tempSliderVolue.ToString();
                SetCost();
                SetMassEngine();
                ShowCost();
            }
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

    private void SetMassEngine()
    {
        float Coefficient = 1f;
        float mass;
        switch (_botsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: Coefficient = 2.5f; break;
            case ETypeBot.SBT: Coefficient = 2f; break;
            case ETypeBot.LT: Coefficient = 1.5f; break;
            case ETypeBot.TT: Coefficient = 1f; break;
        }
        mass = _tempSliderVolue * Coefficient;
        _tempMass = mass / 1000;
        string str = "";
        if(_tempMass<1)
        {
            str = $"0{_tempMass.ToString("#.###")}";
        }
        else 
        {
            str = _tempMass.ToString("#.###");
        }
        _panelEngineView.PraceView.Mass.text = str;
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
        CheckIsCanBay();
    }
    public void SetSlider()
    {
        _panelEngineView.EnginePowerSlider.value = _botsData.ActivBot.PowerEngine;
    }
    private void BayEngine()
    {
        if (CheckIsCanBay() && ActivePanelAmmunition == ActivePanelAmmunition.Engine)
        {
            string error = "";
            if (!_currencyUserController.Bay(_finishCost.Gold, _finishCost.Silver, _finishCost.Copper, out error))
            {
                _botsData.ActivBot.MassBotPart.MassEngine = _tempMass;
                _massController.SetMass();
                SetBotEngine();
                ShowCost();
                SetMassEngine();
            }
            else 
            {
                _panelAmmunitionController.InfoHelpPanelController.SOInfoHelpTexts.AmmunitionHelp.TempInfo.HelpTextBody = error;
                _panelAmmunitionController.InfoHelpPanelController.SOInfoHelpTexts.AmmunitionHelp.TempInfo.HelpTextHead = "Ошибка сети";
                _panelAmmunitionController.InfoHelpPanelController.SetInform
                    (_panelAmmunitionController.InfoHelpPanelController.SOInfoHelpTexts.AmmunitionHelp.TempInfo);
            }
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
        float tempSliderMax = _panelEngineView.EnginePowerSlider.maxValue/5;
        float _power = _panelEngineView.EnginePowerSlider.value/5;
        float level80 = tempSliderMax * 0.8f;
        float level40 = tempSliderMax * 0.4f;
        CurrencyModel cost = new CurrencyModel();

        switch (_botsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: coefficient += 0f; break;
            case ETypeBot.SBT: coefficient += 0.2f; break;
            case ETypeBot.LT: coefficient += 0.4f; break;
            case ETypeBot.TT: coefficient += 0.6f; break;
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
        CheckOnNull();
    }
    private void CheckOnNull()
    {
        if(_botsData.ActivBot.PowerEngine<50)
        {
            switch (_botsData.ActivBot.TypeBot)
            {
                case ETypeBot.LBT: _botsData.ActivBot.PowerEngine = 60; break;
                case ETypeBot.SBT: _botsData.ActivBot.PowerEngine = 80; break;
                case ETypeBot.LT: _botsData.ActivBot.PowerEngine = 150; break;
                case ETypeBot.TT: _botsData.ActivBot.PowerEngine = 400; break;
            }
        }
    }
}
