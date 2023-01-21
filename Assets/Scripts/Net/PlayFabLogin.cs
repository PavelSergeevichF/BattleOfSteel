using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    private const string PLAYFAB_TITLE = "58BCD";
    private const string GAME_VERSION = "dev";
    private const string AUTHENTIFICATION_KEY = "AUTHENTIFICATION_KEY";

    private struct Data
    {
        public bool needCreation;
        public string id;
    }
    public void Start()
    {
        // Here we need to check whether TitleId property is configured in settings or not
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            * If not we need to assign it to the appropriate variable manually
            * Otherwise we can just remove this if statement at all
            */
            PlayFabSettings.staticSettings.TitleId = PLAYFAB_TITLE; 
        } 

        var needCreation = !PlayerPrefs.HasKey(AUTHENTIFICATION_KEY);
        var id=PlayerPrefs.GetString(AUTHENTIFICATION_KEY, Guid.NewGuid().ToString());
        var data = new Data { needCreation = needCreation, id = id };
        var request = new LoginWithCustomIDRequest
        {
            CustomId = id,
            CreateAccount = needCreation
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure, data);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log($"LoginPlayFab!!!!!!!!!!!!!!!!!");
        Debug.Log(result.PlayFabId);
        Debug.Log((string)result.CustomData);
        Connect();
    }


    private void OnLoginFailure(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport();
        Debug.LogError($"Something went wrong: {errorMessage}");
    }
    private void Connect()
    {
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomOrCreateRoom();
        }
    }

}
