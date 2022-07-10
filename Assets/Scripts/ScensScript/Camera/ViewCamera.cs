using UnityEngine;

public class ViewCamera : MonoBehaviour
{
    [SerializeField] private SOBotPosition _sOBotPosition;
    [SerializeField] private Camera _camera;
    private ControllerCameraPosition _controllerCameraPosition;
    private void Start()
    {
        _controllerCameraPosition = new ControllerCameraPosition(this, _sOBotPosition);
    }
    private void Update()
    {
        _controllerCameraPosition.ControllerCameraPositionUpdate();
    }
}
