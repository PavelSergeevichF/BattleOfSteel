using UnityEngine;

[CreateAssetMenu(fileName = "SOUserData", menuName = "User/SOUserData", order = 1)]
public class SOUserData : ScriptableObject
{
    public string UserName;
    public string UserPassword;

    public SOEconomyData Economy;
    public SOExpData ExpData;
    public SOBotsData BotsData;
    public SOProgressData ProgressData;

    public bool Authorization = false;
}
