using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogManagerView : MonoBehaviour
{
    private Dictionary<string, CatalogItem> _catalog = new Dictionary<string, CatalogItem>();
    public void Init()
    {
        var catalogRequest = new GetCatalogItemsRequest();
        PlayFabClientAPI.GetCatalogItems(catalogRequest, Success, Failure);
    }
    private void Success(GetCatalogItemsResult result) 
    {
        foreach( var item in result.Catalog)
        {
            _catalog.Add(item.ItemId,item);
            Debug.Log($"Name {item.DisplayName}, ID {item.ItemId}");
        }
    }
    private void Failure(PlayFabError error) 
    {
        Debug.LogError(error.GenerateErrorReport());
    }
}
