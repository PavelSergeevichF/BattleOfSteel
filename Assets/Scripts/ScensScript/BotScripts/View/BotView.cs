using UnityEngine;

public class BotView : MonoBehaviour
{
    [SerializeField] private GameObject _bodyBot;
    [SerializeField] private GameObject _towerBot;
    [SerializeField] private GameObject _gunBot;
    [SerializeField] private Transform _startPointRayCast;
    [SerializeField] private ButtonView _buttonVierw;
    [SerializeField] private SOBotModel _sOBotModel;
    [SerializeField] private SOBotPosition _sOBotPosition;
    private BotController _botController;
    private BotMoveController _botMoveController;
    private CharacterController _characterController;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _botController = new BotController(this);
        _botMoveController = new BotMoveController(this, _sOBotModel, _characterController, _buttonVierw);
    }

    private void Update()
    {
        _botController.Update();
        _botMoveController.Update();
        _sOBotPosition.BotPosition = this.transform.position;
    }
    private void FixedUpdate()
    {
        _botMoveController.FixedUpdate();
    }
    public GameObject BodyBot => _bodyBot;
    public GameObject TowerBot => _towerBot;
    public GameObject GunBot => _gunBot;
    public Transform GetTransformPosition() => _startPointRayCast;
    public void SetStartRayPosition(Transform pos)
    {
        _startPointRayCast = pos;
    }
}
