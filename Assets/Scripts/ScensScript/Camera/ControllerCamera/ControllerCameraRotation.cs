using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerCameraRotation
{
    private GameObject _player;
    private ViewTachForCamera _viewTachForCamera;
    private Image _joystickBG;
    private Image _joystick;
    private Vector2 _inputVector;
    private Vector2 _startPosOnTach = new Vector2();
    private int _turningAngel;
    private float _angelRotate;
    private float _tempAngelRotate;
    private bool _ifStartDrag = true;
    private bool _reversX = false;
    private bool _reversY = false;


    public ControllerCameraRotation(ViewTachForCamera viewTachForCamera, Image joystickBG, Image joystick, int turningAngel, GameObject player, bool reversX, bool reversY)
    {
        _viewTachForCamera = viewTachForCamera;
        _joystickBG = joystickBG;
        _joystick = joystick;
        _turningAngel = turningAngel;
        _player = player;
        _reversX = reversX;
        _reversY = reversY;
    }

    public void Update()
    {
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        //Косание
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        _inputVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
        _viewTachForCamera.SetInputVector(_inputVector);
        _ifStartDrag = true;
        _angelRotate = _tempAngelRotate;
        //Отпускание
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 realPosOnTach;
        Vector2 deltaPosOnTach;
        var tmp = _viewTachForCamera.UIPanel.GetComponent<RectTransform>().rect;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (_joystickBG.rectTransform, ped.position, ped.pressEventCamera, out realPosOnTach))
        {
            realPosOnTach.x = (realPosOnTach.x / (_viewTachForCamera.UIPanel.GetComponent<RectTransform>().rect.width/2));
            realPosOnTach.y = (realPosOnTach.y / (_viewTachForCamera.UIPanel.GetComponent<RectTransform>().rect.height/2));
            DataInfoChitController.SetText(1, $"posX {realPosOnTach.x},   posY {realPosOnTach.y}");

            if(_ifStartDrag)
            {
                _ifStartDrag = false;
                Vector2 tmpVector = new Vector2(realPosOnTach.x, realPosOnTach.y);
                _startPosOnTach = tmpVector;
            }
            deltaPosOnTach = realPosOnTach - _startPosOnTach;

            _tempAngelRotate = deltaPosOnTach.x* _turningAngel+ _angelRotate;
            _tempAngelRotate = CheckAngel(_tempAngelRotate);
            _tempAngelRotate = _reversX? -_tempAngelRotate: _tempAngelRotate;
            _player.GetComponent<PlayerView>().CentrCamTransform.rotation = 
                Quaternion.Euler( 0, _tempAngelRotate, 0);

            _inputVector = new Vector2(realPosOnTach.x , realPosOnTach.y);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;
            _joystick.rectTransform.anchoredPosition =
                new Vector2(
                    _inputVector.x * (_viewTachForCamera.UIPanel.GetComponent<RectTransform>().rect.width / 2),
                    _inputVector.y * (_viewTachForCamera.UIPanel.GetComponent<RectTransform>().rect.height / 2));
            DataInfoChitController.SetText(2, $"xx {0}, xx {0}");
            DataInfoChitController.SetText(3, $"deltaPosOnTach {deltaPosOnTach}");
            DataInfoChitController.SetText(4, $"_inputVector {_inputVector}");
            DataInfoChitController.SetText(5, $"_angelRotate {_angelRotate}");
            DataInfoChitController.SetText(6, $"tempAngelRotate {_tempAngelRotate}");
            _viewTachForCamera.SetInputVector(_inputVector);
        }
    }
    private float CheckAngel(float angel)
    {
        float ang = 0;
        if(angel > 360)
        {
            ang = angel - 360;
        }
        else
        { 
            if(angel < -360)
            {
                ang = angel + 360;
            }
            else 
            {
                ang = angel;
            }
        }
        return ang;
    }
}