using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skill/Create New Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public int bulletCount = 1; // a ‚Ì‘ã‚í‚è
    public bool isSpreadType = false;
    public bool isBurstType = false;
    public float fireRate = 0.2f; // ”­ŽËŠÔŠu
    public Sprite WeaponImage;
}