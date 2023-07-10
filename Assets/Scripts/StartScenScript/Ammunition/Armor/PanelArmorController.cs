using System.Collections.Generic;
using System.Diagnostics;
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
    private void SwitchingImage(int num)
    {
        foreach(var img in _armorImagePanels)
        {
            img.SetActive(false);
        }
        _armorImagePanels[num].SetActive(true);
    }
}
