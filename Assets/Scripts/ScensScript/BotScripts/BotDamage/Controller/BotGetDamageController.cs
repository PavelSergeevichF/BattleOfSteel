using UnityEngine;
using System.Collections.Generic;

public class BotGetDamageController : MonoBehaviour
{
    private SOBotModel _sOBotModel;

    public BotGetDamageController(SOBotModel sOBotModel)
    {
        _sOBotModel = sOBotModel;
    }
    public void Damage(int dmg)
    {
        if (_sOBotModel.HP>0)
        { 
            if(_sOBotModel.HP> dmg)
            {
                _sOBotModel.HP -= dmg;
            }
            else 
            {
                _sOBotModel.HP = 0;
            }
        }
    }
}
