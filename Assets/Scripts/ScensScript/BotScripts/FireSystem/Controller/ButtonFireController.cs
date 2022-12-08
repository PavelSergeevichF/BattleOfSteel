using UnityEngine;

public class ButtonFireController
{
    private SOBotConnect _bot;
    private SOBotShellModel _sOBotShellModel;
    private BotView _botView;
    private const int _maxTimeGun= 30;
    private int _timeGun = 30;
    private const int _maxTimeMachineGun = 30;
    private int _timeMachineGun = 30;
    private int _test = 0;

    public ButtonFireController(SOBotConnect bot)
    {
        _bot = bot;
        _sOBotShellModel = _bot.bot.GetComponent<BotView>().GetSOBotModel().Ammunition;
        _botView = _bot.bot.GetComponent<BotView>();
    }
    public void Update()
    {
        _reload();
    }
    public void GunFire() 
    {
        if(_timeGun== _maxTimeGun)
        {
            if(_sOBotShellModel.ShellNum > 0)
            {
                _sOBotShellModel.ShellNum--;
                _timeGun = 0;
                _botView.GunFire();
            }
        }
    }
    public void MachineGunFire() 
    {
        Debug.Log($"Test= {++_test}");
        if (_timeMachineGun == _maxTimeMachineGun)
        {
            if(_sOBotShellModel.BulletNum>0)
            {
                _sOBotShellModel.BulletNum--;
                _timeMachineGun = 0;
                _botView.MachineGunFire();
            }
        }
    }
    private void _reload()
    {
        _timeGun += _timeGun < _maxTimeGun ? 1 : 0;
        _timeMachineGun += _timeMachineGun < _maxTimeMachineGun ? 2 : 0;
    }
}
