using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyUserView : MonoBehaviour
{
    private Dictionary<string, CatalogItem> _catalog = new Dictionary<string, CatalogItem>();
    private EconomyView _economyView;

    public Dictionary<string, CatalogItem> Catalog => _catalog;
    public EconomyView EconomyView => _economyView;

    public GetPlayerCombinedInfoRequestParams Info;



}
