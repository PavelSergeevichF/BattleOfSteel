using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class PanelGunsController : AmmunitionControllers
{
    private bool _firstStart = true;
    private bool _workingWithCannon;
    private float _caliberData;
    private float _glowTime;
    private int _longData;
    private int _speedData;
    private string _setWeapon = "Установить";
    private string _remoweWeapon = "Удалить";

    private Text _caliberText;
    private Text _longText;
    private Text _speedText;

    private GameObject _gunRawImage;
    private GameObject _machinGunRawImage;

    private PanelGunsView _panelGunsView;
    private PanelAmmunitionController _panelAmmunitionController;
    private EconomyController _economyController;
    private CurrencyModel _finishCost = new CurrencyModel();

    private SOEconomyData _economy;

    public PanelGunsController(PanelAmmunitionController panelAmmunitionController)
    {
        _panelAmmunitionController = panelAmmunitionController;
        _panelGunsView= panelAmmunitionController.GunsPanel.GetComponent<PanelGunsView>();
        _economyController = panelAmmunitionController.EconomyController;
        ActivePanelAmmunition = panelAmmunitionController.ActivePanelAmmunition;
        _glowTime = panelAmmunitionController.GlowTime;
        _economy = panelAmmunitionController.Economy;

        _caliberText = _panelGunsView.CaliberText;
        _longText = _panelGunsView.LongText;
        _speedText = _panelGunsView.SpeedText;

        _panelGunsView.GunSelect.onClick.AddListener(WorkingWithCannon);
        _panelGunsView.MachinGunSelect.onClick.AddListener(WorkingWithMachinGun);
        _panelGunsView.Select.onClick.AddListener(RemoveInstall);
        panelAmmunitionController.PanelAmmunitionView.Aply.onClick.AddListener(BayWeapon);

        _gunRawImage = _panelGunsView.GunRawImage;
        _machinGunRawImage = _panelGunsView.MachinGunRawImage;
    }

    public void Execute()
    {
        if (ActivePanelAmmunition== ActivePanelAmmunition.Gans)
        {
            CheckDataSlider();
            if (_firstStart)
            {
                _firstStart = false;
                CheckOnWeapon();
            }
        }
    }
    public void ChenchBot()
    {
        CheckOnWeapon();
        WorkingWithMachinGun();
    }
    private void CheckOnWeapon()
    {
        if (_panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberGun < 15 && _panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberMachineGun < 5)
        {
            SetStokWeapon();
        }
    }
    private void CheckDataSlider() 
    {
        if (_caliberData != _panelGunsView.CaliberSlider.value)
        {
            _caliberData = _panelGunsView.CaliberSlider.value;
            _panelGunsView.LongSlider.maxValue = (int)(_panelGunsView.CaliberSlider.value * 40);
            SetTempCannon(_caliberData);
            string _caliberDataStr = _caliberData.ToString("#.##");
            _panelGunsView.CaliberText.text = _caliberDataStr;
            UpDate();
        }
        if (_longData != (int)_panelGunsView.LongSlider.value)
        {
            _longData = (int)_panelGunsView.LongSlider.value;
            SetLongWeapon();
            string _caliberDataStr = _longData.ToString();
            _panelGunsView.LongText.text = _caliberDataStr;
            UpDate();
        }
        if (_speedData != (int)_panelGunsView.SpeedSlider.value)
        {
            _speedData = (int)_panelGunsView.SpeedSlider.value;
            string _caliberDataStr = _speedData.ToString();
            _panelGunsView.SpeedText.text = _caliberDataStr;
            UpDate();
        }
    }
    private void UpDate() 
    {
        SetPrice();
        ShowCost();
    }
    private void WorkingWithCannon()
    {
        _workingWithCannon=true;
        _panelGunsView.CaliberSlider.value = _panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberGun;
        _panelGunsView.CaliberSlider.maxValue = SetMaxCaliber();
        _panelGunsView.CaliberSlider.minValue = SetMinCaliber();
        _panelGunsView.LongSlider.value = _panelAmmunitionController.BotsData.ActivBot.GunModel.LongGun;
        _panelGunsView.LongSlider.minValue = 200;
        _panelGunsView.LongSlider.maxValue = (int)(_panelGunsView.CaliberSlider.value * 40);
        _panelGunsView.SpeedSlider.value = _panelAmmunitionController.BotsData.ActivBot.GunModel.FiringRateGun;
        SetTempCannon(_panelGunsView.CaliberSlider.value);
        _gunRawImage.SetActive(true);
        _machinGunRawImage.SetActive(false);
        if (_panelAmmunitionController.BotsData.ActivBot.GunModel.Gun)
        {
            _panelGunsView.ButtonSelectText.text = _remoweWeapon;
        }
        else 
        {
            _panelGunsView.ButtonSelectText.text = _setWeapon; 
        }
    }
    private void ShowCost()
    {
        string GoldBuy;
        string SilverBuy;
        string CopperBuy;

        string GoldRepair;
        string SilverRepair;
        string CopperRepair;
        _economyController.ShowPrice
            (
            out GoldBuy, out SilverBuy, out CopperBuy,
            out GoldRepair, out SilverRepair, out CopperRepair,
            _finishCost, _economy.Repair
            );

        _panelGunsView.PraceView.GoldBuy.text = GoldBuy;
        _panelGunsView.PraceView.SilverBuy.text = SilverBuy;
        _panelGunsView.PraceView.CopperBuy.text = CopperBuy;
        
        _panelGunsView.PraceView.GoldRepair.text = GoldRepair;
        _panelGunsView.PraceView.SilverRepair.text = SilverRepair;
        _panelGunsView.PraceView.CopperRepair.text = CopperRepair;
        CheckIsCanBay();
    }
    private void WorkingWithMachinGun()
    {
        _workingWithCannon = false;
        _panelGunsView.CaliberSlider.value = _panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberMachineGun;
        _panelGunsView.CaliberSlider.maxValue = 15f;
        _panelGunsView.CaliberSlider.minValue = 5f;
        _panelGunsView.LongSlider.value = _panelAmmunitionController.BotsData.ActivBot.GunModel.LongMachineGun;
        _panelGunsView.LongSlider.minValue = 100;
        _panelGunsView.LongSlider.maxValue = 1000;
        _panelGunsView.SpeedSlider.value = _panelAmmunitionController.BotsData.ActivBot.GunModel.FiringRateMachineGun;
        _panelGunsView.SpeedSlider.minValue = 300;
        _panelGunsView.SpeedSlider.maxValue = 1800;
        _gunRawImage.SetActive(false);
        _machinGunRawImage.SetActive(true);
        if (_panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun)
        {
            _panelGunsView.ButtonSelectText.text = _remoweWeapon;
        }
        else
        {
            _panelGunsView.ButtonSelectText.text = _setWeapon;
        }
    }
    private void SetLongWeapon()
    {
        if(_workingWithCannon)
        {
            Vector3 vector3 = _panelGunsView.GunBarrel.transform.localScale;
            vector3.z = _longData;
            _panelGunsView.GunBarrel.transform.localScale = vector3;
        }
        else 
        {
            Vector3 vector3 = _panelGunsView.MachinGunBarrel.transform.localScale;
            vector3.z = _longData/2+50;
            _panelGunsView.MachinGunBarrel.transform.localScale = vector3;
        }
    }
    private void RemoveInstall()
    {
        if (_workingWithCannon)
        {
            if (_panelAmmunitionController.BotsData.ActivBot.GunModel.Gun)
            {
                _panelAmmunitionController.BotsData.ActivBot.GunModel.Gun = false;
                _panelGunsView.ButtonSelectText.text = _setWeapon;
            }
            else
            {
                if (_panelAmmunitionController.BotsData.ActivBot.TypeBot == ETypeBot.LBT
                    && _panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun)
                {
                    _panelAmmunitionController.InfoHelpPanelController.SetInform
                    (_panelAmmunitionController.InfoHelpPanelController.SOInfoHelpTexts.AmmunitionHelp.CantInstallTwoInfo);
                }
                else
                {
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.Gun = true;
                    _panelGunsView.ButtonSelectText.text = _remoweWeapon;
                }
            }
        }
        else
        {
            if (_panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun)
            {
                 _panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun = false;
                _panelGunsView.ButtonSelectText.text = _setWeapon;
            }
            else
            {
                if (_panelAmmunitionController.BotsData.ActivBot.TypeBot == ETypeBot.LBT
                    && _panelAmmunitionController.BotsData.ActivBot.GunModel.Gun)
                {
                    _panelAmmunitionController.InfoHelpPanelController.SetInform
                    (_panelAmmunitionController.InfoHelpPanelController.SOInfoHelpTexts.AmmunitionHelp.CantInstallTwoInfo);
                }
                else
                {
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun = true;
                    _panelGunsView.ButtonSelectText.text = _remoweWeapon;
                } 
            }
        }
    }
    private void SetTempCannon(float caliber) 
    {
        if (caliber < 26)
        {
            _panelGunsView.SpeedSlider.maxValue = 1800;
            _panelGunsView.SpeedSlider.minValue = 30;
        }
        else 
        {
            if (caliber < 70)
            {
                _panelGunsView.SpeedSlider.maxValue = 80;
                _panelGunsView.SpeedSlider.minValue = 20;
            }
            else
            {
                if (caliber < 160)
                {
                    _panelGunsView.SpeedSlider.minValue = 1;
                    _panelGunsView.SpeedSlider.maxValue = (int)(80-(caliber - 70)*0.63f);
                }
                else 
                {
                    _panelGunsView.SpeedSlider.minValue = 1;
                    _panelGunsView.SpeedSlider.maxValue = 3;
                }
            }
        }
    }
    
    private void SetPrice()
    {
        CurrencyModel cost = new CurrencyModel();
        cost.SetCurrencyModel(0,0,0);
        float coeff = 0;

        CurrencyModel tempCost = new CurrencyModel();
        if (_workingWithCannon)
        {
            tempCost = SetPricePart(_caliberData, 1.2f, _panelGunsView.CaliberSlider.maxValue);
        }
        else 
        {
            tempCost = SetPricePart(_caliberData, 1.4f, _panelGunsView.CaliberSlider.maxValue);
        }
        cost.Gold += tempCost.Gold;
        cost.Silver += tempCost.Silver;
        cost.Copper += tempCost.Copper;

        tempCost = new CurrencyModel();
        if (_workingWithCannon)
        {
            coeff = 0.3f;
            if (_panelGunsView.LongSlider.maxValue > 5200)
            {
                coeff = 0.05f;
            }
            tempCost = SetPricePart(_longData, coeff, _panelGunsView.LongSlider.maxValue);
        }
        else
        {
            tempCost = SetPricePart(_longData, 0.07f, _panelGunsView.LongSlider.maxValue);
        }
        cost.Gold += tempCost.Gold;
        cost.Silver += tempCost.Silver;
        cost.Copper += tempCost.Copper;

        tempCost = new CurrencyModel();
        if (_panelGunsView.SpeedSlider.maxValue > 81)
        {
            coeff = 0.01f;
        }
        else
        {
            if (_panelGunsView.SpeedSlider.maxValue > 20)
            {
                coeff = 1;
            }
            else 
            {
                coeff = 1.5f;
            }
        }
        tempCost = SetPricePart(_speedData, coeff, _panelGunsView.SpeedSlider.maxValue);
        cost.Gold += tempCost.Gold;
        cost.Silver += tempCost.Silver;
        cost.Copper += tempCost.Copper;

        _finishCost = cost;
    }
    private CurrencyModel SetPricePart(float data, float coeff, float maxData)
    {
        CurrencyModel cost = new CurrencyModel();
        cost.SetCurrencyModel(0, 0, 0);
        float coefficient = 0;
        float level80 = maxData * 0.8f;
        float level40 = maxData * 0.4f;

        switch (_panelAmmunitionController.BotsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: coefficient = 1f; break;
            case ETypeBot.SBT: coefficient = 1.2f; break;
            case ETypeBot.LT: coefficient = 1.4f; break;
            case ETypeBot.TT: coefficient = 1.6f; break;
        }
        coefficient = coefficient * coeff;

        cost.Copper += (int)(data * coefficient);
        if (data > level40)
        {
            cost.Silver = (int)((data - level40) * coefficient);
        }
        if (data > level80)
        {
            cost.Gold = (int)((data - level80) * coefficient);
        }

        return cost;
    }
    private void BayWeapon()
    { 
        if(CheckIsCanBay() && ActivePanelAmmunition == ActivePanelAmmunition.Gans)
        {
            if(_panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun || _panelAmmunitionController.BotsData.ActivBot.GunModel.Gun)
            {
                Debug.Log($"Типо купил");//
            }
            else 
            {
                _panelAmmunitionController.InfoHelpPanelController.SetInform
                        (_panelAmmunitionController.InfoHelpPanelController.SOInfoHelpTexts.AmmunitionHelp.ImpossibleWithoutWeapons);
            }
        }
    }
    private void SetStokWeapon()
    {
        switch (_panelAmmunitionController.BotsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: 
                {
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.Gun = false;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun = true;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberMachineGun = 5f;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.LongMachineGun = 100;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.FiringRateMachineGun = 300;
                }
                break;
            case ETypeBot.SBT:
                {
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.Gun = true;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun = false;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberGun = 16f;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.LongGun = 200;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.FiringRateGun = 60;
                }
                break;
            case ETypeBot.LT:
                {
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.Gun = true;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun = true;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberMachineGun = 5f;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.LongMachineGun = 100;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.FiringRateMachineGun = 300;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberGun = 20f;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.LongGun = 200;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.FiringRateGun = 60;
                }
                break;
            case ETypeBot.TT:
                {
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.Gun = true;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.MachineGun = true;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberMachineGun = 5f;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.LongMachineGun = 100;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.FiringRateMachineGun = 300;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.CaliberGun = 30f;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.LongGun = 300;
                    _panelAmmunitionController.BotsData.ActivBot.GunModel.FiringRateGun = 60;
                }
                break;
        }
    }
    private bool CheckIsCanBay() => _economyController.CheckIsCanBay(_finishCost, _glowTime);
    private float SetMaxCaliber()
    {
        float maxCaliber = 0;
        switch (_panelAmmunitionController.BotsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: maxCaliber = 50f; break;
            case ETypeBot.SBT: maxCaliber = 100f; break;
            case ETypeBot.LT: maxCaliber = 130f; break;
            case ETypeBot.TT: maxCaliber = 210f; break;
        }
        return maxCaliber;
    }
    private float SetMinCaliber()
    {
        float minCaliber = 0;
        switch (_panelAmmunitionController.BotsData.ActivBot.TypeBot)
        {
            case ETypeBot.LBT: minCaliber = 16f; break;
            case ETypeBot.SBT: minCaliber = 16f; break;
            case ETypeBot.LT: minCaliber = 20f; break;
            case ETypeBot.TT: minCaliber = 30f; break;
        }
        return minCaliber;
    }
}