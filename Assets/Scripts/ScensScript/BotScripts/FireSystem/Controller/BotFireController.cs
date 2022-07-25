
using UnityEngine;

public class BotFireController
{
    private Camera _camera;
    private int _distance;
    private BotSetDamageController _botSetDamageController;
    public BotFireController(Camera camera, int distance, BotSetDamageController botSetDamageController)
    {
        _camera = camera;
        _distance = distance;
        _botSetDamageController = botSetDamageController;
    }
    public void GunFire()
    {
        Ray(EGunTaype.Gun);
    }
    public void MachineGunFire()
    {
        Ray(EGunTaype.MachineGun);
    }
    private void Ray(EGunTaype taype)
    {
        RaycastHit hit;
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward * _distance);
        Physics.Raycast(ray, out hit, _distance);
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * _distance, Color.red);
        if (hit.collider != null)
        {
            if(hit.collider.GetComponent<BotGetDamageView>() != null)
            {
                _botSetDamageController.SetDataFire(taype, hit.distance);
            }
        }
    }
}
