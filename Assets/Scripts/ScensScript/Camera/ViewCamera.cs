using UnityEngine;

public class ViewCamera : MonoBehaviour
{
    [SerializeField] private SOBotPosition _sOBotPosition;
    [SerializeField] private Camera _camera;
    [SerializeField] private SOCameraConnect _sOCameraConnect;
    [SerializeField] private JoysticView _joysticView; 
    [SerializeField] private ControllerTargetForShot _controllerTargetForShot;
    [SerializeField] private GameObject _targetGameObject;
    [SerializeField] private GameObject _collisionGameObject;
    [SerializeField] private float _distTarget=50f;

    private ControllerCameraPosition _controllerCameraPosition;

    private void Start()
    {
        _controllerCameraPosition = new ControllerCameraPosition(this, _sOBotPosition);
        _sOCameraConnect.Camera = _camera;
        _controllerTargetForShot = new ControllerTargetForShot(_camera, _sOCameraConnect, _targetGameObject, _collisionGameObject, _distTarget);
    }
    private void Update()
    {
        _controllerCameraPosition.ControllerCameraPositionUpdate();
        _controllerTargetForShot.Update();
    }
}
