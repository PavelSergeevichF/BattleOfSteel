using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PanelArmorController
{
    private ActivePanelAmmunition _activePanelAmmunition;

    private int _numImg = 0;
    private bool _firstStart = true;
    private int _timeForOffSignal = 0;

    private List<GameObject> _armorImagePanels;

    //private Text _planText;
    //private Text _partText;
    //private Text _armorThicknessText;

    private PanelArmorView _panelArmorView;
    //private GameObject _armorPanel;
    private SOBotsData _botsData;
    private SOEconomyData _economy;

    private CurrencyUserController _currencyUserController;
    private CostArmor _costArmor;
    private SetMassArmorController _setMassArmorController;

    private ArmorDataModel _armorDataModel;
    private ePartBotName _ePartBotName= ePartBotName.Body;
    private ePlanName _ePlanName = ePlanName.Top;
    private eTypeArmor _eTypeArmor = eTypeArmor.Easy;

    private int _ePartNum = 0;
    private int _ePlanNum = 0;
    private EconomyController _economyController;
    private MassController _massController;

    public PanelArmorController(PanelAmmunitionController panelAmmunitionController)
    {
        _panelArmorView = panelAmmunitionController.ArmorPanel.GetComponent<PanelArmorView>();
        //_armorPanel = panelAmmunitionController.ArmorPanel;
        _currencyUserController = panelAmmunitionController.CurrencyUserController;
        _botsData = panelAmmunitionController.BotsData;
        _economy = panelAmmunitionController.Economy;
        _economyController = panelAmmunitionController.EconomyController;
        _massController = panelAmmunitionController.MassController;
        _activePanelAmmunition = panelAmmunitionController.ActivePanelAmmunition;

        _panelArmorView.CastArmor.onClick.AddListener(CastArmorClick);
        _panelArmorView.RolledArmor.onClick.AddListener(RolledArmorClick);
        _panelArmorView.CompositeArmor.onClick.AddListener(CompositeArmorClick);
        _panelArmorView.Plan.onClick.AddListener(PlanClick);
        _panelArmorView.Part.onClick.AddListener(PartClick);
        panelAmmunitionController.PanelAmmunitionView.Aply.onClick.AddListener(BayArmorr);
        _armorImagePanels = _panelArmorView.ArmorImagePanels;
        CheckArmorrNull();
        _armorDataModel = new ArmorDataModel();
        _setMassArmorController = new SetMassArmorController(_botsData.ActivBot);
        _costArmor = new CostArmor(_ePartBotName, _ePlanName, _eTypeArmor, _armorDataModel, _panelArmorView.ArmorThicknessSlider, _botsData.ActivBot);
        _costArmor.ChangesCost += ShowCost;
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
            _costArmor.GetFinishCost() , _economy.Repair
            );

        _panelArmorView.PraceView.GoldBuy.text = GoldBuy;
        _panelArmorView.PraceView.SilverBuy.text = SilverBuy;
        _panelArmorView.PraceView.CopperBuy.text = CopperBuy;

        _panelArmorView.PraceView.GoldRepair.text = GoldRepair;
        _panelArmorView.PraceView.SilverRepair.text = SilverRepair;
        _panelArmorView.PraceView.CopperRepair.text = CopperRepair;
        CheckIsCanBay();
    }
    
    private void InitData()
    {
        CastArmorClick();
        SelectPart(0);
        SelectPlan(0);
        CheckOnSetDatabot();
    }
    public void Execute()
    {
        if(_firstStart)
        {
            _firstStart = false;
            InitData();
        }
        SetData();
        _costArmor.Execute();
        _economyController.WorkErrorBay();
    }

    private void SetData()
    {
        int ArmorThickness = (int)_panelArmorView.ArmorThicknessSlider.value;
        _panelArmorView.ArmorThicknessText.text = ArmorThickness.ToString();
    }
    private void CastArmorClick() 
    {
        _eTypeArmor = eTypeArmor.Easy;
        SwitchingImage(0);
    }

    private void RolledArmorClick() 
    {
        _eTypeArmor = eTypeArmor.Medium;
        SwitchingImage(1);
    }

    private void CompositeArmorClick()
    {
        _eTypeArmor = eTypeArmor.Hard;
        SwitchingImage(2);
    }

    private void CheckOnSetDatabot()
    {
        bool notSet = false;
        if (_botsData.ActivBot.ArmorModel.ArmorBody.PlanSurfaces.Count < 5)
        {
            notSet=true;
        }
        else
        {
            notSet = true;
            foreach (var surface in _botsData.ActivBot.ArmorModel.ArmorBody.PlanSurfaces)
            {
                if (surface.Key == ePlanName.Front) notSet = false;
            }
            if (!notSet)
            {
                if (_botsData.ActivBot.ArmorModel.ArmorBody.PlanSurfaces[ePlanName.Front].MM < 1)
                {
                    notSet = true;
                }
            }
        }
        if(notSet)
        {
            SetFirstDataBot();
        }
        _botsData.ActivBot.ArmorModel.ArmorBody.SetListForShowe();
        _botsData.ActivBot.ArmorModel.ArmorTower.SetListForShowe();
    }
    private void SetFirstDataBot()
    {
        UnityEngine.Debug.Log("SetDataBot");
        if (_botsData.ActivBot.ArmorModel.ArmorBody.PlanSurfaces.Count > 0)
        {
            _botsData.ActivBot.ArmorModel.ArmorBody.PlanSurfaces.Clear();
            _botsData.ActivBot.ArmorModel.ArmorTower.PlanSurfaces.Clear();
        }
        SetArmorEmpety(_botsData.ActivBot.ArmorModel.ArmorTower);
        SetArmorEmpety(_botsData.ActivBot.ArmorModel.ArmorBody);
        SetMassArmor();
    }
    private void PlanClick()
    {
        if (_ePlanNum < 4) _ePlanNum++;
        else _ePlanNum =  0;
        SelectPlan(_ePlanNum);
    }
    private void PartClick()
    {
        if (_ePartNum < 1) _ePartNum++;
        else _ePartNum = 0;
        SelectPart(_ePartNum);
    }
    
    private void BayArmorr()
    {
        if(CheckIsCanBay() && _activePanelAmmunition == ActivePanelAmmunition.Armor)
        {
            _currencyUserController.Bay(_costArmor.FinishCost.Gold, _costArmor.FinishCost.Silver, _costArmor.FinishCost.Copper);
            SetBotArmor();
            ShowCost();
            SetMassArmor();
        }
    }
    private void SetMassArmor()
    {
        _setMassArmorController.SetDataMassArmor();
        _massController.SetMass();
    }
    private void SetBotArmor()
    {
        foreach (var planSurfaces in _costArmor.GetArmorDataModel().ArmorTower.PlanSurfaces)
        {
            PlanSurface tempPlanSurface = new PlanSurface(planSurfaces.Key, planSurfaces.Value.MM, planSurfaces.Value.Cost);
            _botsData.ActivBot.ArmorModel.ArmorTower.PlanSurfaces.Remove(planSurfaces.Key);
            _botsData.ActivBot.ArmorModel.ArmorTower.PlanSurfaces.Add(planSurfaces.Key, tempPlanSurface);
        }
        foreach (var planSurfaces in _costArmor.GetArmorDataModel().ArmorBody.PlanSurfaces)
        {
            PlanSurface tempPlanSurface = new PlanSurface(planSurfaces.Key, planSurfaces.Value.MM, planSurfaces.Value.Cost);
            _botsData.ActivBot.ArmorModel.ArmorBody.PlanSurfaces.Remove(planSurfaces.Key);
            _botsData.ActivBot.ArmorModel.ArmorBody.PlanSurfaces.Add(planSurfaces.Key, tempPlanSurface);
        }
        _botsData.ActivBot.ArmorModel.ArmorTower.SetListForShowe();
        _botsData.ActivBot.ArmorModel.ArmorBody.SetListForShowe();
    }
    private bool CheckIsCanBay() =>_economyController.CheckIsCanBay(_costArmor.FinishCost, _panelArmorView.GlowTime);
    public void SetMaxArmor()
    {
        switch (_botsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: _panelArmorView.ArmorThicknessSlider.minValue = 1; _panelArmorView.ArmorThicknessSlider.maxValue = 15; break;
            case ETypeBot.SBT: _panelArmorView.ArmorThicknessSlider.minValue = 10; _panelArmorView.ArmorThicknessSlider.maxValue = 30; break;
            case ETypeBot.LT: _panelArmorView.ArmorThicknessSlider.minValue = 15; _panelArmorView.ArmorThicknessSlider.maxValue = 80; break;
            case ETypeBot.TT: _panelArmorView.ArmorThicknessSlider.minValue = 20; _panelArmorView.ArmorThicknessSlider.maxValue  = 200; break;
        }
    }

    private void SelectPart(int num)
    { 
        switch (num)
        { 
            case 0: 
                _ePartBotName = ePartBotName.Body;
                _panelArmorView.PartText.text = "корпуса";
                break;
            case 1: 
                _ePartBotName = ePartBotName.Tower;
                _panelArmorView.PartText.text = "башни";
                break;
        };
        _costArmor.SetPart(_ePartBotName);
    }

    private void SelectPlan(int num)
    {
        switch (num)
        {
            case 0: 
                _ePlanName = ePlanName.Top;
                _panelArmorView.PlanText.text = "Верх";
                break;
            case 1: 
                _ePlanName = ePlanName.Bottom;
                _panelArmorView.PlanText.text = "Низ"; 
                break;
            case 2: 
                _ePlanName = ePlanName.Front;
                _panelArmorView.PlanText.text = "Лоб";
                break;
            case 3: 
                _ePlanName = ePlanName.Back;
                _panelArmorView.PlanText.text = "Корма";
                break;
            case 4: 
                _ePlanName = ePlanName.Flank;
                _panelArmorView.PlanText.text = "Бок";
                break;
        };
        _costArmor.SetPlan(_ePlanName);
    }
    private void SwitchingImage(int num)
    {
        foreach(var img in _armorImagePanels)
        {
            img.SetActive(false);
        }
        _armorImagePanels[num].SetActive(true);
    }
    private void CheckArmorrNull()
    { 
        if( _botsData.ActivBot.ArmorModel.ArmorBody.PlanSurfaces==null || _botsData.ActivBot.ArmorModel.ArmorBody.PlanSurfaces.Count<1)
        {
            SetArmorEmpety(_botsData.ActivBot.ArmorModel.ArmorTower);
            SetArmorEmpety(_botsData.ActivBot.ArmorModel.ArmorBody);
        }
    }
    private void SetArmorEmpety(ArmorPart armorPart)
    {
        int minArmor = 5;
        
        switch (_botsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: minArmor = 5; break;
            case ETypeBot.SBT: minArmor = 10; break;
            case ETypeBot.LT: minArmor = 15;  break;
            case ETypeBot.TT: minArmor = 20;  break;
        }
        armorPart.PlanSurfaces.Add(ePlanName.Top, new PlanSurface(ePlanName.Top, minArmor, new CurrencyModel()));
        armorPart.PlanSurfaces.Add(ePlanName.Bottom, new PlanSurface(ePlanName.Bottom, minArmor, new CurrencyModel()));
        armorPart.PlanSurfaces.Add(ePlanName.Front, new PlanSurface(ePlanName.Front, minArmor, new CurrencyModel()));
        armorPart.PlanSurfaces.Add(ePlanName.Back, new PlanSurface(ePlanName.Back, minArmor, new CurrencyModel()));
        armorPart.PlanSurfaces.Add(ePlanName.Flank, new PlanSurface(ePlanName.Flank, minArmor, new CurrencyModel()));
    }
}