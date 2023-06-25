using System.Collections.Generic;
using UnityEngine;

public class BotGetDamageView : MonoBehaviour
{
    [SerializeField] private BotModel _sOBotModel;
    private BotGetDamageController _botGetDamageController;
    void Start()
    {
        _botGetDamageController = new BotGetDamageController(_sOBotModel);
    }

    public void Damage(int dmg)
    {
        _botGetDamageController.Damage(dmg);
    }
}
