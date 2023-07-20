using UnityEngine.UI;
using UnityEngine;

public class PanelEngineController
{
    private ActivePanelAmmunition _activePanelAmmunition;
    private CurrencyModel _finishCost = new CurrencyModel();
    private PanelEngineView _panelEngineView;
    private SOBotsData _botsData;
    private SOEconomyData _economy;
    private CurrencyUserController _currencyUserController;
    private EconomyController _economyController;
    private MassController _massController;

    public PanelEngineController(PanelAmmunitionController panelAmmunitionController)
    {
        _panelEngineView = panelAmmunitionController.EnginePanel.GetComponent<PanelEngineView>();
        _botsData = panelAmmunitionController.BotsData;
        _economy = panelAmmunitionController.Economy;
        _currencyUserController = panelAmmunitionController.CurrencyUserController;
        _economyController = panelAmmunitionController.EconomyController;
        _massController = panelAmmunitionController.MassController;
        _activePanelAmmunition = panelAmmunitionController.ActivePanelAmmunition;

        panelAmmunitionController.PanelAmmunitionView.Aply.onClick.AddListener(BayEngine);
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

        _panelEngineView.PraceView.GoldBuy.text = GoldBuy;
        _panelEngineView.PraceView.SilverBuy.text = SilverBuy;
        _panelEngineView.PraceView.CopperBuy.text = CopperBuy;

        _panelEngineView.PraceView.GoldRepair.text = GoldRepair;
        _panelEngineView.PraceView.SilverRepair.text = SilverRepair;
        _panelEngineView.PraceView.CopperRepair.text = CopperRepair;
        //CheckIsCanBay();
    }

   private void BayEngine()
    {
        //if (CheckIsCanBay() && _activePanelAmmunition == ActivePanelAmmunition.Engine)
        {
            //_currencyUserController.Bay(_costArmor.FinishCost.Gold, _costArmor.FinishCost.Silver, _costArmor.FinishCost.Copper);
            //SetBotArmor();
            ShowCost();
            //SetMassArmor();
        }
    }
    //private bool CheckIsCanBay() => _economyController.CheckIsCanBay(_costArmor.FinishCost, _panelArmorView.GlowTime);
}
