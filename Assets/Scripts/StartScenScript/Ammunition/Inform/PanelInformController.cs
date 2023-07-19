using UnityEngine;

public class PanelInformController : IExecute
{
    private BotModel _botData;
    private PanelInformView _panelInformView;

    public PanelInformController(SOBotsData botsData, PanelInformView panelInformView)
    {
        _botData = botsData.ActivBot;
        _panelInformView = panelInformView;
    }

    public void Execute()
    {
    }
    public void UpdateInform()
    {
        SetTypeName();
        SetMassInfo();
        SetArmorInfo();
    }

    private void SetTypeName()
    { 
        switch(_botData.TypeBot)
        {
            case ETypeBot.LBT: _panelInformView.BotText[0].text = "Легкий БТР"; break;
            case ETypeBot.SBT: _panelInformView.BotText[0].text = "Средний БТР"; break;
            case ETypeBot.LT: _panelInformView.BotText[0].text = "Средний танк"; break;
            case ETypeBot.TT: _panelInformView.BotText[0].text = "Тяжелый танк"; break;
        }
    }
    private void SetMassInfo()
    {
        float tmp = _botData.MassBotFinish * 10;
        int tmpI = (int)tmp;
        tmp = tmpI;
        tmp = tmp / 10;
        _panelInformView.BotText[1].text = tmp.ToString();
    }
    private void SetArmorInfo()
    {
        _panelInformView.ArmTowerText[0].text = _botData.ArmorModel.ArmorTower.PlanSurfaces[ePlanName.Front].MM.ToString();
        _panelInformView.ArmTowerText[1].text = _botData.ArmorModel.ArmorTower.PlanSurfaces[ePlanName.Back].MM.ToString();
        _panelInformView.ArmTowerText[2].text = _botData.ArmorModel.ArmorTower.PlanSurfaces[ePlanName.Top].MM.ToString();
        _panelInformView.ArmTowerText[3].text = _botData.ArmorModel.ArmorTower.PlanSurfaces[ePlanName.Bottom].MM.ToString();
        _panelInformView.ArmTowerText[4].text = _botData.ArmorModel.ArmorTower.PlanSurfaces[ePlanName.Flank].MM.ToString();

        _panelInformView.ArmBodyText[0].text = _botData.ArmorModel.ArmorBody.PlanSurfaces[ePlanName.Front].MM.ToString();
        _panelInformView.ArmBodyText[1].text = _botData.ArmorModel.ArmorBody.PlanSurfaces[ePlanName.Back].MM.ToString();
        _panelInformView.ArmBodyText[2].text = _botData.ArmorModel.ArmorBody.PlanSurfaces[ePlanName.Top].MM.ToString();
        _panelInformView.ArmBodyText[3].text = _botData.ArmorModel.ArmorBody.PlanSurfaces[ePlanName.Bottom].MM.ToString();
        _panelInformView.ArmBodyText[4].text = _botData.ArmorModel.ArmorBody.PlanSurfaces[ePlanName.Flank].MM.ToString();
    }
}
