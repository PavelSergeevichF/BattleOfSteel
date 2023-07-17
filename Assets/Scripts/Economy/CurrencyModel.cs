using System;

[Serializable]
public class CurrencyModel
{
    public int Gold;
    public int Silver;
    public int Copper;

    public void SetCurrencyModel(int g, int s, int c)
    {
        Gold=g;
        Silver = s;
        Copper = c;
    }
}
