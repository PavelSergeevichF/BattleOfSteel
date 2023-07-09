using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOLicenseAgreement", menuName = "User/SOLicenseAgreement", order = 1)]
public class SOLicenseAgreement : ScriptableObject
{
    public string MineHeadText = "Лицензионное соглашение";
   public List<Paragraph> Paragraph = new List<Paragraph>();
}

[Serializable]
public struct Paragraph
{
    public string HeadText;
    public string BodyText;
}