using UnityEngine;

public class BotView : MonoBehaviour
{
    public Collider TerrainCollider;
    [SerializeField] private bool _pleer=true;
    [SerializeField] private GameObject _bodyBot;
    [SerializeField] private GameObject _towerBot;
    [SerializeField] private GameObject _gunBot;
    [SerializeField] private Transform _startPointRayCast;
    [SerializeField] private ButtonView _buttonVierw;
    [SerializeField] private SOBotModel _sOBotModel;
    [SerializeField] private SOBotConnect _sOBotConnect;
    [SerializeField] private SOBotPosition _sOBotPosition;
    [SerializeField] private SOCameraConnect _sOCameraConnect;
    private BotController _botController;
    private BotMoveController _botMoveController;
    private CharacterController _characterController;
    private BotFireController _botFireController;
    private BotSetDamageController _botSetDamageController;


    private void Start()
    {
        _sOBotConnect.bot = _bodyBot;
        _characterController = GetComponent<CharacterController>();
        _botController = new BotController(this);
        _botMoveController = new BotMoveController(this, _sOBotModel, _characterController, _buttonVierw, _pleer);
        _botSetDamageController = new BotSetDamageController(_sOBotModel);
        _botFireController = new BotFireController(_sOCameraConnect.Camera, _sOBotModel.Distance, _botSetDamageController);
    }

    private void Update()
    {
        _botController.Update();
        _botMoveController.Update();
        if(_pleer)
        {
            _sOBotPosition.BotPosition = this.transform.position;
        }
    }
    private void FixedUpdate()
    {
        _botMoveController.FixedUpdate();
    }
    public GameObject BodyBot => _bodyBot;
    public GameObject TowerBot => _towerBot;
    public GameObject GunBot => _gunBot;
    public Transform GetTransformPosition() => _startPointRayCast;
    public void GunFire() => _botFireController.GunFire();
    public void MachineGunFire() => _botFireController.MachineGunFire();
    public void SetStartRayPosition(Transform pos)
    {
        _startPointRayCast = pos;
    }
    public SOBotModel GetSOBotModel() => _sOBotModel;
    public SOBotConnect GetSOBotConnect() => _sOBotConnect;
}
