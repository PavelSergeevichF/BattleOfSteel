using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.SharedModels;

public class ConversionController 
{
    private CurrencyUserView _currencyUserView;
    private SOUserData _sOUserData;
    private CurrencyUserController _currencyUserController;

    public ConversionController(CurrencyUserView currencyUserView, SOUserData sOUserData, CurrencyUserController currencyUserController)
    {
        _currencyUserView = currencyUserView;
        _sOUserData = sOUserData;
        _currencyUserController = currencyUserController;
    }

    public void ConversionSilverSelect(CurrencieSize currencieSize)
    { 
        switch(currencieSize)
        {
            case CurrencieSize.C10: ConversionCurrencies("SL10", 1, "GD");  break;
            case CurrencieSize.C50: ConversionCurrencies("SL50", 5, "GD");  break;
            case CurrencieSize.C100: ConversionCurrencies("SL100", 10, "GD");  break;
        };
    }

    public void ConversionCopperSelect(CurrencieSize currencieSize)
    {
        switch (currencieSize)
        {
            case CurrencieSize.C10: ConversionCurrencies("CU10", 1, "SL"); break;
            case CurrencieSize.C50: ConversionCurrencies("CU50", 5, "SL"); break;
            case CurrencieSize.C100: ConversionCurrencies("CU100", 10, "SL"); break;
        };
    }

    void ConversionCurrencies(string itemId, int price, string virtualCurrency)
    {
        PlayFabClientAPI.PurchaseItem(new PurchaseItemRequest
        {
            CatalogVersion = "0.1",
            ItemId = itemId,
            Price = price,
            VirtualCurrency = virtualCurrency
        }, LogSuccess, LogFailure);
    }
    void MakePurchase()
    {
        PlayFabClientAPI.PurchaseItem(new PurchaseItemRequest
        {
            CatalogVersion = "0.1",
            ItemId = "MediumHealthPotion",
            Price = 5,
            VirtualCurrency = "AU"
        }, LogSuccess, LogFailure);
    }
    void LogSuccess(PlayFabResultCommon result)
    {
        var requestName = result.Request.GetType().Name;
        Debug.Log(requestName + " successful");
    }
    void LogFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
}

public enum CurrencieSize
{
    C1,
    C5,
    C10,
    C50,
    C100,
    C500
};
