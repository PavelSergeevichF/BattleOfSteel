using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonView : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image joystickBG;
    [SerializeField] private Image joystick;
    [SerializeField] private GameObject buttonGunFire;
    [SerializeField] private GameObject buttonMGunFire;
    [SerializeField] private GameObject buttonMenu;
    private JoystickController joystickController;
    private ButtonController buttonController;
    public Vector2 InputVector;
    public JoystickController JoystickController=> joystickController;

    private void Awake()
    {
        joystickController = new JoystickController(this, joystickBG, joystick);
    }

    void Start()
    {        
        buttonController = new ButtonController(this, buttonGunFire, buttonMGunFire, buttonMenu);
    }
    public void OnDrag(PointerEventData eventData) => joystickController.OnDrag(eventData);

    public void OnPointerUp(PointerEventData eventData) => joystickController.OnPointerUp(eventData);

    public void OnPointerDown(PointerEventData eventData) => joystickController.OnPointerDown(eventData);
}
