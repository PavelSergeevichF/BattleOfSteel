using System;

[Serializable]
public struct GunModel
{
    public bool Gun;
    public float CaliberGun;
    public int LongGun;
    public int FiringRateGun;

    public bool MachineGun;
    public float CaliberMachineGun;
    public int LongMachineGun;
    public int FiringRateMachineGun;

    public GunModel(bool setGun, bool setMachineGun)
    {
        Gun = setGun;
        CaliberGun = 20;
        LongGun = 200;
        FiringRateGun = 6;

        MachineGun = setMachineGun;
        CaliberMachineGun = 5;
        LongMachineGun = 100;
        FiringRateMachineGun = 300;
    }

    public void SetGun(int Long, float Caliber, int FiringRate)
    {
        LongGun = Long;
        CaliberGun = Caliber;
        FiringRateGun = FiringRate;
    }

    public void SetMachineGun(int Long, float Caliber, int FiringRate)
    {
        LongMachineGun = Long;
        CaliberMachineGun = Caliber;
        FiringRateMachineGun = FiringRate;
    }
}