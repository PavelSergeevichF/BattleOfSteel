using UnityEngine;

public class BotSetDamageController 
{
    private float _distancToTheEnemy;
    private float _caliberGun;
    private int _longGun;
    private float _caliberMachineGun;
    private int _longMachineGun;

    public BotSetDamageController(BotModel _sOBotModel)
    {
        _caliberGun = _sOBotModel.CaliberGun;
        _longGun = _sOBotModel.LongGun;
        _caliberMachineGun = _sOBotModel.CaliberMachineGun;
        _longMachineGun = _sOBotModel.LongMachineGun;
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
