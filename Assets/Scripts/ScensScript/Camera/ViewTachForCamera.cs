using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ViewTachForCamera : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image _joystickBG;
    [SerializeField] private Image _joystick;
    [SerializeField] private GameObject _uIPanel;
    [SerializeField] private int _turningAngel =90;
    [SerializeField] private bool _reversX=false;
    [SerializeField] private bool _reversY = false;
    [SerializeField] private GameObject _player;

    public Vector2 InputVector;

    private ControllerCameraRotation _controllerCameraRotation;
    public ControllerCameraRotation ControllerCameraRotation => _controllerCameraRotation;
    public GameObject UIPanel => _uIPanel;

    private void Awake()
    {
        _player = GameObject.Find("Player");
        _controllerCameraRotation = new ControllerCameraRotation(this, _joystickBG, _joystick, _turningAngel, _player, _reversX, _reversY);
    }
    public void SetInputVector(Vector2 vector2)
    {
        InputVector = vector2;
    }
    public void OnDrag(PointerEventData eventData) => _controllerCameraRotation.OnDrag(eventData);

    public void OnPointerUp(PointerEventData eventData) => _controllerCameraRotation.OnPointerUp(eventData);

    public void OnPointerDown(PointerEventData eventData) => _controllerCameraRotation.OnPointerDown(eventData);
}
