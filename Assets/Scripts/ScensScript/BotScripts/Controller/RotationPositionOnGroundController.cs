using UnityEngine;

public class RotationPositionOnGroundController 
{
    private BotView _botView;
    private Transform _transform;
    private Vector3 _vector3Start = new Vector3();
    private Vector3 _vector3Target = new Vector3();
    private const float _distStartPointRay = 3f;
    private float _distance = 5.0f;
    public RotationPositionOnGroundController(BotView botView)
    {
        _botView = botView;
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
        //_vector3Start  = _botView.transform.position;
        //_vector3Start.y = _botView.transform.position.y + _distStartPointRay;
        //_transform.position = _vector3Start;
        _botView.SetStartRayPosition(_transform);
    }
    private void GetRotation()
    {
        RaycastHit hit;
        Vector3 fwd = _botView.transform.forward;
        Ray ray = new Ray(_botView.transform.position, fwd);
        Physics.Raycast(ray, out hit, _distance);
        //if (hit.collider != null)
        //{
        //    Debug.Log("***");
        //    if (hit.collider.GetComponent<Terrain>())
        //    {
        //        Debug.Log("+++");
        //    }
        //    Debug.DrawLine(ray.origin, hit.point, Color.red);
        //}
        Debug.DrawLine(ray.origin, fwd, Color.red);
    }
}
