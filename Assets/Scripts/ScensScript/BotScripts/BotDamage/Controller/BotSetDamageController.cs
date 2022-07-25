using UnityEngine;

public class BotSetDamageController 
{
    private SOBotGunModel _sOBotGunModel;
    private float _distancToTheEnemy;
    private float _caliberGun;
    private int _longGun;
    private float _caliberMachineGun;
    private int _longMachineGun;

    public BotSetDamageController(SOBotModel _sOBotModel)
    {
        _sOBotGunModel = _sOBotModel.GunsModel;
        _caliberGun = _sOBotGunModel.CaliberGun;
        _longGun = _sOBotGunModel.LongGun;
        _caliberMachineGun = _sOBotGunModel.CaliberMachineGun;
        _longMachineGun = _sOBotGunModel.LongMachineGun;
    }
    public void SetDataFire(EGunTaype taype, float dist)
    {
        _distancToTheEnemy = dist;
        switch (taype)
        {
            case EGunTaype.Gun:
                _setGunDamage();
                break;
            case EGunTaype.MachineGun:
                _setMachineGunDamage();
                break;
        };

        Debug.Log($"Distance {_distancToTheEnemy}");
    }
    private void _setGunDamage()
    { }
    private void _setMachineGunDamage()
    { }
}
