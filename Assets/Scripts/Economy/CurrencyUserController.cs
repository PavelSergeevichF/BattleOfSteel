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

    private string _myPlayFabId;
    private bool _enterPlayFab = false;

    public CurrencyUserController(CurrencyUserView currencyUserView, SOUserData sOUserData)
    {
        _currencyUserView = currencyUserView;
        _sOUserData = sOUserData;
        _conversionController = new ConversionController(currencyUserView, sOUserData, this);


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
                _enterPlayFab = true;

            },
                Failure
            );

        }
    }
    public void GetDataUserCurrency()
    {
        if (_sOUserData.Authorization)
        {
            PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, Failure);
        }
    }

    private void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        _sOUserData.Economy.Gold = result.VirtualCurrency["GD"];
        _sOUserData.Economy.Silver = result.VirtualCurrency["SL"];
        _sOUserData.Economy.Copper = result.VirtualCurrency["CU"];
        _sOUserData.ExpData.Exp = result.VirtualCurrency["EX"];
    }

    public void ShowAds()
    {
        AddCurrency(3, SelectCurrency.Gold);
    }

    private void AddCurrency(int volue, SelectCurrency selectCurrency)
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

    public void ReductionCurrency(int volue, SelectCurrency selectCurrency)
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
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = currencyType,
            Amount = volue
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, Failure);
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
