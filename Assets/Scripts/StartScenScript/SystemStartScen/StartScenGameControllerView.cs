using UnityEngine;

public class StartScenGameControllerView : MonoBehaviour
{
    [SerializeField] private MainButtonPanelView _mainButtonPanelView;
    [SerializeField] private PanelMenuView _panelMenuView; 
    [SerializeField] private PanelAmmunitionView _panelAmmunitionView;
    [SerializeField] private PanelHangarView _panelHangarView;
    [SerializeField] private MenuAccountView _menuAccountView;
    [SerializeField] private SOUserData _sOUserData;
    [SerializeField] private SelectAuthorizationOrRegistrationView _selectAuthorizationOrRegistrationView;

    private StartScenControllers _startScenControllers;

    public MainButtonPanelView MainButtonPanelView => _mainButtonPanelView;
    public PanelMenuView PanelMenuView => _panelMenuView;
    public PanelAmmunitionView PanelAmmunitionView => _panelAmmunitionView;
    public PanelHangarView PanelHangarView => _panelHangarView;
    public MenuAccountView MenuAccountView => _menuAccountView;
    public SOUserData SOUserData => _sOUserData;
    public SelectAuthorizationOrRegistrationView SelectAuthorizationOrRegistrationView => _selectAuthorizationOrRegistrationView;

    private void Awake()
    {
        _startScenControllers = new StartScenControllers();
        new StartScenGameInit(_startScenControllers, this);

        _startScenControllers.Awake();
    }

    private void Start()  => _startScenControllers.Init();

    private void Update() => _startScenControllers.Execute();

    private void FixedUpdate() =>  _startScenControllers.FixedExecute();

    private void LateUpdate() => _startScenControllers.LateExecute();

    private void OnDestroy() => _startScenControllers.Cleanup();
    public void OnDestroyBetwenLevels() =>  _startScenControllers.Cleanup();
}
