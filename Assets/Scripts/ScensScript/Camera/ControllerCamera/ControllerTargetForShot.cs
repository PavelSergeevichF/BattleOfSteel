using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTargetForShot
{
    private Camera _camera;
    private SOCameraConnect _sOCameraConnect;
    private GameObject _targetGameObject;
    private GameObject _collisionGameObject;
    private float _distTarget;

    public ControllerTargetForShot(Camera camera, SOCameraConnect sOCameraConnect, GameObject targetGameObject, GameObject collisionGameObject, float distTarget)
    {
        _camera = camera;
        _sOCameraConnect = sOCameraConnect;
        _distTarget = distTarget;
        _targetGameObject = targetGameObject;
        _collisionGameObject = collisionGameObject;
    }
    public void Update()
    {
        GetPosition();
    }

    private void GetPosition()
    {
        Vector3 direction = _targetGameObject.transform.position - _camera.transform.position;
        RaycastHit[] hits = Physics.RaycastAll(_camera.transform.position, direction);
        if (hits != null)
        {
            _sOCameraConnect.TargetPosition = hits[0].point;
        }
        Debug.DrawLine(_camera.transform.position, _targetGameObject.transform.position, Color.red);
    }
}
