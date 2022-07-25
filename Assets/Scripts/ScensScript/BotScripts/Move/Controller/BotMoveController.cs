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
    private CharacterController _characterController;
    private BotRotationController _botRotationController;
    private ButtonView _buttonVierw;
    private RotationPositionOnGroundController _PositionOnGroundController;
    public BotMoveController(BotView botView, 
                             SOBotModel sOBotModel, 
                             CharacterController characterController,
                             ButtonView buttonVierw, bool pleer)
    {
        _botView = botView;
        _sOBotModel = sOBotModel;
        _characterController = characterController;
        _buttonVierw = buttonVierw;
        _pleer = pleer;
        _botRotationController = new BotRotationController(_buttonVierw, _characterController, this);
        _PositionOnGroundController = new RotationPositionOnGroundController(_botView, this);
        if(!_pleer)
        {
            _botView.GetSOBotConnect().bot.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    public void Update()
    {
        _PositionOnGroundController.Update();
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
    private void CharacterMove()
	{
        _moveVector = Vector3.zero;
        moveLogic();
        if (_characterController.isGrounded)
        {
            if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
            {
                if (_sOBotModel.Tracks)
                {
                    _botView.transform.rotation = Quaternion.Euler(
                    _setRotateData(_rotatePosition.x),
                    _botRotationController.CharacterRotation(),
                    _setRotateData(_rotatePosition.z));
                }
                else 
                {
                    float cof = 1;
                    _botView.transform.rotation = Quaternion.Euler(
                    _setRotateData(_rotatePosition.x),
                    _botRotationController.CharacterRotation()* cof,
                    _setRotateData(_rotatePosition.z));
                }
                
            }
        }
        _moveVector = _botView.transform.forward * _sOBotModel.SpeedBot;
        _moveVector.y = _gravitySpeed;
        _characterController.Move(_moveVector * Time.deltaTime);
    }
    private float _setRotateData(float inData)
    {
        return _const * inData;
    }
    private void moveLogic()
    {
        if (_buttonVierw.InputVector.y > 0.05)
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
            if (_buttonVierw.InputVector.y < -0.05)
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
        if (_buttonVierw.InputVector.y != 0)
        {
            if (_buttonVierw.InputVector.y > 0.05
                || _buttonVierw.InputVector.y < -0.05)
            {
                return _buttonVierw.InputVector.y;
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
