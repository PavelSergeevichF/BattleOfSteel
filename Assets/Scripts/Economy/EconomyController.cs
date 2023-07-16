using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EconomyController : IExecute
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
    private EconomyView _economyView;

    private SelectCurrency _selectCurrency;
    private CurrencyUserController _currencyUserController;


    public EconomyController(EconomyView economyView, CurrencyUserController currencyUserController, SOUserData sOUserData, MainButtonPanelView mainButtonPanelView)
    {
        _economyView = economyView;
        _currencyUserController = currencyUserController;

        _goldText = economyView.GoldText;
        _silverText = economyView.SilverText;
        _copperText = economyView.CopperText;
        _expText = economyView.ExpText;
        _goldTextErr = economyView.GoldTextErr;
        _silverTextErr = economyView.SilverTextErr;
        _copperTextErr = economyView.CopperTextErr;
        _expTextErr = economyView.ExpTextErr;

        _sOUserData = sOUserData;
        
        mainButtonPanelView.ShowAdsButton.onClick.AddListener(ShowAdsClickOnButton);

        economyView.GoldButton.onClick.AddListener(GoldClickOnButton);
        economyView.SilverButton.onClick.AddListener(SilverClickOnButton);
        economyView.CopperButton.onClick.AddListener(CopperClickOnButton);
        economyView.ExpButton.onClick.AddListener(ExpClickOnButton);

        economyView.ConversionButton1_10.onClick.AddListener(SelectConversion1_10);
        economyView.ConversionButton5_50.onClick.AddListener(SelectConversion5_50);
        economyView.ConversionButton10_100.onClick.AddListener(SelectConversion10_100);

        ClearErrorChar();
        SetEconomyData();
    }

    public void Execute()
    {
        SetEconomyData();
    }

    private void SetEconomyData()
    {
        _goldText.text   = _sOUserData.Economy.CurrencyModel.Gold.ToString();
        _silverText.text = _sOUserData.Economy.CurrencyModel.Silver.ToString();
        _copperText.text = _sOUserData.Economy.CurrencyModel.Copper.ToString();
        _expText.text    = _sOUserData.ExpData.Exp.ToString();
    }
    private void ClearErrorChar()
    {
        _goldTextErr.gameObject.SetActive(false);
        _silverTextErr.gameObject.SetActive(false);
        _copperTextErr.gameObject.SetActive(false);
        _expTextErr.gameObject.SetActive(false);
    }
    public void GoldError() => _goldTextErr.gameObject.SetActive(true);
    public void SilverError() => _silverTextErr.gameObject.SetActive(true);
    public void CopperError() => _copperTextErr.gameObject.SetActive(true);
    public void ExpError() => _expTextErr.gameObject.SetActive(true);

    private void GoldClickOnButton()
    {
        _selectCurrency = SelectCurrency.Gold;
        _economyView.ConversionPanel.SetActive(true);
    }

    private void ShowAdsClickOnButton() => _currencyUserController.ShowAds();

    private void SilverClickOnButton()
    {
        _selectCurrency = SelectCurrency.Silver;
        _economyView.ConversionPanel.SetActive(true);
    }
    private void CopperClickOnButton()
    {
        _selectCurrency = SelectCurrency.Copper;
        _economyView.ConversionPanel.SetActive(true);
    }
    private void ExpClickOnButton()
    {
        _selectCurrency = SelectCurrency.Exp;
        _economyView.ConversionPanel.SetActive(true);
    }
    private void SelectConversion1_10()
    {
        Conversion(CurrencieSize.C10);
    }
    private void SelectConversion5_50()
    {
        Conversion(CurrencieSize.C50);
    }
    private void SelectConversion10_100()
    {
        Conversion(CurrencieSize.C100);
    }
    private void Conversion(CurrencieSize currencieSize)
    {
        _economyView.ConversionPanel.SetActive(false);
        switch (_selectCurrency)
        {
            case SelectCurrency.Gold:
                { }
                break;
            case SelectCurrency.Silver:
                _currencyUserController.ConversionSilverSelect(currencieSize);
                break;
            case SelectCurrency.Copper:
                _currencyUserController.ConversionCopperSelect(currencieSize);
                break;
            case SelectCurrency.Exp:
                { }
                break;
        }
    }
}
