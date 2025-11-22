using UnityEngine;

[CreateAssetMenu(menuName = "LevelUp/Weapon")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public Sprite icon;

    [Header("Level Data (Max 5 LV)")]
    public int maxLevel = 5;
    public int[] damagePerLevel;
    public float[] rangePerLevel;
}
