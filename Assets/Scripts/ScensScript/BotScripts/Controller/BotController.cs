using UnityEngine;

public class BotController
{
    private GameObject _bodyBot;
    private GameObject _towerBot;
    private GameObject _gunBot;
    private BotView _botView;

    public BotController(BotView botView)
    {
        _botView = botView;
        _bodyBot = botView.BodyBot;
        _towerBot = botView.TowerBot;
        _gunBot = botView.GunBot;
    }
    
    public void Update()
    {
    }
}
