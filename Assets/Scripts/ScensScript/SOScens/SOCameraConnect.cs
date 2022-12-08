using UnityEngine;

[CreateAssetMenu(fileName = nameof(SOCameraConnect), menuName = "SOGame/" + nameof(SOCameraConnect), order = 0)]
public class SOCameraConnect : ScriptableObject
{
    public Camera Camera;
    public Vector3 TargetPosition;
}
