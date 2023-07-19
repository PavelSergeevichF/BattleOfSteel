using UnityEngine;

public class SetMassArmorController
{
    private BotModel _activBot;
    private SizeBot _sizeBot;
    private const float _metalDensity = 7.9f;

    public SetMassArmorController(BotModel activBot)
    {
        _activBot = activBot;
    }
    public void SetDataMassArmor()
    {
        float volumeBot = 0;
        _sizeBot = new SizeBot();
        ArmorPart armorPart = new ArmorPart();
        armorPart = _activBot.ArmorModel.ArmorBody;
        _sizeBot = _activBot.SizeBot;
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Top].MM, _sizeBot.GetLongBody(), _sizeBot.GetWidthBody());
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Bottom].MM, _sizeBot.GetLongBody(), _sizeBot.GetWidthBody());
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Front].MM, _sizeBot.GetHeightBody(), _sizeBot.GetWidthBody());
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Back].MM, _sizeBot.GetHeightBody(), _sizeBot.GetWidthBody());
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Flank].MM, _sizeBot.GetHeightBody(), _sizeBot.GetLongBody())*2;

        armorPart = new ArmorPart();
        armorPart = _activBot.ArmorModel.ArmorTower;
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Top].MM, _sizeBot.GetLongBody(), _sizeBot.GetWidthBody());
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Bottom].MM, _sizeBot.GetLongBody(), _sizeBot.GetWidthBody());
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Front].MM, _sizeBot.GetHeightBody(), _sizeBot.GetWidthBody());
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Back].MM, _sizeBot.GetHeightBody(), _sizeBot.GetWidthBody());
        volumeBot += VolumeCalculation(armorPart.PlanSurfaces[ePlanName.Flank].MM, _sizeBot.GetHeightBody(), _sizeBot.GetLongBody()) * 2;

        _activBot.MassBotPart.MassArmor= volumeBot* _metalDensity;
    }
    private float VolumeCalculation(int a, float b, float c)
    {
        float A = a;
        A = A * 0.001f;
        return A* b*c;
    }
}

