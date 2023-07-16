using UnityEngine.UI;

public class CostArmor : Costs
{
    private ePartBotName _ePartBotName;
    private ePlanName _ePlanName;
    private eTypeArmor _eTypeArmor;
    private BotModel _tempBotModel = new BotModel();
    private Slider _armorThicknessSlider;
    private int _tempSliderVolue=0;
    private BotModel _botModel;

    public delegate void SentChangesCost();
    public event SentChangesCost ChangesCost;

    public CostArmor(ePartBotName ePartBotName, ePlanName ePlanName, eTypeArmor eTypeArmor, ArmorDataModel armorDataModel, Slider armorThicknessSlider, BotModel botModel)
    {
        _eTypeArmor = eTypeArmor;
        _ePartBotName = ePartBotName;
        _ePlanName = ePlanName;
        _botModel = botModel;
        _armorThicknessSlider = armorThicknessSlider;
        _tempBotModel.NameBot = "-";
    }

    public void SetPart(ePartBotName ePartBotName)
    {
        _ePartBotName = ePartBotName;
    }
    public void SetPlan(ePlanName ePlanName) 
    {
        _ePlanName = ePlanName;
    }
    public void SetTypeArmor(eTypeArmor eTypeArmor) 
    {
        _eTypeArmor = eTypeArmor;
    }

    public void ShowPrice(out int Gold, out int Silver, out int Copper)
    {
        Gold = base._finishCost.Gold;
        Silver = base._finishCost.Silver;
        Copper = base._finishCost.Copper;
    }

    public void Execute()
    {
        if (_tempBotModel.NameBot != _botModel.NameBot)
        {
            _tempBotModel = _botModel;
        }

        if (_tempSliderVolue != (int)_armorThicknessSlider.value)
        {
            _tempSliderVolue = (int)_armorThicknessSlider.value;
            ChangesCost?.Invoke();
            SetCost();
        }
    }

    //Мы посчитали соимость брони на боте, надо посчитать с изменениями
    private void SetCost()
    {
        base._finishCost.Gold = base._finishCost.Silver = base._finishCost.Copper = 0;
        foreach (var planSurfaces in _tempBotModel.ArmorModel.ArmorTower.PlanSurfaces)
        {
            SetCostPart(_eTypeArmor, _tempBotModel.TypeBot, ePartBotName.Tower, planSurfaces.PlanName);
            AddCost(planSurfaces.Cost);
        }
        foreach (var planSurfaces in _tempBotModel.ArmorModel.ArmorBody.PlanSurfaces)
        {
            SetCostPart(_eTypeArmor, _tempBotModel.TypeBot, ePartBotName.Body, planSurfaces.PlanName);
            AddCost(planSurfaces.Cost);
        }
    }
    private void SetCostPart(eTypeArmor eTypeArmor, ETypeBot eTypeBot, ePartBotName ePartBotName, ePlanName ePlanName)
    {
        base._coefficient = 1f;
        float tempSliderMax = _armorThicknessSlider.maxValue;
        float tempSlider = _armorThicknessSlider.value;
        float level80= tempSliderMax * 0.8f;
        float level40 = tempSliderMax * 0.4f;
        CurrencyModel cost = new CurrencyModel();

        switch (eTypeArmor)
        {
            case eTypeArmor.Easy: base._coefficient += 0f; break;
            case eTypeArmor.Medium: base._coefficient += 0.3f; break;
            case eTypeArmor.Hard: base._coefficient += 0.6f; break;
        }
        switch (eTypeBot)
        {
            case ETypeBot.LBT: base._coefficient += 0f; break;
            case ETypeBot.SBT: base._coefficient += 0.5f; break;
            case ETypeBot.LT: base._coefficient += 1f; break;
            case ETypeBot.TT: base._coefficient += 1.5f; break;
        }
        switch (ePartBotName)
        {
            case ePartBotName.Tower: base._coefficient += 0f; break;
            case ePartBotName.Body: base._coefficient += 1f; break;
        };
        switch (ePlanName)
        {
            case ePlanName.Front: base._coefficient += 0f; break;
            case ePlanName.Back: base._coefficient += 0f; break;
            case ePlanName.Flank: base._coefficient += 1f; break;
            case ePlanName.Top: base._coefficient += 1.5f; break;
            case ePlanName.Bottom: base._coefficient += 1.5f; break;
        };

        cost.Copper = (int)(tempSlider * base._coefficient);
        if (tempSlider > level40)
        {
            cost.Silver= (int)((tempSlider - level40) * base._coefficient);
        }
        if (tempSlider > level80)
        {
            cost.Gold = (int)((tempSlider - level80) * base._coefficient);
        }
        SetArmorPlan(ePartBotName, ePlanName, cost, (int)_armorThicknessSlider.value);
    }
    private void SetArmorPlan(ePartBotName ePartBotName, ePlanName ePlanName, CurrencyModel cost, int MM)
    {
        if (ePartBotName == ePartBotName.Tower)
        {
            _tempBotModel.ArmorModel.ArmorTower.PlanSurfaces[(int)ePlanName].MM = MM;
            _tempBotModel.ArmorModel.ArmorTower.PlanSurfaces[(int)ePlanName].Cost = cost;
            _tempBotModel.ArmorModel.ArmorTower.PlanSurfaces[(int)ePlanName].PlanName = ePlanName;
        }
        else 
        {
            _tempBotModel.ArmorModel.ArmorBody.PlanSurfaces[(int)ePlanName].MM = MM;
            _tempBotModel.ArmorModel.ArmorBody.PlanSurfaces[(int)ePlanName].Cost = cost;
            _tempBotModel.ArmorModel.ArmorBody.PlanSurfaces[(int)ePlanName].PlanName = ePlanName;
        }
        
    }
    private void AddCost(CurrencyModel cost)
    {
        base._finishCost.Gold += cost.Gold;
        base._finishCost.Silver += cost.Silver;
        base._finishCost.Copper += cost.Copper;
    }
}