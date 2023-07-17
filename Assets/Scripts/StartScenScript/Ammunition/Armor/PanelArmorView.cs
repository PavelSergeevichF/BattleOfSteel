using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PanelArmorView  : AmmunitionsElement
{
    [Header("Buttons")]
    [SerializeField] private Button _castArmor;
    [SerializeField] private Button _rolledArmor;
    [SerializeField] private Button _compositeArmor;
    [SerializeField] private Button _plan;
    [SerializeField] private Button _part;

    [Header("Panels")]
    [SerializeField] private List<GameObject> _armorImagePanels;

    [Header("Slider")]
    public Slider ArmorThicknessSlider;

    [Header("Text")]
    public Text PlanText;
    public Text PartText;
    public Text ArmorThicknessText;

    [Header("Text")]
    public float GlowTime = 2f; 

    public Button CastArmor => _castArmor;
    public Button RolledArmor => _rolledArmor;
    public Button CompositeArmor => _compositeArmor;
    public Button Plan => _plan;
    public Button Part => _part;

    public List<GameObject> ArmorImagePanels => _armorImagePanels;

}
