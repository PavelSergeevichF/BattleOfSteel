using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataInfoChitController
{
    public static DataInfoChitView dataInfoChitView;

    public static void SetText(int line, string txt)
    {
        dataInfoChitView.SetText(line, txt);
    }
}
