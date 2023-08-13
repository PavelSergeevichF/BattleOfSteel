using System;
using System.Collections.Generic;

[Serializable]
public struct BotShellModel
{
    public Dictionary<eBulletType, int> BulletNum;
    public Dictionary<eShellType, int> ShellNum;
}

public enum eBulletType
{
    SC,//обычная
    TB,//трассирующая
    BB,//бронебойная
    IB,//зажигательная
    TIB,//трассирубщая зажигательная
    BIB,//бронебойно зажигательная
    TBIB//трассирующая бронебойно зажигательная
}
public enum eShellType
{
    BB,//Бронебойный
    SCP,//Подколиберный
    HES,//Фугас
    THES,//Фугас трассирующи
    CS,//Кумулятивный 
    DS,//управляемый
    AS//спец
}