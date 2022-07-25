using UnityEngine;

public class ViewCamera : MonoBehaviour
{
    [SerializeField] private SOBotPosition _sOBotPosition;
    [SerializeField] private Camera _camera;
    [SerializeField] private SOCameraConnect _sOCameraConnect;
    private ControllerCameraPosition _controllerCameraPosition;
    private void Start()
    {
        _controllerCameraPosition = new ControllerCameraPosition(this, _sOBotPosition);
        _sOCameraConnect.Camera = _camera;
    }
    private void Update()
    {
        _controllerCameraPosition.ControllerCameraPositionUpdate();
    }
}
