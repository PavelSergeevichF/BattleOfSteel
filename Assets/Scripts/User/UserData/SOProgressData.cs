using UnityEngine;

[CreateAssetMenu(fileName = "SOProgressData", menuName = "User/SOProgressData", order = 1)]
public class SOProgressData : ScriptableObject
{
    public float VictoriesPercentages = 0; 
    public float Victories = 0;
    public float Defeats = 0;
    public int Battles = 0;
    public float SkillPercentages = 0;
    public long Shots¿ired = 0;
    public long DestroyEnemy = 0;
    public long DestroyModules = 0;
    public long Destroy = 0;
    public int Awards = 0;
}
