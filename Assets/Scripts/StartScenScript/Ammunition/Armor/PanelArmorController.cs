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

    public PanelArmorController(PanelArmorView panelArmorView, GameObject armorPanel, SOBotsData botsData)
    {
        _panelArmorView = panelArmorView;
        _armorPanel = armorPanel;

        _botsData = botsData;

        _panelArmorView.CastArmor.onClick.AddListener(CastArmorClick);
        _panelArmorView.RolledArmor.onClick.AddListener(RolledArmorClick);
        _panelArmorView.CompositeArmor.onClick.AddListener(CompositeArmorClick);
        _panelArmorView.Plan.onClick.AddListener(PlanClick);
        _panelArmorView.Part.onClick.AddListener(PartClick);
        _armorImagePanels = _panelArmorView.ArmorImagePanels;
        CheckArmorrNull();
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
    private void CastArmorClick() => SwitchingImage(0);

    private void RolledArmorClick() => SwitchingImage(1);

    private void CompositeArmorClick() => SwitchingImage(2);

    private void PlanClick()
    { }
    private void PartClick()
    { }
    private void Apply()
    { }
    public void SetMaxArmor()
    {
        switch (_botsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: _panelArmorView.ArmorThicknessSlider.maxValue = 15; break;
            case ETypeBot.SBT: _panelArmorView.ArmorThicknessSlider.maxValue = 30; break;
            case ETypeBot.LT: _panelArmorView.ArmorThicknessSlider.maxValue = 60; break;
            case ETypeBot.TT: _panelArmorView.ArmorThicknessSlider.maxValue  = 200; break;
        }
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
        switch(_botsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT:  break;
            case ETypeBot.SBT: minArmor = 10; break;
            case ETypeBot.LT: minArmor = 15; break;
            case ETypeBot.TT: minArmor = 20; break;
        }
        for (int i = 0; i < armorPart.PlanSurfaces.Length; i++)
        {
            armorPart.PlanSurfaces[i].MM = minArmor;
        }
        armorPart.PlanSurfaces[0].PlanName = PlanName.Top;
        armorPart.PlanSurfaces[1].PlanName = PlanName.Bottom;
        armorPart.PlanSurfaces[2].PlanName = PlanName.Front;
        armorPart.PlanSurfaces[3].PlanName = PlanName.Back;
        armorPart.PlanSurfaces[4].PlanName = PlanName.Left;
        armorPart.PlanSurfaces[5].PlanName = PlanName.Right;
    }
}
