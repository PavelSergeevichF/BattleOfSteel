using UnityEngine;

public class ViewButtonFire : MonoBehaviour
{
    public SOBotConnect Bot;
    private ButtonFireController _buttonFireController;


    private void Start()
    {
        _buttonFireController = new ButtonFireController(Bot);
    }
    private void Update() => _buttonFireController.Update();
    public void GunFire() => _buttonFireController.GunFire();
    public void MachineGunFire() => _buttonFireController.MachineGunFire();
}
