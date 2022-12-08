﻿using System;
using UnityEngine;
public class BotRotationController
{
    private float _rotation = 0.0f;
    private Vector3 _moveVector;

    private JoysticView _joysticView;
    private CharacterController _characterController;
	private BotMoveController _botMoveController;
	public BotRotationController(JoysticView joysticView, CharacterController characterController, BotMoveController botMoveController)
    {
        _joysticView = joysticView;
        _characterController = characterController;
        _botMoveController = botMoveController;
    }

	public float CharacterRotation(bool inversion)
    {
        if (inversion)
        {
            _rotation += -_horizontal();
        }
        else 
        {
            _rotation += _horizontal();
        }
        _rotation=_checkRotation(_rotation);
        return _rotation;
    }
    private float _horizontal()
    {
        if (_joysticView.InputVector.x != 0)
        {
            if (   _joysticView.InputVector.x < -0.05
                || _joysticView.InputVector.x >  0.05)
            {
                return _joysticView.InputVector.x;
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