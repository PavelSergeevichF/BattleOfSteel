using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "SOInfoHelpText", menuName = "InfoHelp/SOInfoHelpText", order = 1)]
public class SOInfoHelpText : ScriptableObject
{
    public string HelpTextHead;
    public string HelpTextBody;
}
