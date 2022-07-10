using System;
using UnityEngine;
public class BotRotationController
{
    private float _rotation = 0.0f;
    private Vector3 _moveVector;

    private ButtonView _buttonVierw;
    private CharacterController _characterController;
	private BotMoveController _botMoveController;
	public BotRotationController(ButtonView buttonVierw, CharacterController characterController, BotMoveController botMoveController)
    {
        _buttonVierw = buttonVierw;
        _characterController = characterController;
        _botMoveController = botMoveController;
    }

	public float CharacterRotation()
    {
        _rotation += _horizontal();
        _rotation=_checkRotation(_rotation);
        return _rotation;
    }
    private float _horizontal()
    {
        if (_buttonVierw.InputVector.x != 0)
        {
            if (   _buttonVierw.InputVector.x < -0.05
                || _buttonVierw.InputVector.x >  0.05)
            {
                return _buttonVierw.InputVector.x;
            }
            else
            {
                return 0;
            }
        } 
        else return Input.GetAxis("Horizontal");
    }
    private float _checkRotation(float rotation)
    {
        if (rotation > 360) rotation -= 360;
        if (rotation < -360) rotation += 360;
        return rotation;
    }
}