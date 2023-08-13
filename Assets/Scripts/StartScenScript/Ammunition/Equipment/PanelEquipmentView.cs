using UnityEngine.UI;
using UnityEngine;

public class PanelEquipmentView : AmmunitionsElement
{
    [Header("Buttons")]
    [SerializeField] private Button _muzzleBrakeInformation;
    [SerializeField] private Button _automaticChargingInformation;
    [SerializeField] private Button _improvedOpticsInformation;
    [SerializeField] private Button _reinforcedBrakesInformation;
    [SerializeField] private Button _fuelAdditivesInformation;
    [SerializeField] private Button _enhancedChargeInformation;
    [SerializeField] private Button _uraniumShellsInformation;
    [SerializeField] private Button _tungstenCartridgesInformation;

    [Header("Toggles")]
    [SerializeField] private Toggle _muzzleBrakeToggle;
    [SerializeField] private Toggle _automaticChargingToggle;
    [SerializeField] private Toggle _improvedOpticsToggle;
    [SerializeField] private Toggle _reinforcedBrakesToggle;
    [SerializeField] private Toggle _fuelAdditivesToggle;
    [SerializeField] private Toggle _enhancedChargeToggle;

    public Button MuzzleBrakeInformation => _muzzleBrakeInformation;
    public Button AutomaticChargingInformation => _automaticChargingInformation;
    public Button ImprovedOpticsInformation => _improvedOpticsInformation;
    public Button ReinforcedBrakesInformation => _reinforcedBrakesInformation;
    public Button FuelAdditivesInformation => _fuelAdditivesInformation;
    public Button EnhancedChargeInformation => _enhancedChargeInformation;
    public Button UraniumShellsInformation => _uraniumShellsInformation;
    public Button TungstenCartridgesInformation => _tungstenCartridgesInformation;

    public Toggle MuzzleBrakeToggle => _muzzleBrakeToggle;
    public Toggle AutomaticChargingToggle => _automaticChargingToggle;
    public Toggle ImprovedOpticsToggle => _improvedOpticsToggle;
    public Toggle ReinforcedBrakesToggle => _reinforcedBrakesToggle;
    public Toggle FuelAdditivesToggle => _fuelAdditivesToggle;
    public Toggle EnhancedChargeToggle => _enhancedChargeToggle;
}
