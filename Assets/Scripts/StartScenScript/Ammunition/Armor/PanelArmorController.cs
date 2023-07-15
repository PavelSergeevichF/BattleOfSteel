using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PanelArmorController
{
    private int _numImg = 0;

    private List<GameObject> _armorImagePanels;

    private Text _planText;
    private Text _partText;
    private Text _armorThicknessText;

    private PanelArmorView _panelArmorView;
    private GameObject _armorPanel;
    private SOBotsData _botsData;
    private SOEconomyData _economy;

    private CostArmor _costArmor;

    private ArmorDataModel _armorDataModel;
    private ePartBotName _ePartBotName= ePartBotName.Body;
    private ePlanName _ePlanName = ePlanName.Top;
    private eTypeArmor _eTypeArmor = eTypeArmor.Easy;

    private int _ePartNum = 0;
    private int _ePlanNum = 0;

    public PanelArmorController(PanelArmorView panelArmorView, GameObject armorPanel, SOBotsData botsData, SOEconomyData economy, Button aply)
    {
        _panelArmorView = panelArmorView;
        _armorPanel = armorPanel;

        _botsData = botsData;
        _economy = economy;

        _panelArmorView.CastArmor.onClick.AddListener(CastArmorClick);
        _panelArmorView.RolledArmor.onClick.AddListener(RolledArmorClick);
        _panelArmorView.CompositeArmor.onClick.AddListener(CompositeArmorClick);
        _panelArmorView.Plan.onClick.AddListener(PlanClick);
        _panelArmorView.Part.onClick.AddListener(PartClick);
        aply.onClick.AddListener(Apply);
        _armorImagePanels = _panelArmorView.ArmorImagePanels;
        InitData();
        CheckArmorrNull();
        _armorDataModel = new ArmorDataModel();
        _costArmor = new CostArmor(_ePartBotName, _ePlanName, _eTypeArmor, _armorDataModel, _economy, panelArmorView.ArmorThicknessSlider);
    }

    private void InitData()
    {
        CastArmorClick();
        SelectPart(0);
        SelectPlan(0);
    }
    public void Execute()
    {
        SetData();
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

    private void PlanClick()
    {
        if (_ePlanNum < 5) _ePlanNum++;
        else _ePlanNum =  0;
        SelectPlan(_ePlanNum);
    }
    private void PartClick()
    {
        if (_ePartNum < 1) _ePartNum++;
        else _ePartNum = 0;
        SelectPart(_ePartNum);
    }
    private void Apply()
    {
        UnityEngine.Debug.Log("Применить");
    }
    public void SetMaxArmor()
    {
        switch (_botsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: _panelArmorView.ArmorThicknessSlider.minValue = 5; _panelArmorView.ArmorThicknessSlider.maxValue = 15; break;
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
                _ePartBotName = ePartBotName.Twer;
                _panelArmorView.PartText.text = "башни";
                break;
        };
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
                _ePlanName = ePlanName.Left;
                _panelArmorView.PlanText.text = "Левый бок";
                break;
            case 5:
                _ePlanName = ePlanName.Right;
                _panelArmorView.PlanText.text = "Правый бок";
                break;
        };
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
        if(_botsData.ActivBot.ArmorModel==null)
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
        for (int i = 0; i < armorPart.PlanSurfaces.Length; i++)
        {
            armorPart.PlanSurfaces[i].MM = minArmor;
        }
        armorPart.PlanSurfaces[0].PlanName = ePlanName.Top;
        armorPart.PlanSurfaces[1].PlanName = ePlanName.Bottom;
        armorPart.PlanSurfaces[2].PlanName = ePlanName.Front;
        armorPart.PlanSurfaces[3].PlanName = ePlanName.Back;
        armorPart.PlanSurfaces[4].PlanName = ePlanName.Left;
        armorPart.PlanSurfaces[5].PlanName = ePlanName.Right;
    }
}

public enum ePartBotName
{
    Twer,
    Body
}

public enum eTypeArmor
{
    Easy,
    Medium,
    Hard
}

public class CostArmor
{
    private ePartBotName _ePartBotName;
    private ePlanName _ePlanName;
    private eTypeArmor _eTypeArmor;
    private ArmorDataModel _armorDataModel;
    private SOEconomyData _economy;
    private Slider _armorThicknessSlider;

    public CostArmor(ePartBotName ePartBotName, ePlanName ePlanName, eTypeArmor eTypeArmor, ArmorDataModel armorDataModel, SOEconomyData economy, Slider armorThicknessSlider)
    {
        _ePartBotName = ePartBotName;
        _ePlanName = ePlanName;
        _eTypeArmor = eTypeArmor;
        _armorDataModel = armorDataModel;
        _economy = economy;
        _armorThicknessSlider = armorThicknessSlider;
    }

    public void SetPart(ePartBotName ePartBotName)
    {
        _ePartBotName = ePartBotName;
    }
    public void SetPlan(ePlanName ePlanName) 
    {
        _ePlanName = ePlanName;
    }
    public void SetTypeArmor(eTypeArmor eTypeArmor) 
    {
        _eTypeArmor = eTypeArmor;
    }

}