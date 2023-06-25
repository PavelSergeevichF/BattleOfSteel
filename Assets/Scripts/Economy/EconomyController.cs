using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyController 
{
    private Text _goldText;
    private Text _silverText;
    private Text _copperText;
    private Text _expText;
    private Text _goldTextErr;
    private Text _silverTextErr;
    private Text _copperTextErr;
    private Text _expTextErr;
    private SOUserData _sOUserData;

    public EconomyController(Text goldText, Text silverText, Text copperText, Text expText, Text goldTextErr, Text silverTextErr, Text copperTextErr, Text expTextErr, SOUserData sOUserData)
    {
        _goldText = goldText;
        _silverText = silverText;
        _copperText = copperText;
        _expText = expText;
        _goldTextErr = goldTextErr;
        _silverTextErr = silverTextErr;
        _copperTextErr = copperTextErr;
        _expTextErr = expTextErr;
        _sOUserData = sOUserData;
        SetEconomyData();
    }

    public void Update()
    {
        SetEconomyData();
    }
    private void SetEconomyData()
    {
        _goldText.text   = _sOUserData.Economy.GoldText;
        _silverText.text = _sOUserData.Economy.SilverText;
        _copperText.text = _sOUserData.Economy.CopperText;
        _expText.text    = _sOUserData.ExpData.ExpText;
    }
}
