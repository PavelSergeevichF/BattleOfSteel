using UnityEngine;

public class ControllerCameraPosition 
{
    private ViewCamera _viewCamera;
    private SOBotPosition _sOBotPosition;
    public ControllerCameraPosition(ViewCamera viewCamera, SOBotPosition sOBotPosition)
    {
        _viewCamera = viewCamera;
        _sOBotPosition = sOBotPosition;
    }
    public void ControllerCameraPositionUpdate()
    {
        _viewCamera.transform.position = _sOBotPosition.BotPosition;
    }
}
