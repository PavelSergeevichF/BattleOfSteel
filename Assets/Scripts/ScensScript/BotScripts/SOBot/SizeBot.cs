using System;
using UnityEngine;

[Serializable]
public struct SizeBot
{
    [SerializeField] private float _longBody;
    [SerializeField] private float _heightBody;
    [SerializeField] private float _widthBody;
    [SerializeField] private float _longTower;
    [SerializeField] private float _heightTower;
    [SerializeField] private float _widthTower;
    [SerializeField] private float _groundClearance;


    public SizeBot(float lB, float hB, float wB, float lT, float hT, float wT, float gc)
    {
        _longBody = lB;
        _heightBody = hB;
        _widthBody = wB;
        _longTower = lT;
        _heightTower = hT;
        _widthTower = wT;
        _groundClearance = gc;
    }

    public void SetSize(float lB, float hB, float wB, float lT, float hT, float wT, float gc)
    {
        _longBody = lB;
        _heightBody = hB;
        _widthBody = wB;
        _longTower = lT;
        _heightTower = hT;
        _widthTower = wT;
        _groundClearance = gc;
    }
    public float GetLongBody() => _longBody;
    public float GetHeightBody() => _heightBody;
    public float GetWidthBody() => _widthBody;
    public float GetLongTower() => _longTower;
    public float GetHeightTower() => _heightTower;
    public float GetWidthTower() => _widthTower;
    public float GetClearance() => _groundClearance;

    public void GetSize(ref float lB, ref float hB, ref float wB, ref float lT, ref float hT, ref float wT, ref float gc)
    {
        lB = _longBody;
        hB = _heightBody;
        wB = _widthBody;
        lT = _longTower;
        hT = _heightTower;
        wT = _widthTower;
        gc = _groundClearance;
    }

    public void GetSizeBody(ref float lB, ref float hB, ref float wB)
    {
        lB = _longBody;
        hB = _heightBody;
        wB = _widthBody;
    }
    public void GetSizeTower(ref float lT, ref float hT, ref float wT)
    {
        lT = _longTower;
        hT = _heightTower;
        wT = _widthTower;
    }
}