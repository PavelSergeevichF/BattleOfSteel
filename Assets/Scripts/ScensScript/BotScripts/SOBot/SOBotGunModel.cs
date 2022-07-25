using UnityEngine;

[CreateAssetMenu(fileName = nameof(SOBotGunModel), menuName = "SOGame/" + nameof(SOBotGunModel), order = 0)]
public class SOBotGunModel : ScriptableObject
{
    public bool Gun = false;
    public float CaliberGun = 20;
    public int LongGun = 200;

    public bool MachineGun = false;
    public float CaliberMachineGun = 5;
    public int LongMachineGun = 100;
}
