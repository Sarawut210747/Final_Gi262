using UnityEngine;

[CreateAssetMenu(menuName = "LevelUp/Accessory")]
public class AccessorySO : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public int maxLevel = 2;

    [Header("Effect per level")]
    public float[] valuePerLevel; // เช่น moveSpeed, armor, attack speed
}
