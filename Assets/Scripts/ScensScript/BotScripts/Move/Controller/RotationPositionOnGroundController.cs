using UnityEngine;

public class RotationPositionOnGroundController 
{
    private BotView _botView;
    private BotMoveController _botMoveController;
    private Transform _transform;
    private Vector3 _vector3Start = new Vector3();
    private const float _distStartPointRay = 3f;
    private float _distance =10.0f;
    public RotationPositionOnGroundController(BotView botView, BotMoveController botMoveController)
    {
        _botView = botView;
        _botMoveController = botMoveController;
        _transform = _botView.GetTransformPosition();
        setPositionStartRay();
    }
    public void Update()
    {
        setPositionStartRay();
        GetRotation();
    }
    private void setPositionStartRay()
    {
        _vector3Start  = _botView.transform.position;
        _vector3Start.y = _botView.transform.position.y + _distStartPointRay;
        _transform.position = _vector3Start;
        _botView.SetStartRayPosition(_transform);
    }
    private void GetRotation()
    {
        RaycastHit hit;
        Ray ray = new Ray(_vector3Start, -Vector3.up* _distance);
        if(_botView.TerrainCollider.Raycast(ray, out hit, _distance))
        {
            Vector3 normal = hit.normal;
            Vector3 contactPoint = hit.point;
            Debug.DrawRay(contactPoint, normal, Color.red);
            _botMoveController.SetRotatePosition(normal);
        }
        Debug.DrawRay(ray.origin, -Vector3.up * _distance, Color.green);
    }
}
