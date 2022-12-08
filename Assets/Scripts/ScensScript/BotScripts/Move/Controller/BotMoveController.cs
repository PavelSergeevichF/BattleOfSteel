using UnityEngine;
using System;

public class BotMoveController
{
    private BotView _botView;
    private SOBotModel _sOBotModel;
    private float _gravitySpeed;
    private float _vertical;
    private bool _pleer;
    private const float _gravityForceMove=20f;
    private const float _gravityForceStop=-1f;
    private const int _boost = 1;
    private const int _stoping = 5;
    private const float _const = 57.3f;
    private Vector3 _moveVector;
    private Vector3 _rotatePosition;
    private Vector3 _rotate;
    private CharacterController _characterController;
    private BotRotationController _botRotationController;
    private JoysticView _joysticView;
    private RotationPositionOnGroundController _positionOnGroundController;
    public BotMoveController(BotView botView, 
                             SOBotModel sOBotModel, 
                             CharacterController characterController,
                             JoysticView joysticView, bool pleer)
    {
        _botView = botView;
        _sOBotModel = sOBotModel;
        _characterController = characterController;
        _joysticView = joysticView;
        _pleer = pleer;
        _botRotationController = new BotRotationController(_joysticView, _characterController, this);
        _positionOnGroundController = new RotationPositionOnGroundController(_botView, this);
        if(!_pleer)
        {
            _botView.GetSOBotConnect().bot.GetComponent<Rigidbody>().useGravity = true;
        }
        _rotatePosition = new Vector3(0, 0, 0);
    }
    public void Update()
    {
        _positionOnGroundController.Update();
    }
    public void FixedUpdate()
    {
        if(_pleer)
        {
            CharacterMove();
            GamingGravity();
        }
    }
    public float GetSpeed()=> _sOBotModel.MaxSpeedBot;
    public void SetDirRotate(Vector3 dir)
    {
        _rotate = dir;
    }
    private void CharacterMove()
	{
        _moveVector = Vector3.zero;
        moveLogic();
        float cof = 1;
        float step = 1 / _sOBotModel.MaxSpeedBot;
        if (_characterController.isGrounded)
        {
            if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
            {
                if (_sOBotModel.Tracks)
                {
                    Rotate(cof);
                }
                else 
                {
                    float speedMove = _sOBotModel.SpeedBot < 0.01f ? 0 : _sOBotModel.SpeedBot;
                    cof = _sOBotModel.SpeedBot * step;
                    Rotate(cof);
                    //Настроить повороты!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                }
                
            }
        }
        _moveVector = _botView.transform.forward * _sOBotModel.SpeedBot;
        _moveVector.y = _gravitySpeed;
        _characterController.Move(_moveVector * Time.deltaTime);
    }
    private void Rotate(float cof)
    {
        _rotatePosition += _rotate;
        _botView.transform.rotation = Quaternion.Euler(
        _setRotateData(_rotatePosition.x),
        _botRotationController.CharacterRotation(_joysticView.InputVector.y < -0.05 && _sOBotModel.SpeedBot < 0) * cof,
        _setRotateData(_rotatePosition.z));
    }
    private float _setRotateData(float inData)
    {
        return _const * inData;
    }
    private void moveLogic()
    {
        if (_joysticView.InputVector.y > 0.05)
        {
            if (_sOBotModel.SpeedBot >= 0)
            {
                _sOBotModel.SpeedBot += BoostMath(_boost);
            }
            else
            {
                _sOBotModel.SpeedBot += BoostMath(_stoping);
            }
        }
        else
        {
            if (_joysticView.InputVector.y < -0.05)
            {
                if (_sOBotModel.SpeedBot <= 0)
                {
                    _sOBotModel.SpeedBot -= BoostMath(_boost);
                }
                else 
                {
                    _sOBotModel.SpeedBot -= BoostMath(_stoping);
                }
            }
            else 
            {
                if (_sOBotModel.SpeedBot > 0)
                {
                    _sOBotModel.SpeedBot -= _sOBotModel.Boost;
                }
                if (_sOBotModel.SpeedBot < 0)
                {
                    _sOBotModel.SpeedBot += _sOBotModel.Boost;
                }
            }
        }
    }
    private float BoostMath(int cof)
    { 
        return _sOBotModel.SpeedBot < _sOBotModel.MaxSpeedBot ? _sOBotModel.Boost *cof : 0;
    }
    private float _verticalOld()
    {
        if (_joysticView.InputVector.y != 0)
        {
            if (_joysticView.InputVector.y > 0.05
                || _joysticView.InputVector.y < -0.05)
            {
                return _joysticView.InputVector.y;
            }
            else
            {
                return 0;
            }
        }
        else return Input.GetAxis("Vertical");
    }

    private void GamingGravity()
	{
		if(!_characterController.isGrounded)
        {
            _gravitySpeed -= _gravityForceMove * Time.deltaTime;
        }
        else
        {
            _gravitySpeed = _gravityForceStop;
        }
	}
    public void SetRotatePosition(Vector3 vector3)
    {
        _rotatePosition = vector3;
    }
}
