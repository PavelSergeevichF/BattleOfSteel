using UnityEngine;

public class MenuAccountController : IInitialization
{
    private MenuAccountView _menuAccountView;
    private SOUserData _sOUserData;
    private GameObject _authorizOrRegPanel;

    public MenuAccountController(MenuAccountView menuAccountView, SOUserData sOUserData, GameObject authorizOrRegPanel)
    {
        _sOUserData = sOUserData;
        _authorizOrRegPanel = authorizOrRegPanel; 
        _menuAccountView = menuAccountView;
        menuAccountView.ExitAccount.onClick.AddListener(ClicOnExitAccount);
        menuAccountView.ShowInfo.onClick.AddListener(ClicOnShowInfo);
        menuAccountView.CloseInfo.onClick.AddListener(ClicOnCloseInfo);
        menuAccountView.Back.onClick.AddListener(ClicOnBack);
        SetData();
    }

    public void Init()
    {
    }
    private void SetData()
    {
        _menuAccountView.NameText.text = _sOUserData.UserName;
        _menuAccountView.VictoriesPercentagesText.text = Math(_sOUserData.ProgressData.VictoriesPercentages).ToString();
        _menuAccountView.BattlesText.text = _sOUserData.ProgressData.Battles.ToString();
        _menuAccountView.SkillPercentagesText.text = Math(_sOUserData.ProgressData.SkillPercentages).ToString();
        _menuAccountView.AwardsText.text = _sOUserData.ProgressData.Awards.ToString();
    }
    private void ClicOnExitAccount()
    {
        _sOUserData.Authorization = false;
        _sOUserData.UserName="";
        _sOUserData.UserPassword = "";
        _authorizOrRegPanel.SetActive(true);
    }
    private void ClicOnShowInfo()
    {
        _menuAccountView.PanelInfo.SetActive(true);
    }
    private void ClicOnCloseInfo()
    {
        _menuAccountView.PanelInfo.SetActive(false);
    }
    private void ClicOnBack()
    {
        _menuAccountView.PanelAccount.SetActive(false);
    }

    private float Math(float data) 
    {
        float tempF = data * 100;
        int tempI = (int)tempF;
        tempF = tempI;
        tempF = tempF / 100;
        return tempF;
    }
}
