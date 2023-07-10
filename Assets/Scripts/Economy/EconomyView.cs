using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyView : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _goldButton;
    [SerializeField] private Button _silverButton;
    [SerializeField] private Button _copperButton;
    [SerializeField] private Button _expButton;

    [SerializeField] private Button _conversionButton1_10;
    [SerializeField] private Button _conversionButton5_50;
    [SerializeField] private Button _conversionButton10_100;

    //ConversionButton1_10

    [Header("Texts")]
    [SerializeField] private Text _goldText;
    [SerializeField] private Text _silverText;
    [SerializeField] private Text _copperText;
    [SerializeField] private Text _expText;

    [Header("TextsErrors")]
    [SerializeField] private Text _goldTextErr;
    [SerializeField] private Text _silverTextErr;
    [SerializeField] private Text _copperTextErr;
    [SerializeField] private Text _expTextErr;

    [Header("Panels")]
    [SerializeField] private GameObject _conversionPanel;

    [SerializeField] private SOUserData _sOUserData;
    private EconomyController _economyController;

    public Button GoldButton => _goldButton;
    public Button SilverButton => _silverButton;
    public Button CopperButton => _copperButton;
    public Button ExpButton => _expButton;

    public Button ConversionButton1_10 => _conversionButton1_10;
    public Button ConversionButton5_50 => _conversionButton5_50;
    public Button ConversionButton10_100 => _conversionButton10_100;

    public Text GoldText => _goldText;
    public Text SilverText => _silverText;
    public Text CopperText => _copperText;
    public Text ExpText => _expText;
               
    public Text GoldTextErr => _goldTextErr;
    public Text SilverTextErr => _silverTextErr;
    public Text CopperTextErr => _copperTextErr;
    public Text ExpTextErr => _expTextErr;

    public GameObject ConversionPanel => _conversionPanel;
}
