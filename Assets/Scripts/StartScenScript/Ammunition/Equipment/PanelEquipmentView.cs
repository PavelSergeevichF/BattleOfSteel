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
    public Button MuzzleBrakeInformation => _muzzleBrakeInformation;
    public Button AutomaticChargingInformation => _automaticChargingInformation;
    public Button ImprovedOpticsInformation => _improvedOpticsInformation;
    public Button ReinforcedBrakesInformation => _reinforcedBrakesInformation;
    public Button FuelAdditivesInformation => _fuelAdditivesInformation;
    public Button EnhancedChargeInformation => _enhancedChargeInformation;
    public Button UraniumShellsInformation => _uraniumShellsInformation;
    public Button TungstenCartridgesInformation => _tungstenCartridgesInformation;

    [Header("Buttons")]
    public Toggle MuzzleBrakeToggle;
    public Toggle AutomaticChargingToggle;
    public Toggle ImprovedOpticsToggle;
    public Toggle ReinforcedBrakesToggle;
    public Toggle FuelAdditivesToggle;
    public Toggle EnhancedChargeToggle;
    public Toggle UraniumShellsToggle;
    public Toggle TungstenCartridgesToggle;
}
