using UnityEngine;

public class BotController
{
    private GameObject _bodyBot;
    private GameObject _towerBot;
    private GameObject _gunBot;
    private BotView _botView;
    private SOBotPosition _sOBotPosition;

    public BotController(BotView botView, SOBotPosition sOBotPosition)
    {
        _botView = botView;
        _sOBotPosition = sOBotPosition;
        _bodyBot = botView.BodyBot;
        _towerBot = botView.TowerBot;
        _gunBot = botView.GunBot;
    }
    
    public void Update()
    {
        _sOBotPosition.BotPosition = _botView.transform.position;
    }
}
