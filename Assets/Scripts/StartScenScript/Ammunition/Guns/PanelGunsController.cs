using UnityEngine;
using UnityEngine.UI;

public class PanelGunsController
{
    private bool _workingWithCannon;
    private float _caliberData;
    private float _glowTime;
    private int _longData;
    private int _speedData;

    private Text _caliberText;
    private Text _longText;
    private Text _speedText;

    private GameObject _gunRawImage;
    private GameObject _machinGunRawImage;

    private PanelGunsView _panelGunsView;
    private PanelAmmunitionController _panelAmmunitionController;
    private EconomyController _economyController;
    private CurrencyModel _finishCost = new CurrencyModel();

    public ActivePanelAmmunition ActivePanelAmmunition;

    public PanelGunsController(PanelAmmunitionController panelAmmunitionController)
    {
        _panelAmmunitionController = panelAmmunitionController;
        _panelGunsView= panelAmmunitionController.GunsPanel.GetComponent<PanelGunsView>();
        _economyController = panelAmmunitionController.EconomyController;
        ActivePanelAmmunition = panelAmmunitionController.ActivePanelAmmunition;
        _glowTime = panelAmmunitionController.GlowTime;

        _caliberText = _panelGunsView.CaliberText;
        _longText = _panelGunsView.LongText;
        _speedText = _panelGunsView.SpeedText;

        _panelGunsView.GunSelect.onClick.AddListener(WorkingWithCannon);
        _panelGunsView.MachinGunSelect.onClick.AddListener(WorkingWithMachinGun);
        panelAmmunitionController.PanelAmmunitionView.Aply.onClick.AddListener(BayWeapon);

        _gunRawImage = _panelGunsView.GunRawImage;
        _machinGunRawImage = _panelGunsView.MachinGunRawImage;
    }

    public void Execute()
    {
        CheckDataSlider();
    }
    public void ChenchBot()
    {
        WorkingWithMachinGun();
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
        //_finishCost
    }
    private void BayWeapon()
    { 
        if(CheckIsCanBay() && ActivePanelAmmunition == ActivePanelAmmunition.Engine)
        {
            Debug.Log($"Типо купил");//
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
