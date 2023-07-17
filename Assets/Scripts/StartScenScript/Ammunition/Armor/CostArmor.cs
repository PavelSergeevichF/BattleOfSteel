using System.Collections.Generic;
using UnityEngine.UI;

public class CostArmor : Costs
{
    private ePartBotName _ePartBotName;
    private ePlanName _ePlanName;
    private eTypeArmor _eTypeArmor;
    private ArmorDataModel _tempArmorDataModel = new ArmorDataModel
        (eTypeArmor.Easy,0,"-", 
        new ArmorPart( new Dictionary<ePlanName, PlanSurface>()), 
        new ArmorPart(new Dictionary<ePlanName, PlanSurface>()));
    private Slider _armorThicknessSlider;
    private int _tempSliderVolue=0;
    private BotModel _botModel;
    public CurrencyModel FinishCost;

    public delegate void SentChangesCost();
    public event SentChangesCost ChangesCost;

    public CostArmor(ePartBotName ePartBotName, ePlanName ePlanName, eTypeArmor eTypeArmor, ArmorDataModel armorDataModel, Slider armorThicknessSlider, BotModel botModel)
    {
        _eTypeArmor = eTypeArmor;
        _ePartBotName = ePartBotName;
        _ePlanName = ePlanName;
        _botModel = botModel;
        _armorThicknessSlider = armorThicknessSlider;
        _tempArmorDataModel.NameBotFofCheck = "-";
    }

    public void SetPart(ePartBotName ePartBotName)
    {
        _ePartBotName = ePartBotName;
        if (_tempArmorDataModel.ArmorBody.PlanSurfaces.Count >0)
            SetSlider();
    }
    public void SetPlan(ePlanName ePlanName) 
    {
        _ePlanName = ePlanName;
        if(_tempArmorDataModel.ArmorBody.PlanSurfaces.Count >0)
           SetSlider();
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
        if (_tempArmorDataModel.NameBotFofCheck != _botModel.NameBot)
        {
            _tempArmorDataModel = new ArmorDataModel();
            _tempArmorDataModel.ArmorTower = new ArmorPart(new Dictionary<ePlanName, PlanSurface>());
            _tempArmorDataModel.ArmorBody = new ArmorPart(new Dictionary<ePlanName, PlanSurface>());
            CreatListSurface(_tempArmorDataModel.ArmorTower);
            CreatListSurface(_tempArmorDataModel.ArmorBody);
            foreach (var plan in _botModel.ArmorModel.ArmorTower.PlanSurfaces)
            {
                _tempArmorDataModel.ArmorTower.PlanSurfaces[plan.Key] = plan.Value;
            }
            foreach (var plan in _botModel.ArmorModel.ArmorBody.PlanSurfaces)
            {
                _tempArmorDataModel.ArmorBody.PlanSurfaces[plan.Key] = plan.Value;
            }
            _tempArmorDataModel.NameBotFofCheck = _botModel.NameBot;
            SetCostBot();
            ChangesCost?.Invoke();
        }

        if (_tempSliderVolue != (int)_armorThicknessSlider.value)
        {
            _tempSliderVolue = (int)_armorThicknessSlider.value;
            SetCost();
            ChangesCost?.Invoke();
        }
    }
    private void CreatListSurface(ArmorPart armorPart)
    {
        armorPart.PlanSurfaces.Add(ePlanName.Top, new PlanSurface(ePlanName.Top, 0, new CurrencyModel()));
        armorPart.PlanSurfaces.Add(ePlanName.Bottom, new PlanSurface(ePlanName.Bottom, 0, new CurrencyModel()));
        armorPart.PlanSurfaces.Add(ePlanName.Front, new PlanSurface(ePlanName.Front, 0, new CurrencyModel()));
        armorPart.PlanSurfaces.Add(ePlanName.Back, new PlanSurface(ePlanName.Back, 0, new CurrencyModel()));
        armorPart.PlanSurfaces.Add(ePlanName.Flank, new PlanSurface(ePlanName.Flank, 0, new CurrencyModel()));
    }

    private void SetSlider()
    {
        if (_ePartBotName == ePartBotName.Body)
        {
            _armorThicknessSlider.value = _tempArmorDataModel.ArmorBody.PlanSurfaces[_ePlanName].MM;
        }
        else
        {
            _armorThicknessSlider.value = _tempArmorDataModel.ArmorTower.PlanSurfaces[_ePlanName].MM;
        }
    }

