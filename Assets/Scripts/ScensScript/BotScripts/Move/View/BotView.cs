using UnityEngine;

public class BotView : MonoBehaviour
{
    public Collider TerrainCollider;
    [SerializeField] private bool _pleer=true;
    [SerializeField] private GameObject _bodyBot;
    [SerializeField] private GameObject _towerBot;
    [SerializeField] private GameObject _gunBot;
    [SerializeField] private GameObject _targetGameObject;
    [SerializeField] private GameObject _startPointLF;
    [SerializeField] private GameObject _startPointRF;
    [SerializeField] private GameObject _startPointLB;
    [SerializeField] private GameObject _startPointRB;
    [SerializeField] private GameObject _targetPointLF;
    [SerializeField] private GameObject _targetPointRF;
    [SerializeField] private GameObject _targetPointLB;
    [SerializeField] private GameObject _targetPointRB;

    [SerializeField] private JoysticView _joysticView;
    [SerializeField] private SOBotModel _sOBotModel;
    [SerializeField] private SOBotConnect _sOBotConnect;
    [SerializeField] private SOBotPosition _sOBotPosition;
    [SerializeField] private SOCameraConnect _sOCameraConnect;
    private BotController _botController;
    private BotMoveController _botMoveController;
    private CharacterController _characterController;
    private BotFireController _botFireController;
    private BotSetDamageController _botSetDamageController;
    private TowerRotationController _towerRotationController;
    private GunRotationController _gunRotationController;
    private ObjectRotationController _objectRotationController;



    private void Start()
    {
        _sOBotConnect.bot = _bodyBot;
        _characterController = GetComponent<CharacterController>();
        _botController = new BotController(this, _sOBotPosition);
        _botMoveController = new BotMoveController(this, _sOBotModel, _characterController, _joysticView, _pleer);
        _botSetDamageController = new BotSetDamageController(_sOBotModel);
        _botFireController = new BotFireController(_sOCameraConnect.Camera, _sOBotModel.Distance, _botSetDamageController);
        _objectRotationController = new ObjectRotationController(_sOCameraConnect, _sOBotModel, _targetGameObject);
        _towerRotationController = new TowerRotationController(_sOBotModel);
        _gunRotationController = new GunRotationController(_sOBotModel);
    }

    private void Update()
    {
        _botController.Update();
        _botMoveController.Update();
        _objectRotationController.Update();
        _towerRotationController.Update();
        _gunRotationController.Update();

    }
    private void FixedUpdate()
    {
        _botMoveController.FixedUpdate();
    }
    public GameObject BodyBot => _bodyBot;
    public GameObject TowerBot => _towerBot;
    public GameObject GunBot => _gunBot;
    public Transform StartPointLF => _startPointLF.transform;
    public Transform StartPointRF => _startPointRF.transform;
    public Transform StartPointLB => _startPointLB.transform;
    public Transform StartPointRB => _startPointRB.transform;
    public Transform TargetPointLF => _targetPointLF.transform;
    public Transform TargetPointRF => _targetPointRF.transform;
    public Transform TargetPointLB => _targetPointLB.transform;
    public Transform TargetPointRB => _targetPointRB.transform;

    public void GunFire() => _botFireController.GunFire();
    public void MachineGunFire() => _botFireController.MachineGunFire();
    public SOBotModel GetSOBotModel() => _sOBotModel;
    public SOBotConnect GetSOBotConnect() => _sOBotConnect;
}
