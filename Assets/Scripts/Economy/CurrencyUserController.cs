using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using PlayFab.SharedModels;
using UnityEditor.PackageManager.Requests;

public class CurrencyUserController : IInitialization
{
    private CurrencyUserView _currencyUserView;
    private SOUserData _sOUserData;
    private ConversionController _conversionController;

    public CurrencyUserController(CurrencyUserView currencyUserView, SOUserData sOUserData)
    {
        _currencyUserView = currencyUserView;
        _sOUserData = sOUserData;
        _conversionController = new ConversionController(currencyUserView, sOUserData, this);
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = _sOUserData.TitleID;
        }
    }

    public void Init()
    {
        FirstGetDataUserCurrency();
        GetDataUserCurrency();
    }

    public void FirstGetDataUserCurrency()
    {
        if (_sOUserData.Authorization)
        {
            LoginWithPlayFabRequest loginRequest = new LoginWithPlayFabRequest();
            loginRequest.Username = _sOUserData.UserName;
            loginRequest.Password = _sOUserData.UserPassword;
            loginRequest.InfoRequestParameters = _currencyUserView.Info;
            
            PlayFabClientAPI.LoginWithPlayFab(loginRequest,
                result =>
            {
                Debug.Log($"User registrated: {result.LastLoginTime}");
                ChekOnAutorization();

            },
                Failure
            ) ;
        }
    }
    private void ChekOnAutorization()
    {
        GetDataUserCurrency();
    }
    public void GetDataUserCurrency()
    {
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, Failure);
        }
    }

    private void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        _sOUserData.Economy.CurrencyModel.Gold = result.VirtualCurrency["GD"];
        _sOUserData.Economy.CurrencyModel.Silver = result.VirtualCurrency["SL"];
        _sOUserData.Economy.CurrencyModel.Copper = result.VirtualCurrency["CU"];
        _sOUserData.ExpData.Exp = result.VirtualCurrency["EX"];
    }

    public void ShowAds()
    {
        AddCurrency(3, SelectCurrency.Gold);
    }

    public void CheckIsCanBay(CurrencyModel cost, out bool needG, out bool needS, out bool needC, out bool canBay )
    {
        canBay = true;
        needG = false;
        needS = false;
        needC = false;
        GetDataUserCurrency();
        if (cost.Gold > _sOUserData.Economy.CurrencyModel.Gold) { canBay = false; needG = true; }
        if (cost.Silver > _sOUserData.Economy.CurrencyModel.Silver) { canBay = false; needS = true; }
        if (cost.Copper > _sOUserData.Economy.CurrencyModel.Copper) { canBay = false; needC = true; }
    }
    public void Bay(int g, int s, int c)
    {
        ReductionCurrency(g, SelectCurrency.Gold);
        ReductionCurrency(s, SelectCurrency.Silver);
        ReductionCurrency(c, SelectCurrency.Copper);
    }

    private void AddCurrency(int volue, SelectCurrency selectCurrency) // добавление
    {
        string currencyType = "EX";
        switch(selectCurrency)
        {
            case SelectCurrency.Gold:
                currencyType = "GD";
                break;
            case SelectCurrency.Silver:
                currencyType = "SL";
                break;
            case SelectCurrency.Copper:
                currencyType = "CU";
                break;
            case SelectCurrency.Exp:
                currencyType = "EX";
                break;
        }
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = currencyType,
            Amount = volue
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, Failure);
    }

    public void ReductionCurrency(int volue, SelectCurrency selectCurrency)//убывание
    {
        string currencyType = "EX";
        switch (selectCurrency)
        {
            case SelectCurrency.Gold:
                currencyType = "GD";
                break;
            case SelectCurrency.Silver:
                currencyType = "SL";
                break;
            case SelectCurrency.Copper:
                currencyType = "CU";
                break;
            case SelectCurrency.Exp:
                currencyType = "EX";
                break;
        }
        if(volue>0)
        {
            var request = new SubtractUserVirtualCurrencyRequest
            {
                VirtualCurrency = currencyType,
                Amount = volue
            };
            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, Failure);
        }
    }

    private void OnGrantVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        GetDataUserCurrency();
    }
    public void ConversionSilverSelect(CurrencieSize currencieSize)
    {
        _conversionController.ConversionSilverSelect(currencieSize);
        GetDataUserCurrency();
    }
    public void ConversionCopperSelect(CurrencieSize currencieSize)
    {
        _conversionController.ConversionCopperSelect(currencieSize);
        GetDataUserCurrency();
    } 
    public void InitCatalog()
    {
        var catalogRequest = new GetCatalogItemsRequest();
        PlayFabClientAPI.GetCatalogItems(catalogRequest, Success, Failure);
    }
    private void Success(GetCatalogItemsResult result)
    {
        foreach (var item in result.Catalog)
        {
            _currencyUserView.Catalog.Add(item.ItemId, item);
            Debug.Log($"Name {item.DisplayName}, ID {item.ItemId}");
        }
    }
    private void Failure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
}
