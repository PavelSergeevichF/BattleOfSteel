using UnityEngine;

public class MassController : IExecute
{
    private SOUserData _sOUserData;

    public MassController(SOUserData sOUserData)
    {
        _sOUserData = sOUserData;
    }

    public void Execute()
    {
    }

    public void SetMass()
    {
        _sOUserData.BotsData.ActivBot.MassBotFinish =
            _sOUserData.BotsData.ActivBot.MassBotPart.MassArmor +
             _sOUserData.BotsData.ActivBot.MassBotPart.MassEngine +
             _sOUserData.BotsData.ActivBot.MassBotPart.MassGun +
             _sOUserData.BotsData.ActivBot.MassBotPart.MassMachineGun +
             _sOUserData.BotsData.ActivBot.MassBotPart.MassAmmunition;
    }
}
