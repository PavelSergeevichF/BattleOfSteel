using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class JoystickController
{
    private ButtonView _buttonView;
    private Image _joystickBG;
    private Image _joystick;
	private const int _ratioJoystickX = 6;
	private const int _ratioJoystickY = 4;
	private const int _ratioPose = 4;
	private Vector2 _inputVector;

	public JoystickController(ButtonView buttonView, Image joystickBG, Image joystick)
    {                                              
        this._buttonView = buttonView;
        this._joystickBG = joystickBG;
        this._joystick = joystick;

	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		_inputVector = Vector2.zero;
		_joystick.rectTransform.anchoredPosition = Vector2.zero;
		_buttonView.InputVector = _inputVector;
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle
			(_joystickBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
		{
			pos.x = (pos.x / _joystickBG.rectTransform.sizeDelta.x);
			pos.y = (pos.y / _joystickBG.rectTransform.sizeDelta.x);
			float dataX = 0;
			if (pos.x < -0.2 || pos.x > 0.2) dataX = pos.x;
			_inputVector = new Vector2(dataX * _ratioPose, pos.y * _ratioPose);
			_inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;
			_joystick.rectTransform.anchoredPosition = 
				new Vector2(
					_inputVector.x * (_joystickBG.rectTransform.sizeDelta.x / _ratioJoystickX),
					_inputVector.y * (_joystickBG.rectTransform.sizeDelta.y / _ratioJoystickY));
			_buttonView.InputVector = _inputVector;
		}
	}

	public float Horizontal()
	{
		if (_inputVector.x != 0)
		{
			return _inputVector.x;
		}
		else return Input.GetAxis("Horizontal");
	}
	public float Vertical()
	{
		if (_inputVector.y != 0)
		{
			return _inputVector.y;
		}
		else return Input.GetAxis("Vertical");
	}
}