    private void SetCost()
    {
        SetArmorPlanSlider(_ePartBotName, _ePlanName, _tempSliderVolue);
        SetCostBot();
    }
    private void SetCostBot()
    {
        base._finishCost.Gold = base._finishCost.Silver = base._finishCost.Copper = 0;
        foreach (var planSurfaces in _tempArmorDataModel.ArmorTower.PlanSurfaces)
        {
            SetCostPart(_eTypeArmor, _botModel.TypeBot, ePartBotName.Tower, planSurfaces.Key, _tempArmorDataModel.ArmorTower.PlanSurfaces[planSurfaces.Key].MM);
            AddCost(_tempArmorDataModel.ArmorTower.PlanSurfaces[planSurfaces.Key].Cost);
        }
        foreach (var planSurfaces in _tempArmorDataModel.ArmorBody.PlanSurfaces)
        {
            SetCostPart(_eTypeArmor, _botModel.TypeBot, ePartBotName.Body, planSurfaces.Key, _tempArmorDataModel.ArmorBody.PlanSurfaces[planSurfaces.Key].MM);
            AddCost(_tempArmorDataModel.ArmorBody.PlanSurfaces[planSurfaces.Key].Cost);
        }
        ///--------------------------------------

        FinishCost = new CurrencyModel();
        FinishCost.SetCurrencyModel(base._finishCost.Gold, base._finishCost.Silver, base._finishCost.Copper);
    }
    private void SetCostPart(eTypeArmor eTypeArmor, ETypeBot eTypeBot, ePartBotName ePartBotName, ePlanName ePlanName, float dataMM)
    {
        base._coefficient = 1f;
        float tempSliderMax = _armorThicknessSlider.maxValue;
        float _dataMM = dataMM;
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

        cost.Copper = (int)(_dataMM * base._coefficient);
        if (_dataMM > level40)
        {
            cost.Silver= (int)((_dataMM - level40) * base._coefficient);
        }
        if (_dataMM > level80)
        {
            cost.Gold = (int)((_dataMM - level80) * base._coefficient);
        }
        SetArmorPlan(ePartBotName, ePlanName, cost, (int)_dataMM);
    }
    private void SetArmorPlanSlider(ePartBotName ePartBotName, ePlanName ePlanName, int MM)
    {
        if (ePartBotName == ePartBotName.Tower)
        {
            PlanSurface tmp = new PlanSurface(
                _tempArmorDataModel.ArmorTower.PlanSurfaces[ePlanName].PlanName,MM,
                _tempArmorDataModel.ArmorTower.PlanSurfaces[ePlanName].Cost);
            _tempArmorDataModel.ArmorTower.PlanSurfaces.Remove(ePlanName);
            _tempArmorDataModel.ArmorTower.PlanSurfaces.Add(ePlanName, tmp);
        }
        else
        {
            PlanSurface tmp = new PlanSurface(
                _tempArmorDataModel.ArmorBody.PlanSurfaces[ePlanName].PlanName, MM,
                _tempArmorDataModel.ArmorBody.PlanSurfaces[ePlanName].Cost);
            _tempArmorDataModel.ArmorBody.PlanSurfaces.Remove(ePlanName);
            _tempArmorDataModel.ArmorBody.PlanSurfaces.Add(ePlanName, tmp);
        }
    }
    private void SetArmorPlan(ePartBotName ePartBotName, ePlanName ePlanName, CurrencyModel cost, int MM)
    {
        if (ePartBotName == ePartBotName.Tower)
        {
            _tempArmorDataModel.ArmorTower.PlanSurfaces[ePlanName].SetMM(MM);
            _tempArmorDataModel.ArmorTower.PlanSurfaces[ePlanName].SetCost(cost);
            _tempArmorDataModel.ArmorTower.SetListForShowe();

        }
        else 
        {
            _tempArmorDataModel.ArmorBody.PlanSurfaces[ePlanName].SetMM(MM);
            _tempArmorDataModel.ArmorBody.PlanSurfaces[ePlanName].SetCost(cost);
            _tempArmorDataModel.ArmorBody.SetListForShowe();
        }
        
    }
    private void AddCost(CurrencyModel cost)
    {
        base._finishCost.Gold += cost.Gold;
        base._finishCost.Silver += cost.Silver;
        base._finishCost.Copper += cost.Copper;
    }
}